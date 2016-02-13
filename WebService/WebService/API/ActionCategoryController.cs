using PocketRitual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebService.API.Query_Objects;


namespace WebService.API
{
    public class ActionCategoryController : ApiController
    {
        IPocketRitualDbContext _context { get; }

        public ActionCategoryController(IPocketRitualDbContext context)
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
        public IEnumerable<ActionCategory> Get([FromBody] ActionCategoryQuery query)
        {
            IQueryable<ActionCategory> databaseQuery = _context.ActionCategories;

            if (query.ActionCategoryID.HasValue)
            {
                databaseQuery = databaseQuery.Where(x => x.ActionCategoryID == query.ActionCategoryID.Value);
            }

            if (query.ActionCategoryName != null)
            {
                databaseQuery = databaseQuery.Where(x => x.Name == query.ActionCategoryName);
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
        public void Post([FromBody] ActionCategory journey)
        {
            _context.ActionCategories.Add(journey);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] ActionCategory value)
        {
            var result = _context.ActionCategories.SingleOrDefault(x => x.ActionCategoryID == id);
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            result.Name = value.Name;
            result.Desc = value.Desc;

            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var toRemove = this.Get(new ActionCategoryQuery() { ActionCategoryID = id }).SingleOrDefault();

            if (toRemove == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.ActionCategories.Remove(toRemove);
        }
    }
}