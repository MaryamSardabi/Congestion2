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

        public async Task<CarType> GetCarTypeById(int carTypeId)
        {
            return await _context.CarTypes.Where(x => x.Id == carTypeId).FirstOrDefaultAsync();
        }

        public async Task AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task<City> GetCityById(int cityId)
        {
            return await _context.Cities.Where(x => x.Id == cityId).FirstOrDefaultAsync();

        }

        public async Task<CongestionPlace> GetCongestionPlace(int cityId, int congestionPlaceId)
        {
            return await _context.CongestionPlaces.Where(x => x.CityId == cityId && x.Id == congestionPlaceId).FirstOrDefaultAsync();
        }

        public async Task<Calender> GetCalenderDate(DateTime calenderDate)
        {
            return await _context.Calenders.Where(x => x.Date == calenderDate).SingleOrDefaultAsync();
        }

        public async Task<TimeToll> GetTimeToll(TimeSpan timeSpan)
        {
            return await _context.TimeTolls.Where(x => x.StartTime > timeSpan && x.EndTime < timeSpan).FirstOrDefaultAsync();
        }

        public async Task<Car> GetCarByTagAsync(string tag)
        {
            return await _context.Cars.Where(x => x.Tag == tag).FirstOrDefaultAsync();
        }

        public async Task AddTollRegistrationAsync(TollRegistration tollRegistration)
        {
            _context.TollRegistrations.Add(tollRegistration);
            await _context.SaveChangesAsync();
        }
    }
}
