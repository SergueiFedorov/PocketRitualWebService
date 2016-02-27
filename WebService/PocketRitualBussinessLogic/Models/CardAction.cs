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
        public int CardActionId { get; set; }
        public int CardId { get; set; }
        [ForeignKey("CardId")]
        public virtual Card Card { get; set; }
        public int ActionId { get; set; }
        [ForeignKey("ActionId")]
        public virtual Action Action { get; set; }

    }
}
