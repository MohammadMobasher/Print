using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DTO.Organizations
{
    public class OrganizationDTO
    {
        public int Id { get; set; }
        public string OrganizationTitle { get; set; }
        public string OrganizationPhone { get; set; }
        public string OrganizationAddress { get; set; }
    }
}
