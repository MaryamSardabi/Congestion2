using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionDomain.Entities
{
    public class TimeToll
    {
        public int Id { get; private set; }
        public int CityId { get; private set; }    
        public City City{ get; private set; }    
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }
        public decimal TollAmount { get; private set; }
        public List<TollRegistration> TollRegistrations { get; private set; }

        protected TimeToll()
        {

        }
        public TimeToll(City city,TimeSpan startTime, TimeSpan endTime, decimal tollAmount)
        {
            City = city;
            StartTime = startTime;
            EndTime = endTime;
            TollAmount = tollAmount;
            TollRegistrations = new List<TollRegistration>();
        }
    }
}
