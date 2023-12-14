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
            var carType = await _repository.GetCarTypeByIdAsync(carTypeId);
            if (carType == null) 
                throw new Exception("carType is not valid");

            var car = await _repository.GetCarByTagAsync(tag);
            if (car!=null)
            {
                throw new Exception("this tag has been already existed ");
            }          
            await _repository.AddCarAsync(new Car(tag, carType));

        }


    }
}