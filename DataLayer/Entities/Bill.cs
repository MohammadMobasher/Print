using DataLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class Bill : BaseEntity<int>
    {

        public int SubProjectId { get; set; }

        public double? PriceEachPage { get; set; }
        public double? SumPriceEachPage { get; set; }
        public int? NumberOfPage { get; set; }


        public double? PriceEachCover { get; set; }
        public double? SumPriceEachCover { get; set; }

        
        public double? PriceDelivery { get; set; }


        public double? SumPrice { get; set; }


        public bool IsPayed { get; set; } = false;

        public DateTime? Created { get; set; } = DateTime.Now;


        #region relation

        [ForeignKey(nameof(SubProjectId))]
        public virtual SubProject SubProject { get; set; }

        #endregion

    }
}
