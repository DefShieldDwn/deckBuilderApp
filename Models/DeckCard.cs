using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeckBuilder.Models
{
    public class DeckCard
    {
        public int Id { get; set; }
        public int DeckId { get; set; }
        public int CardId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("DeckId")]
        public virtual Deck Deck { get; set; }

        [ForeignKey("CardId")]
        public virtual Card Card { get; set; }
    }
}