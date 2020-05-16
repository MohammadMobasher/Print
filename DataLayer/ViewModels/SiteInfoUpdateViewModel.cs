using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.ViewModels
{
    public class SiteInfoUpdateViewModel
    {

        [StringLength(100)]
        public string SiteName { get; set; }
        [StringLength(700)]
        public string Logo { get; set; }
        [StringLength(700)]
        public string BackGroudLoginPage { get; set; }
        public IFormFile BackGroudLoginPageFile { get; set; }
        public IFormFile LogoFile { get; set; }

    }
}
