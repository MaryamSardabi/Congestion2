using Congestion.Infrastructure.Repository;
using CongestionDomain.Entities;

namespace Congestion.Application
{
    public class TollRegistrationService : ITollRegistrationService
    {
        private readonly ICongestionRepository _repository;
        public TollRegistrationService(ICongestionRepository repository)
        {
            _repository = repository;
        }

        public async Task AddTollRegistraion(int cityId, int congestionId, string tag, CancellationToken ct)
        {
            var congestionPlace = await _repository.GetCongestionPlace(cityId, congestionId);
            var timetoll = await _repository.GetTimeToll(DateTime.Now.TimeOfDay);
            var today = await _repository.GetCalenderDate(DateTime.Now.Date);
            var tommorrow = await _repository.GetCalenderDate(DateTime.Now.Date.AddDays(1));
            var car = await _repository.GetCarByTagAsync(tag);

            if (car == null)
                throw new Exception("register the car first");
            if (car.CarType.IsTollFree)
            {
                await _repository.AddTollRegistrationAsync(new TollRegistration(car, timetoll, congestionPlace, today, 0, 0, DateTime.Now));
                return;
            }

            if (today.IsHoliday || today.IsTollFree || tommorrow.IsHoliday)
            {
                await _repository.AddTollRegistrationAsync(new TollRegistration(car, timetoll, congestionPlace, today, timetoll.TollAmount, 0, DateTime.Now));
                return;
            }

            var lastTollRegistration = await _repository.GetLastTollRegistrationAsync(car.Id);
            if (lastTollRegistration == null)
            {
                await _repository.AddTollRegistrationAsync(new TollRegistration(car, timetoll, congestionPlace, today, timetoll.TollAmount, timetoll.TollAmount, DateTime.Now));
                return;
            }
            else
            {
                var timeDifference = DateTime.Now - lastTollRegistration.RegistrationDateTime;
                if (timeDifference.Days > 0 || timeDifference.Hours > 0)
                    await _repository.AddTollRegistrationAsync(new TollRegistration(car, timetoll, congestionPlace, today, timetoll.TollAmount, timetoll.TollAmount, DateTime.Now));
                else
                {
                    var differenceTollAmount = timetoll.TollAmount - lastTollRegistration.PaidTollAmount;
                    if (differenceTollAmount > 0)
                        await _repository.AddTollRegistrationAsync(new TollRegistration(car, timetoll, congestionPlace, today, timetoll.TollAmount, differenceTollAmount, DateTime.Now));
                    else
                        await _repository.AddTollRegistrationAsync(new TollRegistration(car, timetoll, congestionPlace, today, timetoll.TollAmount, 0, DateTime.Now));

                }
            }
        }


    }
}