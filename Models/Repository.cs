using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class Repository // This will be used to store the responses given on whom will be attending.
    {
        /* The repository class and its members are set to static, which will make it 
         * easy to store and retrieve data from different places in the application. */
        private static List<Guest_Response> responses = new List<Guest_Response>();
        public static IEnumerable<Guest_Response> Responses
        {
            get
            {
                return responses;
            }
        }
        public static void AddResponse(Guest_Response response)
        {
            responses.Add(response);
        }
        
    }
}
