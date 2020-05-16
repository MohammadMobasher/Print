using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels.ProjectAndSubProject.ProjectViewModel
{
    public class ProjectUpdateViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int UserId { get; set; }

        public int OrganizationId { get; set; }

        public string Address { get; set; }

        public double? lat { get; set; }
        public double? lng { get; set; }
    }
}
