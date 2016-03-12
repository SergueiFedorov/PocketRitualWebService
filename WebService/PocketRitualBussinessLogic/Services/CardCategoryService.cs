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
    public class CardCategoryService : BaseService
    {
        public CardCategoryService(IPocketRitualDbContext context)
            : base(context)
        {

        }

        public IEnumerable<CardCategory> GetCardCategorysById(int CardCategoryId)
        {
            IQueryable<CardCategory> databaseQuery = Context.CardCategories;

            databaseQuery = databaseQuery.Where(x => x.CardCategoryId == CardCategoryId);

            return databaseQuery;
        }

        public IEnumerable<CardCategory> GetCardCategorysByName(string name)
        {
            IQueryable<CardCategory> databaseQuery = Context.CardCategories;

            databaseQuery = databaseQuery.Where(x => x.Name.Equals(name));

            return databaseQuery;
        }

        /*
        public IEnumerable<CardCategory> GetCardCategorysByDate(int userId, DateTime date)
        {
            IQueryable<CardCategory> databaseQuery = Context.CardCategorys;

            databaseQuery = databaseQuery.Where(x => x.CreatedDate == date && x.UserId == userId);

            return databaseQuery;
        }
        */
    }
}
