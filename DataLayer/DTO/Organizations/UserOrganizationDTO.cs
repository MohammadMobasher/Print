using DataLayer.Entities;
using DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.DTO.Organizations
{
    public class UserOrganizationDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int OrganizationId { get; set; }


        #region Relation

        [ForeignKey(nameof(UserId))]
        public virtual Users Users { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        public virtual Organization Organization { get; set; }

        #endregion

    }
}
