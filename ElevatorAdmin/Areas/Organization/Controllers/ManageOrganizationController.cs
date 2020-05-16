using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.CustomAttributes;
using Core.Utilities;
using DataLayer.DTO;
using DataLayer.DTO.Organizations;
using DataLayer.ViewModels;
using DataLayer.ViewModels.Organizations;
using Microsoft.AspNetCore.Mvc;
using Service.Repos.Organizations;
using Service.Repos.User;
using WebFramework.Authenticate;
using WebFramework.Base;

namespace PrintingSolutionAdmin.Areas.Organization.Controllers
{
    [Area("Organization")]
    [ControllerRole("ManageOrganization")]
    public class ManageOrganizationController : BaseAdminController
    {
        private readonly OrganizationRepository _organizationRepository;

        public ManageOrganizationController(UsersAccessRepository usersAccessRepository,
            OrganizationRepository organizationRepository) : base(usersAccessRepository)
        {
            _organizationRepository = organizationRepository;
        }



        [ActionRole("List Items")]
        [HasAccess]
        public async Task<IActionResult> Index(OrganizationSearchViewModel searchModel)
        {
            
            var model = await _organizationRepository.LoadAsyncCount(
                this.CurrentPage,
                this.PageSize,
                searchModel);

            this.TotalNumber = model.Item1;

            ViewBag.SearchModel = searchModel;

            return View(model.Item2);
        }


        #region ثبت
        [ActionRole("Insert")]
        [HasAccess]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(OrganizationInsertViewModel model)
        {
            TempData.AddResult(await _organizationRepository.AddAsync<OrganizationInsertViewModel>(model));

            return RedirectToAction("Index");
        }

        #endregion


        #region ویرایش
        [ActionRole("Update")]
        [HasAccess]
        public async Task<IActionResult> Update(int Id)
        {
            var result = await _organizationRepository.GetByIdAsync(Id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(OrganizationUpdateViewModel model)
        {
            var result = await _organizationRepository.UpdateAsync(model);

            TempData.AddResult(result);

            return RedirectToAction("Index");
        }

        #endregion


        #region حذف

        [ActionRole("Delete")]
        [HasAccess]
        public async Task<IActionResult> Delete(int Id)
        {

            return View(new DeleteDTO { Id = Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteViewModel model)
        {
            TempData.AddResult(await _organizationRepository.DeleteAsync(model.Id));

            return RedirectToAction("Index");
        }

        #endregion
    }
}