using PocketRitual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.API;

namespace DbContextMocking.Mocking
{
    public class MockingTools
    {

        public class BasicSetupObjects
        {
            public JourneyController journey_controller;
            public UserController user_controller;
            public CardController card_controller;
            public IPocketRitualDbContext context;
            public IEnumerable<Journey> journeys;
            public IEnumerable<User> users;
            public IEnumerable<Card> cards;
        }

        /*
        public struct ControllerContexts
        {
            public JourneyController jController;
            public UserController uController;
            public CardController cController;
        }

        public struct DataObjects
        {
            public IEnumerable<Journey> journeys;
            public IEnumerable<User> users;
            public IEnumerable<Card> cards;
        }
        */

        public static string CreateJourneyName(int offset)
        {
            return $"test{offset}";
        }

        public static string CreateUserEmail(int offset)
        {
            return $"test{offset}@website.com";
        }

        public static string CreateCardName(int offset)
        {
            return $"test{offset}";
        }

        public static DateTime CreateDateTime(int offset)
        {
            return new DateTime(2015 + offset, 10, 10);
        }

        public static int CreateJourneyId(int offset)
        {
            return offset + 1;
        }

        public static int CreateUserId(int offset)
        {
            return offset + 1;
        }

        public static int CreateCardId(int offset)
        {
            return offset + 1;
        }

        public static void MockContextAndController(ref BasicSetupObjects controllers, ref IPocketRitualDbContext context)
        {
            context = new PocketRitualDbContextMock();
            controllers.journey_controller = new JourneyController(context);
            controllers.user_controller = new UserController(context);
            controllers.card_controller = new CardController(context);

        }

        public static IEnumerable<Journey> MockJourneys(int count, int userID = -1)
        {
            var journeys = new List<Journey>(count);
            for (int x = 0; x < count; ++x)
            {
                journeys.Add(new Journey()
                {
                    JourneyId = CreateJourneyId(x),
                    UserId = userID,
                    Name = CreateJourneyName(x),
                    CreatedDate = CreateDateTime(x)
                });
            }

            return journeys;
        }

        public static IEnumerable<User> MockUsers(int count, int userID = -1)
        {
            var users = new List<User>(count);
            for (int i = 0; i < count; ++i)
            {
                users.Add(new User()
                {
                    UserId = CreateUserId(i),
                    Email = CreateUserEmail(i),
                    CreatedDate = CreateDateTime(i)
                }
                    );
            }
            return users;
        }

        public static IEnumerable<Card> MockCards(int count, int cardId = -1)
        {
            var cards = new List<Card>(count);
            for (int i = 0; i < count; ++i)
            {
                cards.Add(new Card()
                {
                    CardID = CreateCardId(i),
                    CardCategoryID = CreateCardId(i),
                    Name = CreateCardName(i)
                });
            }
            return cards;
        }

        public static void LoadJourneysIntoContext(IEnumerable<Journey> journeys, IPocketRitualDbContext context)
        {
            foreach (var journey in journeys)
            {
                context.Journeys.Add(journey);
            }
        }

        public static void LoadUsersIntoContext(IEnumerable<User> users, IPocketRitualDbContext context)
        {
            foreach (var user in users)
            {
                context.Users.Add(user);
            }
        }

        public static void LoadCardsIntoContext(IEnumerable<Card> cards, IPocketRitualDbContext context)
        {
            foreach (var card in cards)
            {
                context.Cards.Add(card);
            }
        }

        public static void CreateBasicSetup(ref BasicSetupObjects controllers, ref IPocketRitualDbContext context, int count)
        {
            MockContextAndController(ref controllers, ref context);
            controllers.journeys = MockJourneys(count);
            controllers.users = MockUsers(count);
            controllers.cards = MockCards(count);
            LoadJourneysIntoContext(controllers.journeys, context);
            LoadUsersIntoContext(controllers.users, context);
            LoadCardsIntoContext(controllers.cards, context);
        }

        public static BasicSetupObjects CreateBasicSetup(int count)
        {
            BasicSetupObjects returnObject = new BasicSetupObjects();
            CreateBasicSetup(ref returnObject, ref returnObject.context, count);
            return returnObject;
        }
    }
}
