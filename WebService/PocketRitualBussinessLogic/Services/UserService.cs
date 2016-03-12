using WebService.API;
using WebService.API.Query_Objects;
using PocketRitual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketRitualBussinessLogic.Services
{
    public class UserService : BaseService
    {
        public UserService(IPocketRitualDbContext context)
            : base(context)
        {

        }
        
        public IEnumerable<User> GetUsersById(int UserId)
        {
            IQueryable<User> databaseQuery = Context.Users;

            databaseQuery = databaseQuery.Where(x => x.UserId == UserId);

            return databaseQuery;
        }

        public IEnumerable<User> GetUsersByEmail(string email)
        {
            IQueryable<User> databaseQuery = Context.Users;

            databaseQuery = databaseQuery.Where(x => x.Email.Equals(email));

            return databaseQuery;
        }

        public IEnumerable<User> GetUsersByEmailAndPassword(string email, string password)
        {
            IQueryable<User> databaseQuery = Context.Users;

            databaseQuery = databaseQuery.Where(x => x.Email.Equals(email) && x.Password.Equals(password));

            return databaseQuery;
        }

        public IEnumerable<User> GetUsersByDate(int userId, DateTime date)
        {
            IQueryable<User> databaseQuery = Context.Users;

            databaseQuery = databaseQuery.Where(x => x.CreatedDate == date && x.UserId == userId);

            return databaseQuery;
        }

        public IEnumerable<User> GetUsersByDate(string email, DateTime date)
        {
            IQueryable<User> databaseQuery = Context.Users;

            databaseQuery = databaseQuery.Where(x => x.CreatedDate == date && x.Email.Equals(email));

            return databaseQuery;
        }
    }
}
