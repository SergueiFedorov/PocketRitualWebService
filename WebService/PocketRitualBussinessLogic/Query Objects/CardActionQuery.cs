using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.API.Query_Objects
{
    public class CardActionQuery
    {
        //public DateTime? CreatedDate { get; set; }
        public int? CardActionId { get; set; }
        public int? CardId { get; set; }
        public int? ActionId { get; set; }
    }
}