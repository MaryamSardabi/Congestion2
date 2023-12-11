using CongestionDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congestion.Infrastructure.Repository
{
    public interface ICongestionRepository
    {
        Task<City> GetCityByNameAsync(string name);
        Task<CongestionPlace> GetCongestionPlaceByNameAsync(string name);
        Task<List<Car>> GetCarsAsync();
        Task<Car> GetCarByNoAsync(string no);
        Task<List<TimeToll>> GetTimeTollsAsync();
        Task<TimeToll> GetTimeTollByTimeAsync(TimeSpan timeSpan);






    }
}
