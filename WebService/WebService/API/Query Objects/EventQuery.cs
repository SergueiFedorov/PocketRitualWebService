using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.API.Query_Objects
{
    public class EventQuery
    {
        public DateTime? Time { get; set; }
        public int? EventID { get; set; }
        public int? ActionID { get; set; }
    }
}