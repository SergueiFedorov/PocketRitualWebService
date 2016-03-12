using PocketRitual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebService.API.Query_Objects;

namespace WebService.API
{
    public class EventController
    {
        IPocketRitualDbContext _context { get; }

        public EventController(IPocketRitualDbContext context)
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
        public IEnumerable<Event> Get([FromBody] EventQuery query)
        {
            IQueryable<Event> databaseQuery = _context.Events;

            if (query.EventId.HasValue)
            {
                databaseQuery = (IQueryable<Event>)_context.EventService.GetEventsById((int)query.EventId); 
                    //databaseQuery.Where(x => x.EventId == query.EventId.Value);
            }

            if (query.ActionId.HasValue)
            {
                databaseQuery = (IQueryable<Event>)_context.EventService.GetEventsByActionId((int)query.ActionId);
                    //databaseQuery.Where(x => x.ActionId == query.ActionId);
            }

            if (query.Time.HasValue)
            {
                databaseQuery = (IQueryable<Event>)_context.EventService.GetEventsByTime((DateTime) query.Time);

                //var timeValue = query.Time.Value;
                //databaseQuery = databaseQuery.Where(x => x.Time.Day == timeValue.Day && x.Time.Month == timeValue.Month && x.Time.Year == timeValue.Year);
            }
            

            return databaseQuery;
        }

        // POST api/<controller>
        public void Post([FromBody] Event Event)
        {
            _context.Events.Add(Event);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] Event value)
        {
            var result = _context.Events.SingleOrDefault(x => x.EventId == id);
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            result.ActionId = value.ActionId;
            result.Time = value.Time; //TODO: Double check this. Do we want to refresh the time to current time?

            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var toRemove = this.Get(new EventQuery() { EventId = id }).SingleOrDefault();

            if (toRemove == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Events.Remove(toRemove);
        }

    }
}