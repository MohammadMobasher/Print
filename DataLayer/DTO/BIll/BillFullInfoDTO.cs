using DataLayer.SSOT;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DTO.BIll
{
    public class BillFullInfoDTO
    {

        #region BillInfo
        public int Id { get; set; }

        public double? PriceEachPage { get; set; }
        public double? SumPriceEachPage { get; set; }
        public int? NumberOfPage { get; set; }


        public double? PriceEachCover { get; set; }
        public double? SumPriceEachCover { get; set; }


        public double? PriceDelivery { get; set; }


        public double? SumPrice { get; set; }


        public bool IsPayed { get; set; } = false;

        public DateTime? Created { get; set; } = DateTime.Now;

        #endregion


        #region ProjectInfo

        public string ProjectTitle { get; set; }
        public int ProjectId { get; set; }

        #endregion


        #region SubProjectInfo

        public string SubProjectTitle { get; set; }
        public int SubProjectId { get; set; }

        public ProjectTypeSSOT SubProjectType { get; set; }

        public ColorSSOT? Color { get; set; }


        public int Number { get; set; }
        public SizeSSOT? Size { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public PaperMaterialSSOT PaperMaterial { get; set; }
        public BindingSSOT? BindingType { get; set; }
        public BindingSSOT? BindingNumber { get; set; }
        public ColorSSOT? BookCoverColor { get; set; }
        public BookCoverMaterialSSOT? BookCoverMaterial { get; set; }
        public PrioritySSOT Priority { get; set; }

        #endregion

    }
}
