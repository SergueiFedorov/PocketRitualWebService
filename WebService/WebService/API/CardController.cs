using PocketRitual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebService.API.Query_Objects;

namespace WebService.API
{
    public class CardController
    {
        IPocketRitualDbContext _context { get; }

        public CardController(IPocketRitualDbContext context)
        {
            if (context == null)
            {
                throw new System.Exception("");
            }

            this._context = context;
        }

        private DateTime TrimDateTime(DateTime input)
        {
            return new DateTime(input.Year, input.Month, input.Day);
        }

        // GET api/<controller>
        public IEnumerable<Card> Get([FromBody] CardQuery query)
        {
            IQueryable<Card> databaseQuery = _context.Cards;

            if (query.CardId.HasValue)
            {
                databaseQuery = databaseQuery.Where(x => x.CardID == query.CardId.Value);
            }

            if (query.Name != null)
            {
                databaseQuery = databaseQuery.Where(x => x.Name == query.Name);
            }

            /*
            if (query.CreatedDate.HasValue)
            {
                //Don't compare time portion
                var creatDateValue = query.CreatedDate.Value;
                databaseQuery = databaseQuery.Where(x => x.CreateDate.Day == creatDateValue.Day && x.CreateDate.Month == creatDateValue.Month && x.CreateDate.Year == creatDateValue.Year);
            }
            */

            return databaseQuery;
        }

        // POST api/<controller>
        public void Post([FromBody] Card Card)
        {
            _context.Cards.Add(Card);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] Card value)
        {
            var result = _context.Cards.SingleOrDefault(x => x.CardID == id);
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            result.Name = value.Name;
            result.CardID = value.CardID;

            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var toRemove = this.Get(new CardQuery() { CardId = id }).SingleOrDefault();

            if (toRemove == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Cards.Remove(toRemove);
        }

    }
}