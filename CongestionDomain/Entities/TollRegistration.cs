namespace CongestionDomain.Entities
{
    public class TollRegistration
    {
        protected TollRegistration()
        {

        }

        public TollRegistration(Car car, TimeToll timeToll, CongestionPlace congestionPlace, Calender calender, decimal totalTollAmount, decimal paidTollAmount, DateTime registrationDateTime)
        {
            Car = car;
            TimeToll = timeToll;
            CongestionPlace = congestionPlace;
            Calender = calender;
            TotalTollAmount = totalTollAmount;
            PaidTollAmount = paidTollAmount;
            RegistrationDateTime = registrationDateTime;
        }


        public int Id { get; private set; }
        public decimal TotalTollAmount { get; private set; }
        public decimal PaidTollAmount { get; private set; }
        public DateTime RegistrationDateTime { get; private set; }

        public int CarId { get; private set; }
        public Car Car { get; private set; }



        public int TimeTollId { get; private set; }
        public TimeToll TimeToll { get; private set; }

        public int CongestionPlaceId { get; private set; }
        public CongestionPlace CongestionPlace { get; private set; }

        public int CalenderId { get; private set; }
        public Calender Calender { get; private set; }
    }

}
