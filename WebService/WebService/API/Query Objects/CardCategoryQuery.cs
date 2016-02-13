using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.API.Query_Objects
{
    public class CardCategoryQuery
    {
        //public DateTime? CreatedDate { get; set; }
        public int? CardCategoryID { get; set; }
        public string CardCategoryName { get; set; }
        public string Desc { get; set; }
    }
}