using DataLayer.Entities;
using DataLayer.Entities.Users;
using DataLayer.SSOT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.DTO.ProjectAndSubProject.ProjectDTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }

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

        public int UserId { get; set; }


        public ProjectStatusSSOT Status { get; set; }

        public string Address { get; set; }

        public double? lat { get; set; }
        public double? lng { get; set; }

        #region Relation

        [ForeignKey(nameof(OrganizationId))]
        public virtual Organization Organization { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual Users User { get; set; }

        #endregion
    }
}
