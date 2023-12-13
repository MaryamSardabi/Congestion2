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
            var calender = await _repository.GetCalenderDate(DateTime.Now.Date);
            var timetoll = await _repository.GetTimeToll(DateTime.Now.TimeOfDay);
            var car = await _repository.GetCarByTagAsync(tag);
            var tollRegistration = new TollRegistration(car, timetoll, congestionPlace, calender, 100, 100, DateTime.Now);
            await _repository.AddTollRegistrationAsync(tollRegistration);
        }

        
    }
}