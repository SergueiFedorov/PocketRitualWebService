using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketRitual.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public int ActionId { get; set; }
        [ForeignKey("ActionId")]
        public virtual Action Action { get; set; }
        public DateTime Time { get; set; }
    }
}
