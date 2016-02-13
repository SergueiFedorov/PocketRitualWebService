using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketRitual.Models
{
    public class Action
    {
        [Key]
        public int ActionID { get; set; }
        public int ActionCategoryID { get; set; }
        [ForeignKey("ActionCategoryID")]
        public virtual ActionCategory ActionCategory { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}
