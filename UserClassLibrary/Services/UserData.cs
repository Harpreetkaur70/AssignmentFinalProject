using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using UserClassLibrary.DataContext;
using UserClassLibrary.Helpers;
using UserClassLibrary.Models;
using UserClassLibrary.ViewModel;

namespace UserClassLibrary.Services
{
    public class UserData : IUserData
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSetting _appSetting;


        public UserData(ApplicationDbContext applicationDbContex, IOptions<AppSetting> appsetting)
        {
            _context = applicationDbContex;
            _appSetting = appsetting.Value;
        }

        public User AddUser(User userRegistration)
        {
            _context.Users.Add(userRegistration);
            _context.SaveChanges();
            return userRegistration;
        }

        public User GetUserByUserName(string userName)
        {
            var user = _context.Users.Where(x => x.UserName == userName).FirstOrDefault();
            return user;
        }
        public User GetUserByEmail(string Email)
        {
            var user = _context.Users.Where(x => x.Email == Email).FirstOrDefault();
            return user;
        }
        public string Login(LoginViewModel loginVM)
        {
            var userName = _context.Users.Where(x => x.UserName == loginVM.UserNameOrEmail || x.Email == loginVM.UserNameOrEmail).FirstOrDefault();
            if (userName != null)
            {
                if (userName.Password != loginVM.Password)
                {
                    return "Wrong Password";
                }
                else
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenKey = Encoding.ASCII.GetBytes(_appSetting.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name,loginVM.UserNameOrEmail)
                        }),
                        Expires = DateTime.UtcNow.AddDays(5),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return tokenHandler.WriteToken(token);


                }
            }
            return "Wrong Email";
        }
    }
}
    
