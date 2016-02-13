using PocketRitual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebService.API.Query_Objects;


namespace WebService.API
{
    public class UserController : ApiController
    {
        IPocketRitualDbContext _context { get; }

        public UserController(IPocketRitualDbContext context)
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
        public IEnumerable<User> Get([FromBody] UserQuery query)
        {
            IQueryable<User> databaseQuery = _context.Users;

            if (query.UserId.HasValue)
            {
                databaseQuery = databaseQuery.Where(x => x.UserId == query.UserId.Value);
            }

            if (query.Email != null)
            {
                databaseQuery = databaseQuery.Where(x => x.Email == query.Email);
            }

            if (query.CreatedDate.HasValue)
            {
                //Don't compare time portion
                var creatDateValue = query.CreatedDate.Value;
                databaseQuery = databaseQuery.Where(x => x.CreatedDate.Day == creatDateValue.Day && x.CreatedDate.Month == creatDateValue.Month && x.CreatedDate.Year == creatDateValue.Year);
            }

            return databaseQuery;
        }

        // POST api/<controller>
        public void Post([FromBody] User User)
        {
            _context.Users.Add(User);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] User value)
        {
            var result = _context.Users.SingleOrDefault(x => x.UserId == id);
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            result.Email = value.Email;
            result.UserId = value.UserId;
            result.Password = value.Password;

            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var toRemove = this.Get(new UserQuery() { UserId = id }).SingleOrDefault();

            if (toRemove == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Users.Remove(toRemove);
        }
    }
}