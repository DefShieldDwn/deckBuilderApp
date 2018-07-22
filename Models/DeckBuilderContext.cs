using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeckBuilder.Models
{
    public class DeckBuilderContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DeckBuilderContext() : base("name=DeckBuilderConnectionString")
        {
            Database.SetInitializer<DeckBuilderContext>(null);
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Deck> Decks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet <Element> Elements { get; set; }
        public DbSet <DeckCard> DeckCards { get; set; }


    }
}
