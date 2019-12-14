using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportServices.API.Domain.Models;
using AirportServices.API.Domain.Utilities;
using AirportServices.API.Domain.Repositories;
using AirportServices.API.Domain.Services;

namespace AirportServices.API.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ISettingRepository _settingRepository;

        public BookingService(IBookingRepository bookingRepository, ISettingRepository settingRepository)
        {
            _bookingRepository = bookingRepository;
            _settingRepository = settingRepository;
        }
        public async Task<IEnumerable<Booking>> SearchAsync(string name)
        {
            var airportSettings = await _settingRepository.GetAirportsAsync();
            IEnumerable<Booking> bookings = await _bookingRepository.ReadBookingsAsync();
            if (bookings != null)
            {
                var restrictedBookingIDs = from bok in bookings
                                           join aps in airportSettings on
                                            new { A = bok.Airport, B = bok.FightNo } equals
                                            new { A = aps.AirportName, B = aps.RestrictedFlights }
                                           select bok.BookingID;

                //Filter out restricted flights
                if (restrictedBookingIDs.Any())
                {
                    bookings = bookings.Where(b => !restrictedBookingIDs.Contains(b.BookingID));
                }

                //Filter by name on non-restricted flight bookings.
                if (!string.IsNullOrWhiteSpace(name))
                    bookings = bookings.Where(b => b.Passengers.Contains(new Passenger { Name = name }, new PassengerComparer()));
            }
            else
                bookings = new List<Booking>();
            return bookings;
        }
    }
}
