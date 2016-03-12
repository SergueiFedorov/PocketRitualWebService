using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.API.Query_Objects
{
    public class CardQuery
    {
        //public DateTime? CreatedDate { get; set; }
        public int? CardId { get; set; }
        public string Name { get; set; }
    }
}