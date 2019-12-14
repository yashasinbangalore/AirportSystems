using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportServices.API.Domain.Utilities
{
    public static class Constants
    {
        public static int RESULT_SUCCESS = 1;
        public static int RESULT_WARNING = 2;
        public static int RESULT_ERROR = 3;
        public static string MSG_WARNING = "This passenger needs to be companied with adult.";
        public static string MSG_ERROR_WRONGAIRPORT = "The airport of the current booking does not match the current airport.";
        public static string MSG_ERROR_PASSENGER = "No booking found for the passenger name.";
        public static string TYPE_INFANT = "Infant";
        public static string TYPE_CHILD = "Child";
    }
}
