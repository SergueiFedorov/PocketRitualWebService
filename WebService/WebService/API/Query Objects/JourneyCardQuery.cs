using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.API.Query_Objects
{
    public class JourneyCardQuery
    {
        public DateTime? Time { get; set; }
        public int? JourneyCardID { get; set; }
        public int? JourneyID { get; set; }
        public int? CardID { get; set; }
        public string Notes { get; set; }
    }
}