using DataLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Organization : BaseEntity<int>
    {

        public string OrganizationTitle { get; set; }
        public string OrganizationPhone { get; set; }
        public string OrganizationAddress { get; set; }

        

    }
}
