using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserClassLibrary.ViewModel
{
    public class LoginViewModel
    {

        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
