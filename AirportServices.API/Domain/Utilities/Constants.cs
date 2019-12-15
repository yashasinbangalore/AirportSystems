using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportServices.API.Domain.Utilities
{
    public static class Constants
    {
        public static string RESULT_SUCCESS = "Success";
        public static string RESULT_WARNING = "Warning";
        public static string RESULT_ERROR = "Error";
        public static string MSG_SUCCESS = "This passenger is good to go.";
        public static string MSG_WARNING = "This passenger needs to be companied with adult.";
        public static string MSG_ERROR_GENERAL = "Something went wrong! Please contact the administrator.";
        public static string MSG_ERROR_WRONGAIRPORT = "The airport of the current booking does not match the current airport.";
        public static string MSG_ERROR_PASSENGER = "No booking found for the passenger name.";
        public static string TYPE_INFANT = "Infant";
        public static string TYPE_CHILD = "Child";
    }
}
