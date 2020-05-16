using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels.Organizations
{
    public class OrganizationUpdateViewModel
    {
        public int Id { get; set; }
        public string OrganizationTitle { get; set; }
        public string OrganizationPhone { get; set; }
        public string OrganizationAddress { get; set; }
    }
}
