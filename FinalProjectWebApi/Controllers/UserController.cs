using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserClassLibrary.Models;
using UserClassLibrary.Services;
using UserClassLibrary.ViewModel;

namespace UserWebApi.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private IUserData _userData;
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public UserController(IUserData userData)
        {
            _userData = userData;
        }

        [HttpPost]
        [Route("api/AddUser/")]
        public IActionResult AddUser(User userRegistration)
        {
            var username = _userData.GetUserByUserName(userRegistration.UserName);
            var email = _userData.GetUserByEmail(userRegistration.Email);
            if (username != null)
            {
                return NotFound("User Exist");
            }
            if (email != null)
            {
                return NotFound("Email Exist");
            }
            else
            {
                _userData.AddUser(userRegistration);
                return Ok("Added");
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("api/Login/")]
        public IActionResult LogIn(LoginViewModel loginVM)
        {
            var result = _userData.Login(loginVM);

            if (result != null)
                return Ok(result);
            else
                return Unauthorized();
        }

    }
}
