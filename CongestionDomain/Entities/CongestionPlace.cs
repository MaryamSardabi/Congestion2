namespace CongestionDomain.Entities
{
    public class CongestionPlace
    {
        public int Id { get; }
        public string Name { get; }
        public List<TollRegistration> TollRegistrations { get; private set; }


        protected CongestionPlace()
        {

        }
        public CongestionPlace(string name)
        {
            Name = name;
            TollRegistrations = new List<TollRegistration>();
        }
    }
}