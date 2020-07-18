using Antlr.Runtime.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Serialization;
using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using OdeToFood.Web.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Tests
{

    [TestClass]
    public class MainClass
    {
        IList<Restaurant> restList = new List<Restaurant>
                {
                      new Restaurant { Id = 1, Name = "Scott's Pizza", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Tersiguels", Cuisine = CuisineType.French},
                new Restaurant { Id = 3, Name = "Mango Grove", Cuisine = CuisineType.Indian}
                };

        [TestMethod]
        public void TestBasic()
        {
            string a = "100";
            int b = 100;
            Assert.AreEqual(a, b.ToString());


        }

        [TestMethod]
        public void RestuarantTestCaseScenario()
        {
            var restDataToBeAdded = new Restaurant
            {
                Id = 1,
                Name = "Scott's Pizza",
                Cuisine = CuisineType.Italian
            };

            var restDataExpected = new Restaurant
            {
                Id = 1,
                Name = "Scott's Pizza",
                Cuisine = CuisineType.Italian
            };

            /*First have created a mocking object of IRestaurantData by this statement.
             * This statement says we will be potentially mocking a few methods or properties of the interface or System Under Test(SUT)
            */
            Mock<IRestaurantData> restData = new Mock<IRestaurantData>();
            //Calling Add Method:
            restData.Setup(func => func.Add(restDataToBeAdded));
    

            //Calling Update Method:
            restData.Setup(func => func.Update(restDataToBeAdded));

            //Calling Get Method:
            restData.Setup(t => t.Get(It.IsAny<int>())).Returns(new Restaurant()
            {
                Id = 1,
                Name = "Scott's Pizza",
                Cuisine = CuisineType.Italian
            });

            Assert.IsNotNull(restData);

            var result = restData.Object.Get(1);
            Assert.AreEqual(restDataExpected.Id, result.Id);

        }
        [TestMethod]
        public void TestCaseExecution()
        {
            Mock<IUserStore> mockedUserStore = new Mock<IUserStore>();

            mockedUserStore.Setup(func => func.GetUserRole("admin")).Returns("administrator");
            mockedUserStore.Setup(func => func.GetUserRole("user1")).Returns("contributor");
            mockedUserStore.Setup(func => func.GetUserRole("user2")).Returns("basic");




        }

    }
}
