using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketRitual.Models
{
    public class CardAction
    {
        [Key]
        public int CardActionID { get; set; }
        public int CardID { get; set; }
        [ForeignKey("CardID")]
        public virtual Card Card { get; set; }
        public int ActionID { get; set; }
        [ForeignKey("ActionID")]
        public virtual Action Action { get; set; }

    }
}
