using CongestionDomain.Contracts;

namespace CongestionDomain.Entities
{
    public class Car : Vehicle
    {
        public override int Id { get; protected set; }
        public  string Tag { get; private set; }
        public override string Name { get; protected set; }
        public override bool IsTollIncluded { get; protected set; }

        public List<TollRegistration> TollRegistrations { get; private set; }

        protected Car() { }


        public Car(string tag, string name, bool isTollIncluded)
        {
            Tag = tag;
            Name = name;
            IsTollIncluded = isTollIncluded;
            TollRegistrations = new List<TollRegistration>();
        }

    }
}
