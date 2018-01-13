using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoradoK_A2.Models
{
    public static class Repository
    {
        private static List<GuestResponse> _reponses = new List<GuestResponse>();

        public static IEnumerable<GuestResponse> Responses
        {
            get
            {
                return _reponses;
            }
        }

        public static void AddResponse(GuestResponse response)
        {
            _reponses.Add(response);
        }

    }
}
