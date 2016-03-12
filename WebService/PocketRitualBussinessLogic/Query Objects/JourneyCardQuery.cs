using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.API.Query_Objects
{
    public class JourneyCardQuery
    {
        public DateTime? Time { get; set; }
        public int? JourneyCardId { get; set; }
        public int? JourneyId { get; set; }
        public int? CardId { get; set; }
        public string Notes { get; set; }
    }
}