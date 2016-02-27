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
    public class JourneyCardAPIController
    {
        [TestMethod]
        public void GetAllJourneyCards_Controller()
        {
            const int JourneyCard_COUNT = 10;

            var queryObject = new JourneyCardQuery() { };
            var testElement = MockingTools.CreateBasicSetup(JourneyCard_COUNT);

            var result = testElement.journey_card_controller.Get(queryObject);

            Assert.AreEqual(JourneyCard_COUNT, result.Count());
        }

        [TestMethod]
        public void GetJourneyCardById_Controller()
        {
            const int JourneyCard_COUNT = 10;

            var queryObject = new JourneyCardQuery() { JourneyCardId = 1 };

            var testElement = MockingTools.CreateBasicSetup(JourneyCard_COUNT);

            var result = testElement.journey_card_controller.Get(queryObject);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(result.ElementAt(0).JourneyCardId, 1);
        }

        //[TestMethod]
        //public void GetJourneyCardByName_Controller()
        //{
        //    const int JourneyCard_COUNT = 10;
        //    string JourneyCard_EMAIL = MockingTools.CreateJourneyCardEmail(1);

        //    var queryObject = new JourneyCardQuery() { Email = JourneyCard_EMAIL };

        //    var testElement = MockingTools.CreateBasicSetup(JourneyCard_COUNT);
        //    var result = testElement.journey_card_controller.Get(queryObject);

        //    Assert.AreEqual(1, result.Count());
        //    Assert.AreEqual(result.ElementAt(0).Email, JourneyCard_EMAIL);
        //}

        [TestMethod]
        public void GetJourneyCardByCreateDate_Controller()
        {
            const int JourneyCard_COUNT = 10;
            DateTime JourneyCard_CREATE = MockingTools.CreateDateTime(1);

            var queryObject = new JourneyCardQuery() { Time = JourneyCard_CREATE };

            var testElement = MockingTools.CreateBasicSetup(JourneyCard_COUNT);
            var result = testElement.journey_card_controller.Get(queryObject);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(result.ElementAt(0).Time, JourneyCard_CREATE);
        }

        [TestMethod]
        public void CreateJourneyCard_Controller()
        {
            const int JourneyCard_COUNT = 0;

            var testElement = MockingTools.CreateBasicSetup(JourneyCard_COUNT);

            testElement.journey_card_controller.Post(new JourneyCard() {JourneyCardId = 1, JourneyId = 1, CardId = 1 });

            var result = testElement.context.JourneyCards.SingleOrDefault(x => x.JourneyCardId == 1 && x.JourneyId == 1 && x.CardId == 1);

            Assert.IsTrue(result.JourneyCardId == 1 && result.JourneyId == 1 && result.CardId == 1);
        }

        [TestMethod]
        public void UpdateJourneyCard_Controller()
        {
            const int JourneyCard_COUNT = 1;
            int JourneyCard_ID = MockingTools.CreateJourneyCardId(0);

            var testElement = MockingTools.CreateBasicSetup(JourneyCard_COUNT);

            JourneyCard updatedJourneyCard = new JourneyCard() { JourneyCardId = 10, JourneyId = 1, CardId = 1 };

            testElement.journey_card_controller.Put(JourneyCard_ID, updatedJourneyCard);

            var result = testElement.context.JourneyCards.SingleOrDefault(x => x.JourneyCardId == 10 && x.JourneyId == 1 && x.CardId == 1);

            Assert.IsTrue(result.JourneyCardId == 10 && result.JourneyId == 1 && result.CardId == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void UpdateNoneExistentJourneyCard_Controller()
        {
            const int JourneyCard_COUNT = 0;
            int JourneyCard_ID = MockingTools.CreateJourneyCardId(0);

            var testElement = MockingTools.CreateBasicSetup(JourneyCard_COUNT);

            testElement.journey_card_controller.Put(JourneyCard_ID, null);
        }

        //TODO: DOUBLE CHECK THIS
        [TestMethod]
        public void DeleteJourneyCard_Controller()
        {
            const int JourneyCard_COUNT = 1;
            int JourneyCard_ID = MockingTools.CreateJourneyCardId(0);

            var testElement = MockingTools.CreateBasicSetup(JourneyCard_COUNT);

            testElement.journey_card_controller.Delete(JourneyCard_ID);

            var result = testElement.context.JourneyCards.SingleOrDefault(x => x.JourneyCardId == 10);

            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void DeleteNonExistentJourneyCard_Controller()
        {
            const int JourneyCard_COUNT = 0;
            int JourneyCard_ID = MockingTools.CreateJourneyCardId(0);

            var testElement = MockingTools.CreateBasicSetup(JourneyCard_COUNT);

            testElement.journey_card_controller.Delete(JourneyCard_ID);
        }
    }
}
