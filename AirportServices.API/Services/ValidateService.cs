using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportServices.API.Domain.Repositories;
using AirportServices.API.Domain.Models;
using AirportServices.API.Domain.Services;
using AirportServices.API.Domain.Utilities;

namespace AirportServices.API.Services
{
    public class ValidateService : IValidateService
    {
        private readonly IBookingService _bookingService;
        private readonly ISettingRepository _settingRepository;

        public ValidateService(IBookingService bookingService, ISettingRepository settingRepository)
        {
            _bookingService = bookingService;
            _settingRepository = settingRepository;
        }
        public async Task<ValidationResponse> ValidateAsync(ValidationRequest request)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(request.PassengerName) &&
                    !string.IsNullOrWhiteSpace(request.Airport))
                {
                    var bookings = await _bookingService.SearchAsync(request.PassengerName);
                    if (!bookings.Any())
                        return new ValidationResponse { Result = Constants.RESULT_ERROR, Message = Constants.MSG_ERROR_PASSENGER };
                    else if (!bookings.Any(b => b.Airport.ToLower().Equals(request.Airport.ToLower())))
                        return new ValidationResponse { Result = Constants.RESULT_ERROR, Message = Constants.MSG_ERROR_WRONGAIRPORT };
                    else
                    {
                        var booking = bookings.Where(b => b.Airport.ToLower().Equals(request.Airport.ToLower())).FirstOrDefault();
                        var passenger = booking.Passengers.Where(p => p.Name.IsNameMatch(request.PassengerName)).FirstOrDefault();
                        if (passenger != null && passenger.Type.Equals(Constants.TYPE_INFANT))
                            return new ValidationResponse { Result = Constants.RESULT_WARNING, Message = Constants.MSG_WARNING };
                        else if (passenger != null && passenger.Type.Equals(Constants.TYPE_CHILD))
                        {
                            var airportSettings = await _settingRepository.GetAirportsAsync();
                            var airport = airportSettings.Where(a => a.AirportName.ToLower().Equals(request.Airport.ToLower())).FirstOrDefault();
                            if (airport == null)
                                return new ValidationResponse { Result = Constants.RESULT_ERROR, Message = Constants.MSG_ERROR_WRONGAIRPORT };
                            else if (!airport.AllowChildUsePRS)
                                return new ValidationResponse { Result = Constants.RESULT_WARNING, Message = Constants.MSG_WARNING };
                            else
                                return new ValidationResponse { Result = Constants.RESULT_SUCCESS, Message = Constants.MSG_SUCCESS };
                        }
                        else
                            return new ValidationResponse { Result = Constants.RESULT_SUCCESS, Message = Constants.MSG_SUCCESS };
                    }
                }
                else
                {
                    if(string.IsNullOrWhiteSpace(request.PassengerName))
                        return new ValidationResponse { Result = Constants.RESULT_ERROR, Message = Constants.MSG_ERROR_PASSENGER };
                    else
                        return new ValidationResponse { Result = Constants.RESULT_ERROR, Message = Constants.MSG_ERROR_WRONGAIRPORT };
                }
            }
            catch(Exception ex)
            {
                return new ValidationResponse { Result = Constants.RESULT_ERROR, Message = Constants.MSG_ERROR_GENERAL };
            }
        }
        
    }
}
