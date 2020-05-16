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

namespace PrintingSolutionAdmin.Areas.Customer.Controllers
{
    [Area("Customer")]
    [ControllerRole("Manage Tasks for customer")]
    public class ManageSubProjectCController : BaseAdminController
    {
        private readonly SubProjectRepository _subProjectRepository;
        private readonly ProjectRepository _projectRepository;
        private readonly BillRepository _billRepository;

        public ManageSubProjectCController(UsersAccessRepository usersAccessRepository,
            SubProjectRepository subProjectRepository,
            ProjectRepository projectRepository,
            BillRepository billRepository) : base(usersAccessRepository)
        {
            _subProjectRepository = subProjectRepository;
            _projectRepository = projectRepository;
            _billRepository = billRepository;
        }

        [ActionRole("Task List")]
        [HasAccess]
        public async Task<IActionResult> Index(int id, SubProjectSearchViewModel searchModel)
        {
            //ViewBag.Organizations = await _userOrganizationRepository.GetOrganizationFullByUserId(this.UserId);

            var model = await _subProjectRepository.LoadCustomerAsyncCount(
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


        //#region Bills

        ///// <summary>
        ///// Send Project to another step
        ///// </summary>
        ///// <param name="Id">Project Id</param>
        ///// <returns></returns>
        //[HasAccess]
        //[ActionRole("Bills")]
        //public async Task<IActionResult> Bills(int Id, int ProjectId)
        //{
        //    var model = await _subProjectRepository.GetByIdAsync(Id);
        //    ViewBag.Project = await _projectRepository.GetByIdAsync(model.ProjectId);
        //    ViewBag.Bill = await _billRepository.GetBySubProjectIdAsync(Id);
        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Bills(BillInsertUpdateViewModel model)
        //{

        //    if (model.Id != 0)
        //        TempData.AddResult(await _billRepository.UpdateAsync<BillInsertUpdateViewModel>(model));
        //    else
        //        TempData.AddResult(await _billRepository.AddAsync<BillInsertUpdateViewModel>(model));

        //    return RedirectToAction("Index", new { id = model.ProjectId });
        //}

        //#endregion


    }
}