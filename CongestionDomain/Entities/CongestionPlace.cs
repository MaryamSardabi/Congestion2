namespace CongestionDomain.Entities
{
    public class CongestionPlace
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<TollRegistration> TollRegistrations { get; private set; }
        public City City { get; set; }
        public int CityId { get; set; }


        protected CongestionPlace()
        {
        }
        public CongestionPlace(string name, City city)
        {
            Name = name;
            TollRegistrations = new List<TollRegistration>();
            City = city;
        }
    }
}