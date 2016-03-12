using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.API.Query_Objects
{
    public class ActionQuery
    {
        //public DateTime? CreatedDate { get; set; }
        public int? ActionId { get; set; }
        public int? ActionCategoryId { get; set; }
        public string ActionName { get; set; }
        public string Desc { get; set; }
    }
}