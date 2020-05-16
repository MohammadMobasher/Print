using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.CustomAttributes;
using Core.Utilities;
using DataLayer.Entities;
using DataLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Repos;
using Service.Repos.User;
using WebFramework.Authenticate;
using WebFramework.Base;

namespace PrintingSolutionAdmin.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ControllerRole("Manage Site Setting")]
    public class ManageSiteSettingController : BaseAdminController
    {
        private readonly SiteSettingRepository _siteSettingRepository;

        public ManageSiteSettingController(UsersAccessRepository usersAccessRepository,
            SiteSettingRepository siteSettingRepository) : base(usersAccessRepository)
        {
            _siteSettingRepository = siteSettingRepository;
        }

        [ActionRole("Edit Site Setting")]
        [HasAccess]
        public async Task<IActionResult> EditeSiteInfo()
        {
            var model = await _siteSettingRepository.TableNoTracking.FirstOrDefaultAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditeSiteInfo(SiteInfoUpdateViewModel siteSetting)
        {
            TempData.AddResult(await _siteSettingRepository.UpdateInfo(siteSetting));
            return RedirectToAction("EditeSiteInfo");
        }
    }
}