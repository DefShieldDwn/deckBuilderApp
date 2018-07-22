using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckBuilder.DTO
{
    public class CardDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Hp { get; set; }
        public string Attack1 { get; set; }
        public string Attack2 { get; set; }
        public int? ElementId { get; set; }
        public bool IsActive { get; set; }
    }
}