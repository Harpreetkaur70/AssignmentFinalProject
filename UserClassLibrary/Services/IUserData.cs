using System;
using System.Collections.Generic;
using System.Text;
using UserClassLibrary.Models;
using UserClassLibrary.ViewModel;

namespace UserClassLibrary.Services
{
     public interface IUserData
    {
        User AddUser(User userRegistration);
        User GetUserByUserName(string userName);
        User GetUserByEmail(string Email);
        string Login(LoginViewModel loginVM);
    }
}
