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

            if (query.CardActionId.HasValue)
            {
                databaseQuery = (IQueryable<CardAction>)_context.CardActionService.GetCardActionsById((int)query.CardActionId);
                //databaseQuery.Where(x => x.CardActionId == query.CardActionId.Value);
            }

            if (query.CardId.HasValue)
            {
                databaseQuery = (IQueryable<CardAction>)_context.CardActionService.GetCardActionsByCardId((int)query.CardId); 
                    //databaseQuery.Where(x => x.CardId == query.CardId);
            }

            if (query.ActionId.HasValue)
            {
                databaseQuery = (IQueryable<CardAction>)_context.CardActionService.GetCardActionsByActionId((int)query.ActionId); 
                    //databaseQuery.Where(x => x.ActionId == query.ActionId);
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
            var result = _context.CardActions.SingleOrDefault(x => x.CardActionId == id);
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
            result.CardId = value.CardId;
            result.ActionId = value.ActionId;
            
            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var toRemove = this.Get(new CardActionQuery() { CardActionId = id }).SingleOrDefault();

            if (toRemove == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.CardActions.Remove(toRemove);
        }

    }
}