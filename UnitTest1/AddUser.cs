using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserClassLibrary.Migrations;
using UserClassLibrary.Models;
using UserClassLibrary.Services;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class AddUser
        {
            private readonly IUserData _user;
            public AddUser()
            {
                var services = new ServiceCollection();
                services.AddTransient<IUserData, UserData>();
                var serviceProvider = services.BuildServiceProvider();
                _user = serviceProvider.GetService<UserData>();
            }
            #region positive test cases
            [TestMethod]
            public void TestAddUser()
            {
                //Arrange
                var expected = typeof(user);
                //Act
                var result = _user.AddUser(new User() {FirstName="Test",LastName="User",UserName="TestUser",Email="TestUser123@gmail.com",Password= "TestUser123" });
                //Assert
                Assert.IsInstanceOfType(expected, result.GetType());
            }
            #endregion
            #region negative test cases
            [TestMethod]
            public void TestAddNoUser()
            {
                //Arrange
                var expected = typeof(UserData);
                //Act
                var result = _user.AddUser(new User() { FirstName = "Test", LastName = "User", UserName ="TestUser ", Email= "TestUser123@gmail.com",Password= "TestUser123" });
                //Assert
                Assert.IsNotInstanceOfType(expected, result.GetType());
                #endregion
            }
        }
    }
}
