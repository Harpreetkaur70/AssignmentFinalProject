using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                var expected = typeof(User);



                //Act
                var result = _user.AddUser(new User() { });



                //Assert
                Assert.(expected, result.GetType());
            }



            #endregion
        }
    }
}
