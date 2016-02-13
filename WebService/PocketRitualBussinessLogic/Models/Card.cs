using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketRitual.Models
{
    public class Card
    {
        [Key]
        public int CardID { get; set; }
        public string Name { get; set; }
        public int CardCategoryID { get; set; }
        [ForeignKey("CardCategoryID")]
        public virtual CardCategory CardCategory { get; set; }
        public string Description { get; set; }
    }
}
