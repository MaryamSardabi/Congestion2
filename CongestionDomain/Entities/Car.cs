namespace CongestionDomain.Entities
{
    public class Car
    {
        public int Id { get; protected set; }
        public string Tag { get; private set; }
        public CarType CarType { get; set; }
        public List<TollRegistration> TollRegistrations { get; private set; }

        protected Car() { }

        public Car(string tag, CarType carType)
        {
            Tag = tag;
            CarType = carType;
        }

    }
}
