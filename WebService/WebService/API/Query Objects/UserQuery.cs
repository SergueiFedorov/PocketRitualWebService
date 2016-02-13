using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.API.Query_Objects
{
    public class UserQuery
    {
        public DateTime? CreatedDate { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; }
    }
}