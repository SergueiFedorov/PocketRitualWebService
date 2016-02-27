using PocketRitual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebService.API.Query_Objects;

namespace WebService.API
{
    public class JourneyCardController
    {
        IPocketRitualDbContext _context { get; }

        public JourneyCardController(IPocketRitualDbContext context)
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
        public IEnumerable<JourneyCard> Get([FromBody] JourneyCardQuery query)
        {
            IQueryable<JourneyCard> databaseQuery = _context.JourneyCards;

            if (query.JourneyCardId.HasValue)
            {
                databaseQuery = databaseQuery.Where(x => x.JourneyCardId == query.JourneyCardId.Value);
            }

            if (query.JourneyId.HasValue)
            {
                databaseQuery = databaseQuery.Where(x => x.JourneyId == query.JourneyId);
            }

            if (query.CardId.HasValue)
            {
                databaseQuery = databaseQuery.Where(x => x.CardId == query.CardId);
            }

            if (query.Time.HasValue)
            {
                //Don't compare time portion
                var timeValue = query.Time.Value;
                databaseQuery = databaseQuery.Where(x => x.Time.Day == timeValue.Day && x.Time.Month == timeValue.Month && x.Time.Year == timeValue.Year);
            }


            return databaseQuery;
        }

        // POST api/<controller>
        public void Post([FromBody] JourneyCard JourneyCard)
        {
            _context.JourneyCards.Add(JourneyCard);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] JourneyCard value)
        {
            var result = _context.JourneyCards.SingleOrDefault(x => x.JourneyCardId == id);
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            result.JourneyId = value.JourneyId;
            result.CardId = value.CardId;
            result.Notes = value.Notes;
            result.Time = value.Time; //TODO: Double check this. Do we want to refresh the time to current time?

            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var toRemove = this.Get(new JourneyCardQuery() { JourneyCardId = id }).SingleOrDefault();

            if (toRemove == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.JourneyCards.Remove(toRemove);
        }

    }
}