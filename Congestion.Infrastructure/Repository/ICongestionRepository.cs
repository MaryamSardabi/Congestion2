using CongestionDomain.Entities;

namespace Congestion.Infrastructure.Repository
{
    public interface ICongestionRepository
    {
        Task<CarType> GetCarTypeById(int carType);
        Task AddCar(Car car);
        Task<City> GetCityById(int cityId);
        Task<CongestionPlace> GetCongestionPlace(int cityId, int congestionPlaceId);
        Task<Calender> GetCalenderDate(DateTime calenderDate);
        Task<TimeToll> GetTimeToll(TimeSpan timeSpan);
        Task<Car> GetCarByTagAsync(string tag);
        Task AddTollRegistrationAsync(TollRegistration tollRegistration);
        Task<TollRegistration> GetById(int tollRegistrationId, CancellationToken none);
    }
}
