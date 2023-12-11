namespace Congestion.Application
{
    public class CongestionService : ICongestionService
    {
        public Task AddCar(string tag)
        {
            throw new NotImplementedException();
        }

        public Task AddCongestionPlace(int cityId, string congectionPlaceName)
        {
            throw new NotImplementedException();
        }

        public Task AddTimeToll(int cityId, TimeSpan startTime, TimeSpan endTime, decimal tollAmount)
        {
            throw new NotImplementedException();
        }

        public Task AddTollRegistraion(int cityId, int congestionId, string vehicleNo)
        {
            throw new NotImplementedException();
        }

        public Task SaveCity(string name)
        {
            throw new NotImplementedException();
        }
       
    }
}