using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirportServices.API.Domain.Models;
using AirportServices.API.Domain.Services;

namespace AirportServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("{name}")]
        public async Task<IEnumerable<Booking>> SearchAsync(string name)
        {
            var bookings = await _bookingService.SearchAsync(name);
            return bookings;
        }
    }
}