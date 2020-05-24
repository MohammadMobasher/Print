using DataLayer.Entities.Common;
using DataLayer.SSOT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class SubProjectDetails:BaseEntity
    {
        public int? SubProjectId { get; set; }

        public ProjectOperationSSOT Status{ get; set; }

        public int? PrinterId { get; set; }

        public DateTime? StatusChageDate { get; set; }

        [ForeignKey(nameof(SubProjectId))]
        public virtual SubProject SubProject { get; set; }

        [ForeignKey(nameof(PrinterId))]
        public virtual Printer Printer { get; set; }
    }
}
