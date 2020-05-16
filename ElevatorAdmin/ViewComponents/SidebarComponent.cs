using Core.Utilities;
using DataLayer.ViewModels.SideBar;
using Microsoft.AspNetCore.Mvc;
using Service.Repos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ElevatorAdmin.ViewComponents
{
    public class SidebarComponent : ViewComponent
    {
        private readonly UsersAccessRepository _usersAccessRepository;
        private readonly UsersRoleRepository _usersRoleRepository;
        public SidebarComponent(UsersAccessRepository usersAccessRepository
            , UsersRoleRepository usersRoleRepository)
        {
            _usersAccessRepository = usersAccessRepository;
            _usersRoleRepository = usersRoleRepository;
        }


        public IViewComponentResult Invoke()
        {
            List<SidebarViewModel> items = new List<SidebarViewModel>();

            items.Add(new SidebarViewModel { Controller = "Home", Action = "Index", Title = "Dashboard", Icon= "mdi mdi-desktop-mac-dashboard" });
            items.Add(new SidebarViewModel { Controller = "Home", Action = "Profile", Title = "Profile", Icon= "mdi mdi-shield-account-outline" });
            items.Add(new SidebarViewModel { Controller = "UserManage", Action = "Index", Title = "Users", Icon = "mdi mdi-home-account" });
            items.Add(new SidebarViewModel { Controller = "RoleManage", Action = "Index", Title = "Roles", Icon = "mdi mdi-google-circles-extended" });
            items.Add(new SidebarViewModel { Area = "Admin", Controller = "ManageSiteSetting", Action = "EditeSiteInfo", Title = "Site Setting", Icon = "mdi mdi-settings-outline" });
            items.Add(new SidebarViewModel { Area = "Admin", Controller = "ManageProjectA", Action = "Calendar", Title = "Calendar", Icon = "mdi mdi-calendar-clock" });
            items.Add(new SidebarViewModel { Area = "UserAdminCutomer", Controller = "ManageProject", Action = "Index", Title = "Project", Icon = "mdi mdi-wallet-travel" });
            items.Add(new SidebarViewModel { Area = "Customer", Controller = "ManageProjectC", Action = "Index", Title = "Project", Icon = "mdi mdi-wallet-travel" });
            items.Add(new SidebarViewModel { Area = "Admin", Controller = "ManageProjectA", Action = "Index", Title = "Project", Icon = "mdi mdi-wallet-travel" });
            items.Add(new SidebarViewModel { Area = "Employee", Controller = "ManageTaskCovering", Action = "Index", Title = "Tasks", Icon = "mdi mdi-wallet-travel" });
            items.Add(new SidebarViewModel { Area = "Employee", Controller = "ManageTaskPrinting", Action = "Index", Title = "Tasks", Icon = "mdi mdi-wallet-travel" });
            items.Add(new SidebarViewModel { Area = "Employee", Controller = "ManageTaskBinding", Action = "Index", Title = "Tasks", Icon = "mdi mdi-wallet-travel" });
            items.Add(
                new SidebarViewModel
                {
                    Controller = "",
                    Action = "",
                    Title = "Organization",
                    Icon = "mdi mdi-office-building",
                    CollapsName = "ManageOrganization",
                    Childs = new List<SidebarChildViewModel> {
                        new SidebarChildViewModel {Area = "Organization", Controller = "ManageOrganization", Action = "Index", Title = "Manage Organization" },
                        new SidebarChildViewModel {Area = "Organization", Controller = "ManageUserOrganization", Action = "Index", Title = "Manage User Organization" },
                    }
                });
            items.Add(new SidebarViewModel { Area = "SlideShow", Controller = "ManageSlideShow", Action = "Index", Title = "SlideShow", Icon = "mdi mdi-solar-panel" });

            

            

            items.Add(
                new SidebarViewModel {Controller = "", Action = "", Title = "News", Icon = "mdi mdi-newspaper-variant-multiple-outline", CollapsName="ManageNews",
                    Childs = new List<SidebarChildViewModel> {
                        new SidebarChildViewModel {Area = "News", Controller = "ManageNews", Action = "Index", Title = "Manage News" },
                        new SidebarChildViewModel {Area = "NewsGroup", Controller = "ManageNewsGroup", Action = "Index", Title = "Manage Group" },
                    }
                });

            items.Add(
                new SidebarViewModel
                {
                    CollapsName="FAQ",
                    Controller = "",
                    Action = "",
                    Title = "FAQ",
                    Icon = "mdi mdi-comment-question-outline",
                    Childs = new List<SidebarChildViewModel> {
                        new SidebarChildViewModel {Area = "FAQ", Controller = "ManageFAQ", Action = "Index", Title = "Manage FAQ" },
                        new SidebarChildViewModel {Area = "FaqGroup", Controller = "ManageFaqGroup", Action = "Index", Title = "Manage Group" },
                        
                    }
                }
                );


            //ViewBag.Controller = controller;
            //ViewBag.Action = action;
            //ViewBag.Icon = icon;
            //ViewBag.Title = title;

            return View(items);
        }
    }
}
