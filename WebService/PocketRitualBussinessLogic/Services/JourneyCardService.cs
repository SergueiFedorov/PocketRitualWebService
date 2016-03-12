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
    public class JourneyCardService : BaseService
    {
        public JourneyCardService(IPocketRitualDbContext context)
            : base(context)
        {

        }

        public IEnumerable<JourneyCard> GetJourneyCardsById(int JourneyCardId)
        {
            IQueryable<JourneyCard> databaseQuery = Context.JourneyCards;

            databaseQuery = databaseQuery.Where(x => x.JourneyCardId == JourneyCardId);

            return databaseQuery;
        }

        public IEnumerable<JourneyCard> GetJourneyCardsByJourneyId(int JourneyId)
        {
            IQueryable<JourneyCard> databaseQuery = Context.JourneyCards;

            databaseQuery = databaseQuery.Where(x => x.JourneyId == JourneyId);

            return databaseQuery;
        }

        public IEnumerable<JourneyCard> GetJourneyCardsByCardId(int CardId)
        {
            IQueryable<JourneyCard> databaseQuery = Context.JourneyCards;

            databaseQuery = databaseQuery.Where(x => x.CardId == CardId);

            return databaseQuery;
        }

        public IEnumerable<JourneyCard> GetJourneyCardsByTime(DateTime timeValue)
        {
            IQueryable<JourneyCard> databaseQuery = Context.JourneyCards;

            databaseQuery = databaseQuery.Where(x => x.Time.Day == timeValue.Day && x.Time.Month == timeValue.Month && x.Time.Year == timeValue.Year);

            return databaseQuery;
        }
    }
}
