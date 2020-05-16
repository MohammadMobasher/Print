using DataLayer.SSOT;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels.ProjectAndSubProject.ProjectViewModel
{
    public class ProjectInsertViewModel
    {
        /// <summary>
        /// عنوان پروژه
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///  زمان ایجاد این پروژه
        /// </summary>
        public DateTime Created { get; set; }


        /// <summary>
        /// مربوط به کدام سازمان است
        /// </summary>
        public int OrganizationId { get; set; }

        public int UserId { get; set; }

        public string Address { get; set; }

        public double? lat { get; set; }
        public double? lng { get; set; }


        public ProjectStatusSSOT Status { get; set; }

    }
}
