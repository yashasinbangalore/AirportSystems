using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportServices.API.Domain.Models;

namespace AirportServices.API.Domain.Utilities
{
    public class PassengerComparer : IEqualityComparer<Passenger>
    {

        public bool Equals(Passenger x, Passenger y)
        {
            return (x.Name.IsNameMatch(y.Name));
        }

        public int GetHashCode(Passenger obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
