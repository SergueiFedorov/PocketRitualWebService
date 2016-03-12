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
    public class JourneyService : BaseService
    {
        public JourneyService(IPocketRitualDbContext context)
            : base(context)
        {

        }
        
        public IEnumerable<Journey> GetJourneysById(int journeyId)
        {
            IQueryable<Journey> databaseQuery = Context.Journeys;

            databaseQuery = databaseQuery.Where(x => x.JourneyId == journeyId);

            return databaseQuery;
        }

        public IEnumerable<Journey> GetJourneysByName(int userId, string name)
        {
            IQueryable<Journey> databaseQuery = Context.Journeys;

            databaseQuery = databaseQuery.Where(x => x.Name.Equals(name) && x.UserId == userId);

            return databaseQuery;
        }

        public IEnumerable<Journey> GetJourneysByDate(int userId, DateTime date)
        {
            IQueryable<Journey> databaseQuery = Context.Journeys;

            databaseQuery = databaseQuery.Where(x => x.CreatedDate == date && x.UserId == userId);

            return databaseQuery;
        }

        public void PostJourney(Journey journey)
        {

        }
        
        public bool PutJourney(int jID, Journey journey)
        {
            return false;
        }

        public bool DeleteJourney(Journey journey)
        {
            return false;
        }
    }
}
