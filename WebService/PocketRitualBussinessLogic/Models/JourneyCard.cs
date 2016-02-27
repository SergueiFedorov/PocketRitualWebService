using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketRitual.Models
{
    public class JourneyCard
    {
        [Key]
        public int JourneyCardId { get; set; }
        public int JourneyId { get; set; }
        [ForeignKey("JourneyId")]
        public virtual Journey Journey { get; set; }
        public int CardId { get; set; }
        [ForeignKey("CardId")]
        public virtual Card Card { get; set; }
        public DateTime Time { get; set; }
        public string Notes { get; set; }
    }
}
