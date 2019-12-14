
namespace AirportServices.API.Domain.Models
{
    public class Airport
    {
        public string AirportName { get; set; }
        public string RestrictedFlights { get; set; }
        public bool AllowChildUsePRS { get; set; }
    }
}
