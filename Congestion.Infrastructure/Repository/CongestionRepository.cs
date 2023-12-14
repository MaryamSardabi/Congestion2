using AutoMapper;
using CongestionDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Congestion.Infrastructure.Repository
{
    public class CongestionRepository : ICongestionRepository
    {
        private readonly CongestionContext _context;
        public CongestionRepository(CongestionContext context)
        {
            _context = context;
        }

        public async Task<CarType> GetCarTypeByIdAsync(int carTypeId)
        {
            return await _context.CarTypes.FirstOrDefaultAsync(x => x.Id == carTypeId);
        }

        public async Task AddCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task<City> GetCityByIdAsync(int cityId)
        {
            return await _context.Cities.SingleOrDefaultAsync(x => x.Id == cityId);

        }

        public async Task<CongestionPlace> GetCongestionPlaceAsync(int cityId, int congestionPlaceId)
        {
            return await _context.CongestionPlaces.SingleOrDefaultAsync(x => x.CityId == cityId && x.Id == congestionPlaceId);
        }

        public async Task<Calender> GetCalenderDateAsync(DateTime calenderDate)
        {
            return await _context.Calenders.SingleOrDefaultAsync(x => x.Date.Date == calenderDate.Date);
    
        }

        public async Task<TimeToll> GetTimeTollAsync(TimeSpan timeSpan)
        {
            return await _context.TimeTolls.FirstOrDefaultAsync(x => x.StartTime < timeSpan && x.EndTime > timeSpan);
        }

        public async Task<Car?> GetCarByTagAsync(string tag)
        {
            return await _context.Cars.Include(c=>c.CarType).SingleOrDefaultAsync(x => x.Tag == tag);
        }

        public async Task AddTollRegistrationAsync(TollRegistration tollRegistration)
        {
            _context.TollRegistrations.Add(tollRegistration);
            await _context.SaveChangesAsync();
        }

        public async Task<TollRegistration> GetLastTollRegistrationAsync(int carId)
        {
            return await _context.TollRegistrations.Where(x => x.CarId == carId).OrderBy(x => x.RegistrationDateTime).FirstOrDefaultAsync();
        }
    }
}
