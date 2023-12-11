using AutoMapper;
using CongestionDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Congestion.Infrastructure.Repository
{
    public class CongestionRepository : ICongestionRepository
    {
        private readonly CongestionContext _context;
        private readonly IMapper _mapper;
        public CongestionRepository(CongestionContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            var dbCars = await _context.Cars.AsNoTracking().ToListAsync();
            var cars = _mapper.Map<List<Car>>(dbCars);
            return cars;

        }

        public async Task<Car> GetCarByNoAsync(string tag)
        {
            var DbCar = await _context.Cars.Where(x => x.Tag == tag).SingleOrDefaultAsync();
            var car = _mapper.Map<Car>(DbCar);
            return car;

        }

        public async Task<List<TimeToll>> GetTimeTollsAsync()
        {
            var dbTimeTolls = await _context.TimeTolls.AsNoTracking().ToListAsync();
            var timeTolls = _mapper.Map<List<TimeToll>>(dbTimeTolls);
            return timeTolls;
        }

        public async Task<TimeToll> GetTimeTollByTimeAsync(TimeSpan timeSpan)
        {
            var dbTimeToll = await _context.TimeTolls.Where(x => x.StartTime < timeSpan && x.EndTime > timeSpan).SingleOrDefaultAsync();
            var timeToll = _mapper.Map<TimeToll>(dbTimeToll);
            return timeToll;
        }

        public async Task<City> GetCityByNameAsync(string name)
        {
            var dbCity = await _context.Cities.Where(x => x.Name == name).SingleOrDefaultAsync();
            var city = _mapper.Map<City>(dbCity);
            return city;
        }

        public async Task<CongestionPlace> GetCongestionPlaceByNameAsync(string name)
        {
            var dbCongestionPlace = await _context.CongestionPlaces.Where(x => x.Name == name).SingleOrDefaultAsync();
            var congestionPlace = _mapper.Map<CongestionPlace>(dbCongestionPlace);
            return congestionPlace;
        }
    }
}
