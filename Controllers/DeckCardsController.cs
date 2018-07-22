using DeckBuilder.DTO;
using DeckBuilder.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeckBuilder.Controllers
{
    [RoutePrefix("api/DeckCards")]
    public class DeckCardsController : ApiController
    {
        private DeckBuilderContext database = new DeckBuilderContext();

        [Route("ListCards")]
        public IHttpActionResult GetCardsByDeckId(int deckId)
        {
            var result = database.DeckCards
            .Include(z => z.Card)
            .Include(z => z.Card.Element)
            .Where(x => x.DeckId == deckId).ToList()
            .Select(y => y.Card);
            return Ok(result);
        }

        [Route("AddCard")]
        public IHttpActionResult AddCardToDeck(int deckId, int cardId)
        {
            var deckCard = new DeckCard();
            deckCard.DeckId = deckId;
            deckCard.CardId = cardId;
            database.DeckCards.Add(deckCard);
            database.SaveChanges();
            return Ok();
        }

        [Route("RemoveCard")]
        public IHttpActionResult RemoveCardFromDeck(int deckId, int cardId)
        {
            var card = database.DeckCards.SingleOrDefault(x => x.DeckId == deckId && x.CardId == cardId);
            database.DeckCards.Remove(card);
            database.SaveChanges();
            return Ok();
        }
    }
}