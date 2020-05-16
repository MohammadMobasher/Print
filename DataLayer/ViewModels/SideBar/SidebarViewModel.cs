using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels.SideBar
{
    public class SidebarViewModel
    {
        /// <summary>
        /// از این ویژگی، زمانی استفاده می شود که زیر مجموعه داشته باشیم
        /// و باید نام زیر مجموعه را در این فیلد قرار دیهیم تا بتوانیم آن را باز و بسته کنیم
        /// </summary>
        public string CollapsName { get; set; }
        public string Area { get; set; } = string.Empty;
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; } = "zmdi-view-dashboard";
        public List<SidebarChildViewModel> Childs { get; set; } = null;

    }


    public class SidebarChildViewModel
    {
        public string Area { get; set; } = string.Empty;
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; } = "zmdi-view-dashboard";

    }
}