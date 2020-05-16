using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels
{
    public class BillInsertUpdateViewModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int SubProjectId { get; set; }

        public double? PriceEachPage { get; set; }
        public double? SumPriceEachPage { get; set; }
        public int? NumberOfPage { get; set; }


        public double? PriceEachCover { get; set; }
        public double? SumPriceEachCover { get; set; }


        public double? PriceDelivery { get; set; }


        public double? SumPrice { get; set; }

    }
}
