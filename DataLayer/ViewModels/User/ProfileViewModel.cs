using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels.User
{
    public class ProfileViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string NormalizedEmail
        {
            get
            {
                return this.Email.ToUpper().Trim();
            }
            set
            {

            }
        }


        public string PhoneNumber { get; set; }
       
        public string UserName { get; set; }
        public string NormalizedUserName
        {
            get
            {
                return this.UserName.ToUpper().Trim();
            }
            set
            {

            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
