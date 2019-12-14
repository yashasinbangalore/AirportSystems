using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportServices.API.Domain.Models;
using AirportServices.API.Domain.Models.Config;
using AirportServices.API.Domain.Repositories;
using AirportServices.API.Persistence.Contexts;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IO;

namespace AirportServices.API.Persistence.Repositories
{
    public class BookingRepository : BaseRepository, IBookingRepository
    {
        private readonly IOptions<ConfigSettings> appSettings;
        public BookingRepository(AppDbContext context, IOptions<ConfigSettings> app) : base(context)
        { appSettings = app; }

        public async Task<IEnumerable<Booking>> ReadBookingsAsync()
        {
            IEnumerable<Booking> bookings;
            using (StreamReader sr = new StreamReader(appSettings.Value.BookingDataPath))
            {
                string json = await sr.ReadToEndAsync();
                bookings = JsonConvert.DeserializeObject<IEnumerable<Booking>>(json);
            };

            return bookings;
        }
    }
}
