using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.API.Query_Objects
{
    public class JourneyQuery
    {
        public DateTime? CreatedDate { get; set; }
        public int? JourneyId { get; set; }
        public string JourneyName { get; set; }
        public int? UserId { get; set; }
    }
}