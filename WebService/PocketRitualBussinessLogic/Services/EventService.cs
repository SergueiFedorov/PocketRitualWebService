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
    public class EventService : BaseService
    {
        public EventService(IPocketRitualDbContext context)
            : base(context)
        {

        }

        public IEnumerable<PocketRitual.Models.Event> GetEventsById(int EventId)
        {
            IQueryable<PocketRitual.Models.Event> databaseQuery = Context.Events;

            databaseQuery = databaseQuery.Where(x => x.EventId == EventId);

            return databaseQuery;
        }

        public IEnumerable<PocketRitual.Models.Event> GetEventsByActionId(int ActionId)
        {
            IQueryable<PocketRitual.Models.Event> databaseQuery = Context.Events;

            databaseQuery = databaseQuery.Where(x => x.ActionId == ActionId);

            return databaseQuery;
        }

        public IEnumerable<PocketRitual.Models.Event> GetEventsByTime(DateTime timeValue)
        {
            IQueryable<PocketRitual.Models.Event> databaseQuery = Context.Events;

            databaseQuery = databaseQuery.Where(x => x.Time.Day == timeValue.Day && x.Time.Month == timeValue.Month && x.Time.Year == timeValue.Year);

            return databaseQuery;
        }

    }
}
