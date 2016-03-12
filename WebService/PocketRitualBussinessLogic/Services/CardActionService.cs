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
    public class CardActionService : BaseService
    {
        public CardActionService(IPocketRitualDbContext context)
            : base(context)
        {

        }

        public IEnumerable<CardAction> GetCardActionsById(int CardActionId)
        {
            IQueryable<CardAction> databaseQuery = Context.CardActions;

            databaseQuery = databaseQuery.Where(x => x.CardActionId == CardActionId);

            return databaseQuery;
        }

        public IEnumerable<CardAction> GetCardActionsByCardId(int CardId)
        {
            IQueryable<CardAction> databaseQuery = Context.CardActions;

            databaseQuery = databaseQuery.Where(x => x.CardId == CardId);

            return databaseQuery;
        }

        public IEnumerable<CardAction> GetCardActionsByActionId(int ActionId)
        {
            IQueryable<CardAction> databaseQuery = Context.CardActions;

            databaseQuery = databaseQuery.Where(x => x.ActionId == ActionId);

            return databaseQuery;
        }

        /*
        public IEnumerable<CardAction> GetCardActionsByName(int userId, string name)
        {
            IQueryable<CardAction> databaseQuery = Context.CardActions;

            databaseQuery = databaseQuery.Where(x => x.Name.Equals(name) && x.UserId == userId);

            return databaseQuery;
        }

        public IEnumerable<CardAction> GetCardActionsByDate(int userId, DateTime date)
        {
            IQueryable<CardAction> databaseQuery = Context.CardActions;

            databaseQuery = databaseQuery.Where(x => x.CreatedDate == date && x.UserId == userId);

            return databaseQuery;
        }
        */
    }
}
