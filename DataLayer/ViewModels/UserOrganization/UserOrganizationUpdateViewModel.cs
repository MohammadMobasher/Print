using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels.UserOrganization
{
    public class UserOrganizationUpdateViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int OrganizationId { get; set; }
    }
}
