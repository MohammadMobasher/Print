using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.CustomAttributes;
using Core.Utilities;
using DataLayer.DTO;
using DataLayer.ViewModels;
using DataLayer.ViewModels.ProjectAndSubProject.SubProjectViewModel;
using Microsoft.AspNetCore.Mvc;
using Service.Repos;
using Service.Repos.ProjectAndSubProject;
using Service.Repos.User;
using WebFramework.Authenticate;
using WebFramework.Base;

namespace PrintingSolutionAdmin.Areas.UserAdminCutomer.Controllers
{
    [Area("UserAdminCutomer")]
    [ControllerRole("Manage Tasks for admin customer")]
    public class ManageSubProjectACController : BaseAdminController
    {
        private readonly SubProjectRepository _subProjectRepository;
        private readonly ProjectRepository _projectRepository;
        private readonly BillRepository _billRepository;
        private readonly KeywordsRepository _keywordsRepository;
        public ManageSubProjectACController(UsersAccessRepository usersAccessRepository,
            SubProjectRepository subProjectRepository,
            ProjectRepository projectRepository,
            BillRepository billRepository,
            KeywordsRepository keywordsRepository) : base(usersAccessRepository)
        {
            _subProjectRepository = subProjectRepository;
            _projectRepository = projectRepository;
            _billRepository = billRepository;
            _keywordsRepository = keywordsRepository;
        }

        [ActionRole("Task List")]
        [HasAccess]
        public async Task<IActionResult> Index(int id, SubProjectSearchViewModel searchModel)
        {
            //ViewBag.Organizations = await _userOrganizationRepository.GetOrganizationFullByUserId(this.UserId);

            var model = await _subProjectRepository.LoadAdminCustomerAsyncCount(
                id,
                this.CurrentPage,
                this.PageSize,
                searchModel);

            this.TotalNumber = model.Item1;

            ViewBag.SearchModel = searchModel;
            // شماره پروژه مورد نظر
            ViewBag.ProjectId = id;
            // وضعیت پروژه مورد نظر
            ViewBag.ProjectStatus = await _projectRepository.GetStatus(id);

            return View(model.Item2);
        }




        #region Insert
        [ActionRole("Insert")]
        [HasAccess]
        public async Task<IActionResult> Insert(int projectId)
        {
            // شماره پروژه مورد نظر
            ViewBag.ProjectId = projectId;
            var project = await _projectRepository.GetByIdAsync(projectId);
            // شماره سازمان مورد نظر
            ViewBag.OrganizationId = project.OrganizationId;
            // لیست کلید واژه ها
            ViewBag.Keywords = await _keywordsRepository.GetAllAsync(a => a.IsActive);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(SubProjectInsertViewModel model)
        {
            TempData.AddResult(await _subProjectRepository.AddAsync(model));

            return RedirectToAction("Index", new { id = model.ProjectId });
        }

        #endregion

        #region Update

        [ActionRole("Update")]
        [HasAccess]
        public async Task<IActionResult> Update(int Id)
        {
            var result = await _subProjectRepository.GetByIdAsync(Id);
            // شماره پروژه مورد نظر
            ViewBag.ProjectId = result.ProjectId;
            // شماره سازمان مورد نظر
            ViewBag.OrganizationId = result.OrganizationId;
            // لیست کلید واژه ها
            ViewBag.Keywords = await _keywordsRepository.GetAllAsync(a => a.IsActive);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SubProjectUpdateViewModel model)
        {
            var result = await _subProjectRepository.UpdateAsync(model);

            TempData.AddResult(result);

            return RedirectToAction("Index", new { id = model.ProjectId });
        }

        #endregion

        #region Delete

        [ActionRole("Delete")]
        [HasAccess]
        public async Task<IActionResult> Delete(int Id, int projectId)
        {
            ViewBag.ProjectId = projectId;
            return View(new DeleteDTO { Id = Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteViewModel model, int projectId)
        {

            var result = await _subProjectRepository.DeleteAsync(model.Id);
            TempData.AddResult(result);

            return RedirectToAction("Index", new { id = projectId });
        }

        #endregion

    }
}