using Moq;
using PocketRitual.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WebService.UnitTests.Mocking
{
    internal class PocketRitualDbContextMock : IPocketRitualDbContext
    {

        public PocketRitualDbContextMock()
        {
            Journeys = DbSetMock<Journey>();
            Users = DbSetMock<User>();
        }

        public DbSet<Journey> Journeys { get; set; }
        public DbSet<User> Users { get; set; }

        private DbSet<T> DbSetMock<T>()
             where T : class
        {
            var store = new List<T>() ;
            //var storeQuery = store.AsQueryable();
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
