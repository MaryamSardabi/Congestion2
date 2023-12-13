using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congestion.Application
{
    public interface ICarService
    {      
        Task AddCarAsync(string tag, int carTypeId, CancellationToken ct);
    }
}
