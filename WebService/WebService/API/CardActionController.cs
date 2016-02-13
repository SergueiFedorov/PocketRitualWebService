using PocketRitual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebService.API.Query_Objects;

namespace WebService.API
{
    public class CardActionController
    {
        IPocketRitualDbContext _context { get; }

        public CardActionController(IPocketRitualDbContext context)
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
        public IEnumerable<CardAction> Get([FromBody] CardActionQuery query)
        {
            IQueryable<CardAction> databaseQuery = _context.CardActions;

            if (query.CardActionID.HasValue)
            {
                databaseQuery = databaseQuery.Where(x => x.CardActionID == query.CardActionID.Value);
            }

            if (query.CardID.HasValue)
            {
                databaseQuery = databaseQuery.Where(x => x.CardID == query.CardID);
            }

            if (query.ActionID.HasValue)
            {
                databaseQuery = databaseQuery.Where(x => x.ActionID == query.ActionID);
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
        public void Post([FromBody] CardAction CardAction)
        {
            _context.CardActions.Add(CardAction);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] CardAction value)
        {
            var result = _context.CardActions.SingleOrDefault(x => x.CardActionID == id);
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
            result.CardID = value.CardID;
            result.ActionID = value.ActionID;
            
            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var toRemove = this.Get(new CardActionQuery() { CardActionID = id }).SingleOrDefault();

            if (toRemove == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.CardActions.Remove(toRemove);
        }

    }
}