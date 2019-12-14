using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportServices.API.Domain.Models;

namespace AirportServices.API.Domain.Services
{
    public interface IValidateService
    {
        Task<ValidationResponse> ValidateAsync(ValidationRequest request);
    }
}
