using Congestion.Infrastructure.Repository;
using CongestionDomain.Entities;

namespace Congestion.Application
{
    public class CarService : ICarService
    {
        private readonly ICongestionRepository _repository;
        public CarService(ICongestionRepository repository)
        {
            _repository = repository;
        }

        public async Task AddCarAsync(string tag, int carTypeId, CancellationToken ct)
        {
            var carType = await _repository.GetCarTypeById(carTypeId);
            if (carType == null) throw new Exception("carTypeType is not valid");

            var car = new Car(tag, carType);          
            await _repository.AddCar(car);

        }

       
    }
}