using PocketRitual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebService.API.Query_Objects;


namespace WebService.API
{
    public class JourneyController : ApiController
    {
        IPocketRitualDbContext _context { get; }

        public JourneyController(IPocketRitualDbContext context)
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
        public IEnumerable<Journey> Get([FromBody] JourneyQuery query)
        {
            IQueryable<Journey> databaseQuery = _context.Journeys;

            if (query.JourneyId.HasValue)
            {
                databaseQuery = (IQueryable<Journey>) _context.JourneyService.GetJourneysById((int)query.JourneyId);
                //databaseQuery = databaseQuery.Where(x => x.JourneyId == query.JourneyId.Value);
            }

            else if (query.JourneyName != null && query.UserId.HasValue)
            {
                databaseQuery = (IQueryable<Journey>)_context.JourneyService.GetJourneysByName((int)query.UserId, query.JourneyName);
                //databaseQuery = databaseQuery.Where(x => x.Name == query.JourneyName);
            }

            else if (query.CreatedDate.HasValue && query.UserId.HasValue)
            {
                databaseQuery = (IQueryable<Journey>)_context.JourneyService.GetJourneysByDate((int)query.UserId, (System.DateTime)query.CreatedDate);
                
                //var creatDateValue = query.CreatedDate.Value;
                //databaseQuery = databaseQuery.Where(x => x.CreatedDate.Day == creatDateValue.Day && x.CreatedDate.Month == creatDateValue.Month && x.CreatedDate.Year == creatDateValue.Year);
            }

            return databaseQuery;
        }

        // POST api/<controller>
        public void Post([FromBody] Journey journey)
        {
            _context.Journeys.Add(journey);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] Journey value)
        {
            var result = _context.Journeys.SingleOrDefault(x => x.JourneyId == id);
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            result.Name = value.Name;
            result.UserId = value.UserId;

            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var toRemove = this.Get(new JourneyQuery() { JourneyId = id }).SingleOrDefault();

            if (toRemove == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Journeys.Remove(toRemove);
        }
    }
}