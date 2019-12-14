using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportServices.API.Domain.Models;

namespace AirportServices.API.Domain.Repositories
{
    public interface ISettingRepository
    {
        Task<IEnumerable<Airport>> GetAirportsAsync();
    }
}
