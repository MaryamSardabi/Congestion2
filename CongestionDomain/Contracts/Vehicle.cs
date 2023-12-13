using CongestionDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionDomain.Contracts
{
    public abstract class Vehicle
    {
        public abstract int Id { get; protected set; }        
        public abstract CarType CarType { get; set; }

    }
}
