using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeckBuilder.Models
{
    public class Element
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
    }
}