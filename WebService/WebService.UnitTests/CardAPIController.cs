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
    public class CardAPIController
    {
        [TestMethod]
        public void GetAllCards_Controller()
        {
            const int Card_COUNT = 10;

            var queryObject = new CardQuery() { };
            var testElement = MockingTools.CreateBasicSetup(Card_COUNT);

            var result = testElement.card_controller.Get(queryObject);

            Assert.AreEqual(Card_COUNT, result.Count());
        }

        [TestMethod]
        public void GetCardById_Controller()
        {
            const int Card_COUNT = 10;

            var queryObject = new CardQuery() { CardId = 1 };

            var testElement = MockingTools.CreateBasicSetup(Card_COUNT);

            var result = testElement.card_controller.Get(queryObject);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(result.ElementAt(0).CardID, 1);
        }

        [TestMethod]
        public void GetCardByName_Controller()
        {
            const int Card_COUNT = 10;
            string Card_NAME = MockingTools.CreateCardName(1);

            var queryObject = new CardQuery() { Name = Card_NAME };

            var testElement = MockingTools.CreateBasicSetup(Card_COUNT);
            var result = testElement.card_controller.Get(queryObject);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(result.ElementAt(0).Name, Card_NAME);
        }
        
        /*
        [TestMethod]
        public void GetCardByCreateDate_Controller()
        {
            const int Card_COUNT = 10;
            DateTime Card_CREATE = MockingTools.CreateDateTime(1);

            var queryObject = new CardQuery() { CreateDate = Card_CREATE };

            var testElement = MockingTools.CreateBasicSetup(Card_COUNT);
            var result = testElement.Card_controller.Get(queryObject);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(result.ElementAt(0).CreatedDate, Card_CREATE);
        }
        */

        [TestMethod]
        public void CreateCard_Controller()
        {
            const int Card_COUNT = 0;

            var testElement = MockingTools.CreateBasicSetup(Card_COUNT);

            testElement.card_controller.Post(new Card() { Name = "test", CardID = 1});

            var result = testElement.context.Cards.SingleOrDefault(x => x.Name == "test" && x.CardID == 1);

            Assert.IsTrue(result.Name == "test" && result.CardID == 1);
        }

        [TestMethod]
        public void UpdateCard_Controller()
        {
            const int Card_COUNT = 1;
            int Card_ID = MockingTools.CreateCardId(0);

            var testElement = MockingTools.CreateBasicSetup(Card_COUNT);

            Card updatedCard = new Card() { Name = "newName", CardID = 10 };

            testElement.card_controller.Put(Card_ID, updatedCard);

            var result = testElement.context.Cards.SingleOrDefault(x => x.CardID == 10 && x.Name == "newName");

            Assert.IsTrue(result.Name == "newName" && result.CardID == 10);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void UpdateNoneExistentCard_Controller()
        {
            const int Card_COUNT = 0;
            int Card_ID = MockingTools.CreateCardId(0);

            var testElement = MockingTools.CreateBasicSetup(Card_COUNT);

            testElement.card_controller.Put(Card_ID, null);
        }

        [TestMethod]
        public void DeleteCard_Controller()
        {
            const int Card_COUNT = 1;
            int Card_ID = MockingTools.CreateCardId(0);

            var testElement = MockingTools.CreateBasicSetup(Card_COUNT);

            testElement.card_controller.Delete(Card_ID);

            var result = testElement.context.Cards.SingleOrDefault(x => x.CardID == 10 && x.Name == "newName");

            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void DeleteNonExistentCard_Controller()
        {
            const int Card_COUNT = 0;
            int Card_ID = MockingTools.CreateCardId(0);

            var testElement = MockingTools.CreateBasicSetup(Card_COUNT);

            testElement.card_controller.Delete(Card_ID);
        }
    }
}
