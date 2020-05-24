using DataLayer.SSOT;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels.ProjectAndSubProject.SubProjectViewModel
{
    public class SubProjectUpdateViewModel
    {

        public int Id { get; set; }

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

        /// <summary>
        /// زمان پیشنهادی برای تحویل کرفتن این آیتم
        /// </summary>
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
        public IFormFile BookCoverAddress { get; set; }


        /// <summary>
        /// آدرس کتاب یا صفحه مورد نظر
        /// </summary>
        public string BookOrSeet { get; set; }
        public IFormFile BookOrSeetAddress { get; set; }


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



        #region خدمات کلی که این شرکت ارائه میدهد

        public bool HasPrint { get; set; }
        public bool HasCover { get; set; }
        public bool HasCut { get; set; }
        public bool HasDeliver { get; set; }
        public bool HasBinding { get; set; }

        #endregion

    }
}
