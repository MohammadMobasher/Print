using DataLayer.Entities.Common;
using DataLayer.SSOT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class Project : BaseEntity<int>
    {
        /// <summary>
        /// نام پروژه مورد نظر
        /// </summary>
        [StringLength(200)]
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// شماره سازمانی که یک پروژه تعریف کرده است
        /// </summary>
        public int OrganizationId { get; set; }

        /// <summary>
        /// زمانی که این درخواست  ثبت شده است
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// شماره کاربریشخصی که این پروژه را تعریف کرده است
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// آیا این پروژه پرداخت شده است
        /// </summary>
        public bool IsPayed { get; set; } = false;


        [StringLength(500)]
        public string Address { get; set; }

        public double? lat { get; set; }
        public double? lng { get; set; }


        /// <summary>
        /// وضعیت
        /// با استفاده از این فیلد می‌توانیم این موضوع که الان این پروژه دست کدام بخش است را مدیریت کنیم
        /// </summary>
        public ProjectStatusSSOT Status { get; set; } = ProjectStatusSSOT.Customer;



        #region Relation

        [ForeignKey(nameof(OrganizationId))]
        public virtual Organization Organization { get; set; }


        [ForeignKey(nameof(UserId))]
        public virtual Users.Users User { get; set; }

        #endregion
    }
}
