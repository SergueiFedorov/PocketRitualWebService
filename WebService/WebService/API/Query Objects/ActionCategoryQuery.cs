using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.API.Query_Objects
{
    public class ActionCategoryQuery
    {
        //public DateTime? CreatedDate { get; set; }
        public int? ActionCategoryId { get; set; }
        public string ActionCategoryName { get; set; }
        public string Desc { get; set; }
    }
}