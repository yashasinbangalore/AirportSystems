using System.Collections.Generic;
using System.Threading.Tasks;
using AirportServices.API.Domain.Models;

namespace AirportServices.API.Domain.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> SearchAsync(string name);
    }
}
