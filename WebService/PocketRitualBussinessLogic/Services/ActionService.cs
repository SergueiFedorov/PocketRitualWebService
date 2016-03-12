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
    public class ActionService : BaseService
    {
        public ActionService(IPocketRitualDbContext context)
            : base(context)
        {

        }

        public IEnumerable<PocketRitual.Models.Action> GetActionsById(int ActionId)
        {
            IQueryable<PocketRitual.Models.Action> databaseQuery = Context.Actions;

            databaseQuery = databaseQuery.Where(x => x.ActionId == ActionId);

            return databaseQuery;
        }

        public IEnumerable<PocketRitual.Models.Action> GetActionsByCategoryId(int ActionCategoryId)
        {
            IQueryable<PocketRitual.Models.Action> databaseQuery = Context.Actions;

            databaseQuery = databaseQuery.Where(x => x.ActionCategoryId == ActionCategoryId);

            return databaseQuery;
        }

        /*
        public IEnumerable<PocketRitual.Models.Action> GetActionsByName(int userId, string name)
        {
            IQueryable<PocketRitual.Models.Action> databaseQuery = Context.Actions;

            databaseQuery = databaseQuery.Where(x => x.Name.Equals(name) && x.UserId == userId);

            return databaseQuery;
        }

        public IEnumerable<PocketRitual.Models.Action> GetActionsByDate(int userId, DateTime date)
        {
            IQueryable<PocketRitual.Models.Action> databaseQuery = Context.Actions;

            databaseQuery = databaseQuery.Where(x => x.CreatedDate == date && x.UserId == userId);

            return databaseQuery;
        }
        */
    }
}
