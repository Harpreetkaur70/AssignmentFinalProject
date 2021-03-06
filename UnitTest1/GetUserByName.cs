using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using UserClassLibrary.Models;
using UserClassLibrary.Services;

namespace TestingUserWebApi
{
    public  class GetUserByName
    {
        private readonly IUserData _user;
        public GetUserByName()
        {
            var services = new ServiceCollection();
            services.AddTransient<IUserData, UserData>();
            var serviceProvider = services.BuildServiceProvider();
            _user = serviceProvider.GetService<UserData>();
        }
        #region positive test cases
        [TestMethod]
        public void TestGetUserByName(string username)
        {
            //Arrange
            var expected = typeof(User);
            username = "TestUser";
            //Act
            var result = _user.GetUserByUserName(username);
            //Assert
            Assert.IsInstanceOfType(expected, result.GetType());
           
        }

        #endregion

        #region negative test cases
        [TestMethod]
        public void TestNotGetUserByName(string username)
        {
            //Arrange
            var expected = typeof(User);
            username = "TestUser";
            //Act
            var result = _user.GetUserByUserName(username);
            //Assert
            Assert.IsNotInstanceOfType(expected, result.GetType());

        }
        #endregion
    }
}
