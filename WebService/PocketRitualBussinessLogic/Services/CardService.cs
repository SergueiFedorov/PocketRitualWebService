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
    public class CardService : BaseService
    {
        public CardService(IPocketRitualDbContext context)
            : base(context)
        {

        }

        public IEnumerable<Card> GetCardsById(int CardId)
        {
            IQueryable<Card> databaseQuery = Context.Cards;

            databaseQuery = databaseQuery.Where(x => x.CardId == CardId);

            return databaseQuery;
        }

        public IEnumerable<Card> GetCardsByName(string name)
        {
            IQueryable<Card> databaseQuery = Context.Cards;

            databaseQuery = databaseQuery.Where(x => x.Name.Equals(name));

            return databaseQuery;
        }

        /*
        public IEnumerable<Card> GetCardsByDate(int userId, DateTime date)
        {
            IQueryable<Card> databaseQuery = Context.Cards;

            databaseQuery = databaseQuery.Where(x => x.CreatedDate == date && x.UserId == userId);

            return databaseQuery;
        }
        */
    }
}
