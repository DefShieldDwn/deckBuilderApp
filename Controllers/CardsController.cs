using DeckBuilder.DTO;
using DeckBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeckBuilder.Controllers
{
    [RoutePrefix("api/Cards")]
    public class CardsController : ApiController
    {
        private DeckBuilderContext database = new DeckBuilderContext();

        [Route("AllCards")]
        public IHttpActionResult GetAllCards()
        {
            var result = database.Cards.Where(x => x.IsActive == true).ToList();
            return Ok(result);
        }

        [Route("Card")]
        public IHttpActionResult GetCardById(int cardId)
        {
            var result = database.Cards.SingleOrDefault(x => x.Id == cardId);
            return Ok(result);
        }

        [Route("Delete")]
        public IHttpActionResult PostDeleteCardById(int cardId)
        {
            var card = database.Cards.SingleOrDefault(x => x.Id == cardId);
            //database.Cards.Remove(card); //HARD DELETE
            card.IsActive = false; //SOFT DELETE
            database.SaveChanges();
            return Ok();
        }

        [Route("SaveCard")]
        public IHttpActionResult PostSaveCard([FromBody]CardDTO card)
        {

            if (card.Id == 0)
            {
                //when the front-end sends no new ID, this creates a new card
                var newCard = new Card();
                newCard.Id = card.Id;
                newCard.Name = card.Name;
                newCard.Hp = card.Hp;
                newCard.Attack1 = card.Attack1;
                newCard.Attack2 = card.Attack2;
                newCard.ElementId = card.ElementId;
                newCard.IsActive = card.IsActive;
                database.Cards.Add(newCard);
            }
            else
            {
                //when the front-end sends an ID, this section is updatng an old card
                var existingCard = database.Cards.SingleOrDefault(x => x.Id == card.Id);
                existingCard.Id = card.Id;
                existingCard.Name = card.Name;
                existingCard.Hp = card.Hp;
                existingCard.Attack1 = card.Attack1;
                existingCard.Attack2 = card.Attack2;
                existingCard.ElementId = card.ElementId;
                existingCard.IsActive = card.IsActive;
            }

            database.SaveChanges();
            return Ok();
        }

        [Route("SearchCards")]
        public IHttpActionResult GetCardBySearchTerm(string searchTerm)
        {
            var result = database.Cards.Where(x => x.Name.Contains(searchTerm)
                    || x.Attack1.Contains(searchTerm)
                    || x.Attack2.Contains(searchTerm)
                    || x.Element.Value.Contains(searchTerm))
                    .ToList();
            return Ok(result);
        }

        //[Route("AddCard")]
        //public IHttpActionResult PostAddCard()
        //{

        //}
    }
}

