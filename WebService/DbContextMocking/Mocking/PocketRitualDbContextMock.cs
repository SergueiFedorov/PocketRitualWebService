using Moq;
using PocketRitual.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DbContextMocking
{
    public class PocketRitualDbContextMock : IPocketRitualDbContext
    {

        public PocketRitualDbContextMock()
        {
            Actions = DbSetMock<PocketRitual.Models.Action>();
            ActionCategories = DbSetMock<ActionCategory>();
            Cards = DbSetMock<Card>();
            CardActions = DbSetMock<CardAction>();
            CardCategories = DbSetMock<CardCategory>();
            Events = DbSetMock<Event>();
            Journeys = DbSetMock<Journey>();
            JourneyCards = DbSetMock<JourneyCard>();
            Users = DbSetMock<User>(); 
        }

        public DbSet<PocketRitual.Models.Action> Actions { get; set; }
        public DbSet<ActionCategory> ActionCategories { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardAction> CardActions { get; set; }
        public DbSet<CardCategory> CardCategories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<JourneyCard> JourneyCards { get; set; }
        public DbSet<User> Users { get; set; }

        private DbSet<T> DbSetMock<T>()
             where T : class
        {
            var store = new List<T>();
            var journeyMock = new Mock<DbSet<T>>();

            journeyMock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(() => store.AsQueryable().Provider);
            journeyMock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(() => store.GetEnumerator());
            journeyMock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(() => store.AsQueryable().Expression);
            journeyMock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(() => store.AsQueryable().ElementType);

            journeyMock.Setup(x => x.Create()).Returns<T>((x) => { return new Mock<T>().Object; });
            journeyMock.Setup(x => x.Add(It.IsAny<T>())).Callback<T>(store.Add);

            return journeyMock.Object;
        }

        public void Dispose()
        {

        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
