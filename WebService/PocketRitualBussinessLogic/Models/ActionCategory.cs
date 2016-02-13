using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketRitual.Models
{
    public class ActionCategory
    {
        [Key]
        public int ActionCategoryID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}
