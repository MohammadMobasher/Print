using DataLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class UserOrganization : BaseEntity<int>
    {

        public int UserId { get; set; }

        public int OrganizationId { get; set; }


        #region Relation

        [ForeignKey(nameof(UserId))]
        public virtual Users.Users Users { get; set; }


        [ForeignKey(nameof(OrganizationId))]
        public virtual Organization Organization { get; set; }

        #endregion

    }
}
