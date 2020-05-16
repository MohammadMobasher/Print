using DataLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class SiteSetting : BaseEntity<int>
    {
        [StringLength(100)]
        public string SiteName { get; set; }
        [StringLength(700)]
        public string Logo { get; set; }
        [StringLength(700)]
        public string BackGroudLoginPage { get; set; }



    }
}
