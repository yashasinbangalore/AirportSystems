using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportServices.API.Domain.Models;
using AirportServices.API.Domain.Repositories;
using AirportServices.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AirportServices.API.Persistence.Repositories
{
    public class SettingRepository : BaseRepository, ISettingRepository
    {
        public SettingRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Airport>> GetAirportsAsync()
        {
            return await _context.Airports.ToListAsync();
        }
    }
}
