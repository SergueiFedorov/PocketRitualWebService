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
    public class ActionCategoryService : BaseService
    {
        public ActionCategoryService(IPocketRitualDbContext context)
            : base(context)
        {

        }

        public IEnumerable<ActionCategory> GetActionCategoriesById(int ActionCategoryId)
        {
            IQueryable<ActionCategory> databaseQuery = Context.ActionCategories;

            databaseQuery = databaseQuery.Where(x => x.ActionCategoryId == ActionCategoryId);

            return databaseQuery;
        }

        public IEnumerable<ActionCategory> GetActionCategoriesByName(string name)
        {
            IQueryable<ActionCategory> databaseQuery = Context.ActionCategories;

            databaseQuery = databaseQuery.Where(x => x.Name.Equals(name));

            return databaseQuery;
        }

        /*
        public IEnumerable<ActionCategory> GetActionCategorysByDate(DateTime date)
        {
            IQueryable<ActionCategory> databaseQuery = Context.ActionCategories;

            databaseQuery = databaseQuery.Where(x => x.CreatedDate == date && x.UserId == userId);

            return databaseQuery;
        }
        */

    }
}
