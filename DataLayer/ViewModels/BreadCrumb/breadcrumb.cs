using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels.BreadCrumb
{
    public class Breadcrumb
    {

        /// <summary>
        /// چیزی که باید نمایش دهیم
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// آدرس صفحه برای این آیتم
        /// </summary>
        public string Href { get; set; }

    }
}
