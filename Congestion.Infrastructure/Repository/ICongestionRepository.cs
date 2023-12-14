using CongestionDomain.Entities;

namespace Congestion.Infrastructure.Repository
{
    public interface ICongestionRepository
    {
        Task<CarType> GetCarTypeByIdAsync(int carType);
        Task AddCarAsync(Car car);
        Task<City> GetCityByIdAsync(int cityId);
        Task<CongestionPlace> GetCongestionPlaceAsync(int cityId, int congestionPlaceId);
        Task<Calender> GetCalenderDateAsync(DateTime calenderDate);
        Task<TimeToll> GetTimeTollAsync(TimeSpan timeSpan);
        Task<Car> GetCarByTagAsync(string tag);
        Task AddTollRegistrationAsync(TollRegistration tollRegistration);
        Task<TollRegistration> GetLastTollRegistrationAsync(int carId);

    }
}
