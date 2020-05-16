using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.CustomAttributes;
using Core.Utilities;
using DataLayer.DTO;
using DataLayer.DTO.ProjectAndSubProject.ProjectDTO;
using DataLayer.ViewModels;
using DataLayer.ViewModels.ProjectAndSubProject.ProjectViewModel;
using Microsoft.AspNetCore.Mvc;
using Service.Repos.Organizations;
using Service.Repos.ProjectAndSubProject;
using Service.Repos.User;
using WebFramework.Authenticate;
using WebFramework.Base;

namespace PrintingSolutionAdmin.Areas.Customer.Controllers
{
    [Area("Customer")]
    [ControllerRole("Manage Project Customer")]
    public class ManageProjectCController : BaseAdminController
    {
        private readonly ProjectRepository _projectRepository;
        private readonly UserOrganizationRepository _userOrganizationRepository;
        private readonly SubProjectRepository _subProjectRepository;

        public ManageProjectCController(UsersAccessRepository usersAccessRepository,
            ProjectRepository projectRepository,
            UserOrganizationRepository userOrganizationRepository,
            SubProjectRepository subProjectRepository) : base(usersAccessRepository)
        {
            _projectRepository = projectRepository;
            _userOrganizationRepository = userOrganizationRepository;
            _subProjectRepository = subProjectRepository;
        }


        [ActionRole("Project List")]
        [HasAccess]
        public async Task<IActionResult> Index(ProjectSearchViewModel searchModel)
        {
            ViewBag.Organizations = await _userOrganizationRepository.GetOrganizationFullByUserId(this.UserId);

            var model = await _projectRepository.LoadAsyncCountCustomer(
                UserId,
                this.CurrentPage,
                this.PageSize,
                searchModel);

            this.TotalNumber = model.Item1;
            ViewBag.SearchModel = searchModel;

            return View(model.Item2);
        }



        #region New
        [ActionRole("New Item")]
        [HasAccess]
        public async Task<IActionResult> Insert()
        {
            var model = await _userOrganizationRepository.GetOrganizationFullByUserId(this.UserId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ProjectInsertViewModel model)
        {
            //زمانی که این پروژه ساخته شده است
            model.Created = DateTime.Now;

            model.UserId = this.UserId;
            // زمانی که از اینجا یک پروژه ایجاد می شود باید وضعیت آن در حالت ادمین کاستومر قرار بگیرد
            model.Status = DataLayer.SSOT.ProjectStatusSSOT.Customer;

            TempData.AddResult(await _projectRepository.AddAsync(model));

            return RedirectToAction("Index");
        }

        #endregion


        #region Update
        [ActionRole("Update Item")]
        [HasAccess]
        public async Task<IActionResult> Update(int Id)
        {
            var model = await _userOrganizationRepository.GetOrganizationFullByUserId(this.UserId);
            ViewBag.Entity = await _projectRepository.GetByIdAsync(Id);
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Update(ProjectUpdateViewModel model)
        {
            model.UserId = this.UserId;

            var result = await _projectRepository.UpdateAsync<ProjectUpdateViewModel>(model);

            TempData.AddResult(result);

            return RedirectToAction("Index");
        }

        #endregion


        #region Delete

        [ActionRole("Delete")]
        [HasAccess]
        public async Task<IActionResult> Delete(int Id)
        {

            return View(new DeleteDTO { Id = Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteViewModel model)
        {

            // وقتی میتواند حذف کند که هیچ یک از زیر پروژه‌های دیگه  شروع نشده باشد
            var result = await _projectRepository.DeleteAsync(model.Id);
            
            TempData.AddResult(result);

            return RedirectToAction("Index");
        }

        #endregion


        #region Send

        /// <summary>
        /// Send Project to another step
        /// </summary>
        /// <param name="Id">Project Id</param>
        /// <returns></returns>
        [HasAccess]
        [ActionRole("Send Project")]
        public async Task<IActionResult> Send(int Id)
        {
            #region Has Task

            if (await _subProjectRepository.HasSubProjectByProjectId(Id) == 0)
            {
                TempData.AddResult(SweetAlertExtenstion.Error("This project has not task!\n please add some task"));
                return RedirectToAction("Index");
            }

            #endregion
            TempData.AddResult(await _projectRepository.SendProject(Id));
            return RedirectToAction("Index");
        }

        #endregion


        [HasAccess]
        [ActionRole("Summery Project")]
        public async Task<IActionResult> ProjevtSummery(int Id)
        {
            var model = await _projectRepository.GetAllTask(Id);
            return View(model);
        }


        
    }
}