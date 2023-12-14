﻿using AutoMapper;
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
            return await _context.CarTypes.FirstOrDefaultAsync(x => x.Id == carTypeId);
        }

        public async Task AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task<City> GetCityById(int cityId)
        {
            return await _context.Cities.FirstOrDefaultAsync(x => x.Id == cityId);

        }

        public async Task<CongestionPlace> GetCongestionPlace(int cityId, int congestionPlaceId)
        {
            return await _context.CongestionPlaces.FirstOrDefaultAsync(x => x.CityId == cityId && x.Id == congestionPlaceId);
        }

        public async Task<Calender> GetCalenderDate(DateTime calenderDate)
        {
            return await _context.Calenders.SingleOrDefaultAsync(x => x.Date == calenderDate.Date);
        }

        public async Task<TimeToll> GetTimeToll(TimeSpan timeSpan)
        {
            return await _context.TimeTolls.FirstOrDefaultAsync(x => x.StartTime > timeSpan && x.EndTime < timeSpan);
        }

        public async Task<Car?> GetCarByTagAsync(string tag)
        {
            return await _context.Cars.FirstOrDefaultAsync(x => x.Tag == tag);
        }

        public async Task AddTollRegistrationAsync(TollRegistration tollRegistration)
        {
            _context.TollRegistrations.Add(tollRegistration);
            await _context.SaveChangesAsync();
        }

        public async Task<TollRegistration> GetLastTollRegistrationAsync(int carId)
        {
            return await _context.TollRegistrations.Where(x => x.CarId == carId).OrderBy(x=>x.RegistrationDateTime).FirstOrDefaultAsync();
        }
    }
}
