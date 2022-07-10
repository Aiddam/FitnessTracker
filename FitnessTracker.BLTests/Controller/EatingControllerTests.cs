using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessTracker.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.BL.Model;

namespace FitnessTracker.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName,rnd.Next(50,500),rnd.Next(40,500),
                                          rnd.Next(50,500),rnd.Next(40,400));
            //Act
            eatingController.Add(food,100);

            //Assert
            Assert.AreEqual(food.Name,eatingController.Eating.Foods.Last().Key.Name);

        }
    }
}