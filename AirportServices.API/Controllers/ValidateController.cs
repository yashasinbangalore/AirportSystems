using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirportServices.API.Domain.Services;
using AirportServices.API.Domain.Models;

namespace AirportServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        private readonly IValidateService _validateService;

        public ValidateController(IValidateService validateService)
        {
            _validateService = validateService;
        }

        [HttpPost]
        public async Task<ValidationResponse> ValidateAsync(ValidationRequest request)
        {
            var result = await _validateService.ValidateAsync(request);
            return result;
        }
    }
}