using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.API.Query_Objects
{
    public class CardActionQuery
    {
        //public DateTime? CreatedDate { get; set; }
        public int? CardActionID { get; set; }
        public int? CardID { get; set; }
        public int? ActionID { get; set; }
    }
}