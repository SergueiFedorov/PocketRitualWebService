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
        public int JourneyCardID { get; set; }
        public int JourneyID { get; set; }
        [ForeignKey("JourneyID")]
        public virtual Journey Journey { get; set; }
        public int CardID { get; set; }
        [ForeignKey("CardID")]
        public virtual Card Card { get; set; }
        public DateTime Time { get; set; }
        public string Notes { get; set; }
    }
}
