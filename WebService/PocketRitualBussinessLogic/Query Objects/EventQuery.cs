using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.API.Query_Objects
{
    public class EventQuery
    {
        public DateTime? Time { get; set; }
        public int? EventId { get; set; }
        public int? ActionId { get; set; }
    }
}