using PocketRitual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebService.API.Query_Objects;


namespace WebService.API
{
    public class ActionController : ApiController
    {
        IPocketRitualDbContext _context { get; }

        public ActionController(IPocketRitualDbContext context)
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
        public IEnumerable<PocketRitual.Models.Action> Get([FromBody] ActionQuery query)
        {
            IQueryable<PocketRitual.Models.Action> databaseQuery = _context.Actions;

            if (query.ActionId.HasValue)
            {
                databaseQuery = (IQueryable<PocketRitual.Models.Action>)_context.ActionService.GetActionsById((int)query.ActionId);
                    //databaseQuery.Where(x => x.ActionId == query.ActionId.Value);
            }

            if (query.ActionCategoryId.HasValue)
            {
                databaseQuery = (IQueryable<PocketRitual.Models.Action>)_context.ActionService.GetActionsByCategoryId((int)query.ActionCategoryId);
            }

            if (query.ActionName != null)
            {
                databaseQuery = databaseQuery.Where(x => x.Name == query.ActionName);
            }

            /*
            if (query.CreatedDate.HasValue)
            {
                //Don't compare time portion
                var creatDateValue = query.CreatedDate.Value;
                databaseQuery = databaseQuery.Where(x => x.CreatedDate.Day == creatDateValue.Day && x.CreatedDate.Month == creatDateValue.Month && x.CreatedDate.Year == creatDateValue.Year);
            }
             */

            return databaseQuery;
        }

        // POST api/<controller>
        public void Post([FromBody] PocketRitual.Models.Action journey)
        {
            _context.Actions.Add(journey);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] PocketRitual.Models.Action value)
        {
            var result = _context.Actions.SingleOrDefault(x => x.ActionId == id);
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            result.ActionCategoryId = value.ActionCategoryId;
            result.Name = value.Name;
            result.Desc = value.Desc;

            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var toRemove = this.Get(new ActionQuery() { ActionId = id }).SingleOrDefault();

            if (toRemove == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Actions.Remove(toRemove);
        }
    }
}