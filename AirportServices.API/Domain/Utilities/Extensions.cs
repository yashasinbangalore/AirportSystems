using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportServices.API.Domain.Utilities
{
    public static class Extensions
    {
        public static bool IsNameMatch(this string passengerA, string passengerB)
        {
            int matchCount = 0;
            string[] nameA = passengerA.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] nameB = passengerB.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (nameA.Any() && nameB.Any())
            {
                foreach(string word in nameA)
                {
                    foreach(string srchWord in nameB)
                    {
                        if(word.Length > 2 && srchWord.Length > 2 
                            && word.ToLower().Contains(srchWord.ToLower()))
                        {
                            matchCount++;
                        }
                    }
                }
                if (nameA.Length == matchCount || (nameA.Length > matchCount && matchCount == nameB.Length))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}
