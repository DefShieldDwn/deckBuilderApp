using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeckBuilder.Models
{
    public class Deck
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? UserId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}