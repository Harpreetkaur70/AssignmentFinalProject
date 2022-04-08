using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using UserClassLibrary.Migrations;
using UserClassLibrary.Models;
using UserClassLibrary.Services;

namespace TestingUserWebApi
{
    public class GetUserByEmail
    {
        private readonly IUserData _user;
        public GetUserByEmail()
        {
            var services = new ServiceCollection();
            services.AddTransient<IUserData, UserData>();
            var serviceProvider = services.BuildServiceProvider();
            _user = serviceProvider.GetService<UserData>();
        }
        #region positive test cases
        [TestMethod]
        public void TestGetUserByEmail()
        {
            string email = "TestUser123@gmail.com";
            //Arrange
            var expected = typeof(User);
            //Act
            var result = _user.GetUserByUserName(email);
            //Assert
            Assert.IsInstanceOfType(expected, result.GetType());
        }
        #endregion

        #region negative test cases
        [TestMethod]
        public void TestGetNoUserByEmail(string Email)
        {
            Email = "TestUser123@gmail.com";
            //Arrange 
            var expected = typeof(User);
            //Act
            var result = _user.GetUserByEmail(Email);
            //Assert
            Assert.IsNotInstanceOfType(expected, result.GetType());
        }
        #endregion
    }
}
