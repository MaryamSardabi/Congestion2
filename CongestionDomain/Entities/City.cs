using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionDomain.Entities
{
    public class City
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<CongestionPlace> Congestions { get; private set; }
        public List<TimeToll> TimeTolls { get; private set; }
        public City()
        {

        }
        public City(string name)
        {
            Name = name;
            Congestions = new List<CongestionPlace>();
            TimeTolls = new List<TimeToll>();
        }
        public void AddCongestion(string name)
        {
            var congestion = new CongestionPlace(name, this);
            Congestions.Add(congestion);
        }

        public void AddTimeToll(City city, TimeSpan startTime, TimeSpan endTime, decimal tollAmount)
        {
            var timeToll = new TimeToll(city, startTime, endTime, tollAmount);
            TimeTolls.Add(timeToll);
        }

    }
}
