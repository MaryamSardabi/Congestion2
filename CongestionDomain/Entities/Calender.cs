using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionDomain.Entities
{
    public class Calender
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsHoliday { get; set; }
        public bool IsTollFree { get; set; }
        public List<TollRegistration> TollRegistrations { get;  set; }


        public void MakeDayTollExempt()
        {
            IsTollFree = true;
            TollRegistrations = new List<TollRegistration>();
        }


    }
}
