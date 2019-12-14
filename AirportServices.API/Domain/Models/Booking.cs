using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportServices.API.Domain.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public string Airline { get; set; }
        public string Airport { get; set; }
        public string FightNo { get; set; }
        public IList<Passenger> Passengers { get; set; } = new List<Passenger>();
    }
}
