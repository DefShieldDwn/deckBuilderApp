using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DeckBuilder.DTO;
using DeckBuilder.Models;

namespace DeckBuilder.Controllers
{
    [RoutePrefix("api/Decks")]
    public class DecksController : ApiController
    {
        private DeckBuilderContext database;

        [Route("AllDecks")]
        public IHttpActionResult GetAllDecks()
        {
            var result = database.Decks.Where(x => x.IsActive == true).ToList();
            return Ok(result);
        }

        [Route("Deck")]
        public IHttpActionResult GetDeckById(int deckId)
        {
            var result = database.Decks.SingleOrDefault(x => x.Id == deckId);
            return Ok()
        }

        [Route("Delete")]
        public IHttpActionResult PostDeleteDeckById(int deckId)
        {
            var deck = database.Decks.SingleOrDefault(x => x.Id == deckId;
            //database.Decks.Remove(deck); HARD DELETE
            deck.IsActive = false;
            database.SaveChanges();
            return Ok();
        }

        [Route("SaveDeck")]
        public IHttpActionResult PostSaveDeck([FromBody]DeckDTO deck )
        {
            
            if(deck.Id == 0)
            {

                //when the front-end sends no new ID, this creates a new deck
                var newDeck = new Deck();
                newDeck.Id = deck.Id;
                newDeck.Name = deck.Name;
                newDeck.IsActive = deck.IsActive;
                newDeck.UserId = deck.UserId;
                database.Decks.Add(newDeck);
            }
            else
            {

                //when the front-end sends an ID, this one is updatng an old deck
                var existingDeck = database.Decks.SingleOrDefault(x => x.Id == deck.Id);
                existingDeck.Name = deck.Name;
                existingDeck.IsActive = deck.IsActive;
                existingDeck.UserId = deck.UserId;
            }

            database.SaveChanges();
            return Ok();
        }

        //[Route("AddDeck")]
        //public IHttpActionResult PostAddDeck()
        //{

        //}
    }
}