using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.CustomAttributes;
using Core.Utilities;
using DataLayer.DTO;
using DataLayer.DTO.Organizations;
using DataLayer.DTO.UserDTO;
using DataLayer.ViewModels;
using DataLayer.ViewModels.UserOrganization;
using Microsoft.AspNetCore.Mvc;
using Service.Repos.Organizations;
using Service.Repos.User;
using WebFramework.Authenticate;
using WebFramework.Base;

namespace PrintingSolutionAdmin.Areas.Organization.Controllers
{
    [Area("Organization")]
    [ControllerRole("ManageUserOrganization")]
    public class ManageUserOrganizationController : BaseAdminController
    {
        private readonly UserOrganizationRepository _userOrganizationRepository;
        private readonly OrganizationRepository _organizationRepository;
        private readonly UserRepository _userRepository;

        public ManageUserOrganizationController(UsersAccessRepository usersAccessRepository,
            UserOrganizationRepository userOrganizationRepository,
            OrganizationRepository organizationRepository,
            UserRepository userRepository
            ) : base(usersAccessRepository)
        {
            _userOrganizationRepository = userOrganizationRepository;
            _organizationRepository = organizationRepository;
            _userRepository = userRepository;
        }

        [ActionRole("List Items")]
        [HasAccess]
        public async Task<IActionResult> Index(UserOrganizationSearchViewModel searchModel)
        {

            var model = await _userOrganizationRepository.LoadAsyncCount(
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
            ViewBag.Organization = await _organizationRepository.GetAllMapAsync<OrganizationIdTitleDTO>();
            ViewBag.Users = await _userRepository.GetAllMapAsync<UserIdTitleDTO>();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(UserOrganizationInsertViewModel model)
        {

            TempData.AddResult(await _userOrganizationRepository.AddAsync<UserOrganizationInsertViewModel>(model));

            return RedirectToAction("Index");
        }

        #endregion


        //#region ویرایش
        //[ActionRole("Update")]
        //[HasAccess]
        //public async Task<IActionResult> Update(int Id)
        //{
        //    ViewBag.Organization = await _organizationRepository.GetAllMapAsync<OrganizationIdTitleDTO>();
        //    ViewBag.Users = await _userRepository.GetAllMapAsync<UserIdTitleDTO>();
        //    var result = await _userOrganizationRepository.GetByIdAsync(Id);
        //    return View(result);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Update(UserOrganizationUpdateViewModel model)
        //{
        //    var result = await _userOrganizationRepository.UpdateAsync(model);

        //    TempData.AddResult(result);

        //    return RedirectToAction("Index");
        //}

        //#endregion


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
            TempData.AddResult(await _userOrganizationRepository.DeleteAsync(model.Id));

            return RedirectToAction("Index");
        }

        #endregion
    }
}