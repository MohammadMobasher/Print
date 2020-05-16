using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels.User
{
    public class UserChangePasswordViewModel
    {

        public string Password { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string conPassword { get; set; }

    }
}
