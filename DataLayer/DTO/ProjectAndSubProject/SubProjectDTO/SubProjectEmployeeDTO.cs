using DataLayer.Entities;
using DataLayer.SSOT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.DTO.ProjectAndSubProject.SubProjectDTO
{
    public class SubProjectEmployeeDTO
    {
        public int Id { get; set; }

        /// <summary>
        /// عنوان زیر پروژه
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// شماره پروژه ‌ایی که این آیتم مربوط به آن است
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// تعدادی که میخواهد سفارش دهد
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// زمان پیشنهادی برای تحویل کرفتن این آیتم
        /// </summary>
        public DateTime SuggestedTime { get; set; }

        /// <summary>
        /// نوع زیر پروژه مورد نظر
        /// </summary>
        public ProjectTypeSSOT SubProjectType { get; set; }

        /// <summary>
        /// اولویت این زیر پروژه
        /// </summary>
        public PrioritySSOT Priority { get; set; }

        public int NumOfPrinting { get; set; } = 0;
        public int NumOfBinding { get; set; } = 0;
        public int NumOfCovering { get; set; } = 0;

        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }

    }
}
