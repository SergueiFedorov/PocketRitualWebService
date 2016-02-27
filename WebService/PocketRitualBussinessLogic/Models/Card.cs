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
        public int CardId { get; set; }
        public string Name { get; set; }
        public int CardCategoryId { get; set; }
        [ForeignKey("CardCategoryId")]
        public virtual CardCategory CardCategory { get; set; }
        public string Description { get; set; }
    }
}
