using CongestionDomain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace CongestionDomain.Entities
{
    public class TollRegistration
    {
        public int Id { get; private set; }
        public int VehicleId { get; private set; }

        [NotMapped]
        public Vehicle Vehicle { get; private set; }
        public int TimeTollId { get; private set; }
        public TimeToll TimeToll { get; private set; }
        public int CongestionPlaceId { get;private set; }
        public CongestionPlace CongestionPlace { get; private set; }
        public int CalenderId { get;private set; }
        public Calender Calender { get; private set; }
        public decimal TotalTollAmount { get; private set; }
        public decimal PaidTollAmount { get; private set; }
        protected TollRegistration()
        {

        }

        public TollRegistration(Vehicle vehicle, TimeToll timeToll, CongestionPlace congestionPlace, Calender calender, decimal totalTollAmount, decimal paidTollAmount)
        {
            Vehicle = vehicle;
            TimeToll = timeToll;
            CongestionPlace = congestionPlace;
            Calender = calender;
            TotalTollAmount = totalTollAmount;
            PaidTollAmount = paidTollAmount;
        }
    }

}
