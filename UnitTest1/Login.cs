using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using UserClassLibrary.Migrations;
using UserClassLibrary.Models;
using UserClassLibrary.Services;
using UserClassLibrary.ViewModel;

namespace TestingUserWebApi
{
    public class Login      
    {
        private readonly IUserData _user;
        public Login()
        {
            var services = new ServiceCollection();
            services.AddTransient<IUserData, UserData>();
            var serviceProvider = services.BuildServiceProvider();
            _user = serviceProvider.GetService<UserData>();
        }
        #region positive test cases
        [TestMethod]
        public void TestLogin(LoginViewModel loginVM)
        {
     
            //Arrange
            var expected = typeof(user);
            //Act
            var result = _user.Login(new LoginViewModel {UserNameOrEmail= "TestUser123@gmail.com", Password= "TestUser123" });
            //Assert
            Assert.IsInstanceOfType(expected, result.GetType());
        }
        #endregion
        public void TestNoLogin()
        {
            //Arrange
            var expected = typeof(user);
            //Act
            var result = _user.Login(new LoginViewModel { UserNameOrEmail = "TestUser123@gmail.com", Password = "TestUser123" });
        }
    }
}
