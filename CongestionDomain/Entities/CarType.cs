using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionDomain.Entities
{
    public class CarType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsTollFree { get; set; }

        public CarType(string name, bool isTollFree)
        {
            Name = name;
            IsTollFree = isTollFree;
        }
    }
}
