using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PocketRitual.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebService.API;
using WebService.API.Query_Objects;
using DbContextMocking;
using DbContextMocking.Mocking;

namespace WebService.UnitTests
{
    [TestClass]
    public class JourneyAPIController
    {
        [TestMethod]
        public void GetAllJourneys_Controller()
        {
            const int JOURNEY_COUNT = 10;

            var queryObject = new JourneyQuery() { };
            var testElement = MockingTools.CreateBasicSetup(JOURNEY_COUNT);

            var result = testElement.journey_controller.Get(queryObject);

            Assert.AreEqual(JOURNEY_COUNT, result.Count());
        }

        [TestMethod]
        public void GetJourneyById_Controller()
        {
            const int JOURNEY_COUNT = 10;

            var queryObject = new JourneyQuery() { JourneyId = 1 };

            var testElement = MockingTools.CreateBasicSetup(JOURNEY_COUNT);

            var result = testElement.journey_controller.Get(queryObject);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(result.ElementAt(0).JourneyId, 1);
        }

        [TestMethod]
        public void GetJourneyByName_Controller()
        {
            const int JOURNEY_COUNT = 10;
            string JOURNEY_NAME = MockingTools.CreateJourneyName(1);

            var queryObject = new JourneyQuery() { JourneyName = JOURNEY_NAME };

            var testElement = MockingTools.CreateBasicSetup(JOURNEY_COUNT);
            var result = testElement.journey_controller.Get(queryObject);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(result.ElementAt(0).Name, JOURNEY_NAME);
        }

        [TestMethod]
        public void GetJourneyByCreateDate_Controller()
        {
            const int JOURNEY_COUNT = 10;
            DateTime JOURNEY_CREATE = MockingTools.CreateDateTime(1);

            var queryObject = new JourneyQuery() { CreatedDate = JOURNEY_CREATE };

            var testElement = MockingTools.CreateBasicSetup(JOURNEY_COUNT);
            var result = testElement.journey_controller.Get(queryObject);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(result.ElementAt(0).CreatedDate, JOURNEY_CREATE);
        }

        [TestMethod]
        public void CreateJourney_Controller()
        {
            const int JOURNEY_COUNT = 0;

            var testElement = MockingTools.CreateBasicSetup(JOURNEY_COUNT);

            testElement.journey_controller.Post(new Journey() { Name = "test", UserId = 1 });

            var result = testElement.context.Journeys.SingleOrDefault(x => x.Name == "test" && x.UserId == 1);

            Assert.IsTrue(result.Name == "test" && result.UserId == 1);
        }

        [TestMethod]
        public void UpdateJourney_Controller()
        {
            const int JOURNEY_COUNT = 1;
            int JOURNEY_ID = MockingTools.CreateJourneyId(0);

            var testElement = MockingTools.CreateBasicSetup(JOURNEY_COUNT);

            Journey updatedJourney = new Journey() { Name = "newName", UserId = 10 };

            testElement.journey_controller.Put(JOURNEY_ID, updatedJourney);

            var result = testElement.context.Journeys.SingleOrDefault(x => x.UserId == 10 && x.Name == "newName");

            Assert.IsTrue(result.Name == "newName" && result.UserId == 10);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void UpdateNoneExistentJourney_Controller()
        {
            const int JOURNEY_COUNT = 0;
            int JOURNEY_ID = MockingTools.CreateJourneyId(0);

            var testElement = MockingTools.CreateBasicSetup(JOURNEY_COUNT);

            testElement.journey_controller.Put(JOURNEY_ID, null);
        }

        [TestMethod]
        public void DeleteJourney_Controller()
        {
            const int JOURNEY_COUNT = 1;
            int JOURNEY_ID = MockingTools.CreateJourneyId(0);

            var testElement = MockingTools.CreateBasicSetup(JOURNEY_COUNT);

            testElement.journey_controller.Delete(JOURNEY_ID);

            var result = testElement.context.Journeys.SingleOrDefault(x => x.UserId == 10 && x.Name == "newName");

            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void DeleteNonExistentJourney_Controller()
        {
            const int JOURNEY_COUNT = 0;
            int JOURNEY_ID = MockingTools.CreateJourneyId(0);

            var testElement = MockingTools.CreateBasicSetup(JOURNEY_COUNT);

            testElement.journey_controller.Delete(JOURNEY_ID);
        }
    }
}
