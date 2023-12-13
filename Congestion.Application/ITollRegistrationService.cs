using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congestion.Application
{
    public interface ITollRegistrationService
    {
        Task AddTollRegistraion(int cityId, int congestionId, string tag, CancellationToken ct);
        //Task SaveCity(string name);
        //Task AddCongestionPlace(int cityId, string congectionPlaceName);
        //Task AddTimeToll(int cityId, TimeSpan startTime, TimeSpan endTime, decimal tollAmount);

    }
}
