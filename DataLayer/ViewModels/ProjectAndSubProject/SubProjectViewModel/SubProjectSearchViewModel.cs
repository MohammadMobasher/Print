using DataLayer.SSOT;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels.ProjectAndSubProject.SubProjectViewModel
{
    public class SubProjectSearchViewModel
    {

        /// <summary>
        /// عنوان زیر پروژه
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// شماره کاربری که این زیرپروژه را تعریف کرده است
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// نوع زیر پروژه مورد نظر
        /// </summary>
        public ProjectTypeSSOT SubProjectType { get; set; }

        public RoutineSSOT RoutinStatus { get; set; }

    }
}
