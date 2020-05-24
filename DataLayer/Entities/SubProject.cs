using DataLayer.Entities.Common;
using DataLayer.SSOT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class SubProject : BaseEntity<int>
    {
        /// <summary>
        /// شماره پروژه ‌ایی که این آیتم مربوط به آن است
        /// </summary>
        public int ProjectId { get; set; }
        
        /// <summary>
        /// عنوان زیر پروژه
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// تعدادی که میخواهد سفارش دهد
        /// </summary>
        public int Number { get; set; }


        public DateTime SuggestedTime { get; set; }

        /// <summary>
        /// نوع زیر پروژه مورد نظر
        /// </summary>
        public ProjectTypeSSOT SubProjectType { get; set; }

        /// <summary>
        /// سایز 
        /// این آیتم برای زمانی استفاده می شود که چاپ بر اساس یک تک صفحه ایی باشد
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// درصورتی که به صورت کاستوم انتخاب شده باشد 
        /// این فیلد پر میشود
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// درصورتی که به صورت کاستوم انتخاب شده باشد 
        /// این فیلد پر میشود
        /// </summary>
        public int? Width { get; set; }


        /// <summary>
        /// نوع رنگ
        /// </summary>
        public int? Color { get; set; }

        /// <summary>
        /// نوع کاغذی که باید روی آن چاپ بشود
        /// </summary>
        public PaperMaterialSSOT PaperMaterial { get; set; }


        /// <summary>
        /// نوع چسب
        /// </summary>
        public int? BindingType { get; set; }

        /// <summary>
        /// تعداد منگه
        /// درصورتی این فیلد پر میشود که منگنه انتخاب شده باشد
        /// </summary>
        public int? BindingNumber { get; set; }

        
        /// <summary>
        /// درصورتی که کتاب باشد این فیلد پر می شود 
        /// از این فیلد برای جلد اصلی کتاب استفاده می شود
        /// </summary>
        public string BookCover { get; set; }

        public int? BookPageNumber { get; set; }


        /// <summary>
        /// آدرس کتاب یا صفحه مورد نظر
        /// </summary>
        public string BookOrSeet { get; set; }


        public int? BookCoverColor { get; set; }
        public int? BookCoverMaterial { get; set; }

        /// <summary>
        /// اولویت این زیر پروژه
        /// </summary>
        public PrioritySSOT Priority { get; set; }


        /// <summary>
        /// شماره سازمان مورد نظر
        /// </summary>
        public int OrganizationId { get; set; }




        #region Price

        //public string PriceEachPage { get; set; }
        //public string PricePages { get; set; }



        public int NumOfBinding { get; set; } = 0;
        public int NumOfPrinting { get; set; } = 0;
        public int NumOfCovering { get; set; } = 0;



        public SubProjectRoutineStatusSSOT Status { get; set; } = SubProjectRoutineStatusSSOT.Nothing;


        #endregion

        #region Relation

        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }

        

        #endregion

    }
}
