using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congestion.Application
{
    public interface ICongestionService
    {
        Task SaveCity(string name);
        Task AddCongestionPlace(int cityId, string congectionPlaceName);
        Task AddTimeToll(int cityId,TimeSpan startTime, TimeSpan endTime, decimal tollAmount);
        Task AddCar(string tag);
        Task AddTollRegistraion(int cityId, int congestionId, string vehicleNo);
    }
}
