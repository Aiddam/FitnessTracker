using Microsoft. VisualStudio.TestTools.UnitTesting;
using Fitness_Tracker.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.BL.Controller;

namespace Fitness_Tracker.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
       

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var gender = "man";
            var weight = 90;
            var height = 192;
            var controller = new UserController(userName);
            //Act
            controller.SetNewUserData(gender,birthDate,weight,height);
            var controller2 = new UserController(userName);
            
            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            //Act
            var controller = new UserController(userName);
            //Assert
            Assert.AreEqual(userName,controller.CurrentUser.Name);
        }
    }
}