using PocketRitual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketRitualBussinessLogic.Services
{
    class JourneyService : BaseService
    {
        public JourneyService(IPocketRitualDbContext context)
            : base(context)
        {

        }

        public IEnumerable<Journey> GetJourneysById(int journeyId)
        {
            return null;
        }

        public IEnumerable<Journey> GetJourneysByName(int userId, string name)
        {
            return null;
        }

        public IEnumerable<Journey> GetJourneysByDate(int userId, DateTime date)
        {
            return null;
        }

    }
}
