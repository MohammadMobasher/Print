using DataLayer.Entities.Users;
using DataLayer.Entities;
using DataLayer.SSOT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.DTO.ProjectAndSubProject.SubProjectDTO
{
    public class SubProjectADTO
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
        /// شماره کاربری که این زیرپروژه را تعریف کرده است
        /// </summary>
        public int UserId { get; set; }


        /// <summary>
        /// نوع زیر پروژه مورد نظر
        /// </summary>
        public ProjectTypeSSOT SubProjectType { get; set; }

        /// <summary>
        /// شماره سازمان مورد نظر
        /// </summary>
        public int OrganizationId { get; set; }


        public bool HasBill { get; set; }

        public double PriceEachPage { get; set; }
        public double SumPriceEachPage { get; set; }
        public int? NumberOfPage { get; set; }


        public double PriceEachCover { get; set; }
        public double SumPriceEachCover { get; set; }


        public double PriceDelivery { get; set; }


        public double SumPrice { get; set; }

        public int Number { get; set; }


        #region Relation

        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }


        [ForeignKey(nameof(UserId))]
        public virtual Users User { get; set; }

        #endregion

    }
}
