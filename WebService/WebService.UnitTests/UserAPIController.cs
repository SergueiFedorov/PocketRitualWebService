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
    public class UserAPIController
    {
        [TestMethod]
        public void GetAllUsers_Controller()
        {
            const int User_COUNT = 10;

            var queryObject = new UserQuery() { };
            var testElement = MockingTools.CreateBasicSetup(User_COUNT);

            var result = testElement.user_controller.Get(queryObject);

            Assert.AreEqual(User_COUNT, result.Count());
        }

        [TestMethod]
        public void GetUserById_Controller()
        {
            const int User_COUNT = 10;

            var queryObject = new UserQuery() { UserId = 1 };

            var testElement = MockingTools.CreateBasicSetup(User_COUNT);

            var result = testElement.user_controller.Get(queryObject);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(result.ElementAt(0).UserId, 1);
        }

        [TestMethod]
        public void GetUserByName_Controller()
        {
            const int User_COUNT = 10;
            string User_EMAIL = MockingTools.CreateUserEmail(1);

            var queryObject = new UserQuery() { Email = User_EMAIL };

            var testElement = MockingTools.CreateBasicSetup(User_COUNT);
            var result = testElement.user_controller.Get(queryObject);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(result.ElementAt(0).Email, User_EMAIL);
        }

        [TestMethod]
        public void GetUserByCreateDate_Controller()
        {
            const int User_COUNT = 10;
            DateTime User_CREATE = MockingTools.CreateDateTime(1);

            var queryObject = new UserQuery() { CreatedDate = User_CREATE };

            var testElement = MockingTools.CreateBasicSetup(User_COUNT);
            var result = testElement.user_controller.Get(queryObject);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(result.ElementAt(0).CreatedDate, User_CREATE);
        }

        [TestMethod]
        public void CreateUser_Controller()
        {
            const int User_COUNT = 0;

            var testElement = MockingTools.CreateBasicSetup(User_COUNT);

            testElement.user_controller.Post(new User() { Email = "test@website.com", UserId = 1 });

            var result = testElement.context.Users.SingleOrDefault(x => x.Email == "test@website.com" && x.UserId == 1);

            Assert.IsTrue(result.Email == "test@website.com" && result.UserId == 1);
        }

        [TestMethod]
        public void UpdateUser_Controller()
        {
            const int User_COUNT = 1;
            int User_ID = MockingTools.CreateUserId(0);

            var testElement = MockingTools.CreateBasicSetup(User_COUNT);

            User updatedUser = new User() { Email = "newName@website.com", UserId = 10 };

            testElement.user_controller.Put(User_ID, updatedUser);

            var result = testElement.context.Users.SingleOrDefault(x => x.UserId == 10 && x.Email == "newName@website.com");

            Assert.IsTrue(result.Email == "newName@website.com" && result.UserId == 10);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void UpdateNoneExistentUser_Controller()
        {
            const int User_COUNT = 0;
            int User_ID = MockingTools.CreateUserId(0);

            var testElement = MockingTools.CreateBasicSetup(User_COUNT);

            testElement.user_controller.Put(User_ID, null);
        }

        [TestMethod]
        public void DeleteUser_Controller()
        {
            const int User_COUNT = 1;
            int User_ID = MockingTools.CreateUserId(0);

            var testElement = MockingTools.CreateBasicSetup(User_COUNT);

            testElement.user_controller.Delete(User_ID);

            var result = testElement.context.Users.SingleOrDefault(x => x.UserId == 10 && x.Email == "newName");

            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void DeleteNonExistentUser_Controller()
        {
            const int User_COUNT = 0;
            int User_ID = MockingTools.CreateUserId(0);

            var testElement = MockingTools.CreateBasicSetup(User_COUNT);

            testElement.user_controller.Delete(User_ID);
        }
    }
}
