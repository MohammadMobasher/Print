using DataLayer.SSOT;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels.ProjectAndSubProject.ProjectViewModel
{
    public class ProjectSearchViewModel
    {

        /// <summary>
        /// عنوان پروژه مورد نظر
        /// </summary>
        public string Title { get; set; }

        public int? OrganizationId { get; set; }

        public RoutineSSOT RoutinStatus { get; set; }


    }
}
