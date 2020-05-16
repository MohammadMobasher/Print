using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.CustomAttributes;
using Core.Utilities;
using DataLayer.ViewModels.ProjectAndSubProject.SubProjectViewModel;
using Microsoft.AspNetCore.Mvc;
using Service.Repos.ProjectAndSubProject;
using Service.Repos.User;
using WebFramework.Authenticate;
using WebFramework.Base;

namespace PrintingSolutionAdmin.Areas.Employee.Controllers
{
    [Area("Employee")]
    [ControllerRole("Manage Task Covering Employee")]
    public class ManageTaskCoveringController :  BaseAdminController
    {
        private readonly SubProjectRepository _subProjectRepository;
        private readonly ProjectRepository _projectRepository;

        public ManageTaskCoveringController(UsersAccessRepository usersAccessRepository,
            SubProjectRepository subProjectRepository,
            ProjectRepository projectRepository) : base(usersAccessRepository)
        {
            _subProjectRepository = subProjectRepository;
            _projectRepository = projectRepository;
        }
        [ActionRole("Task List")]
        [HasAccess]
        public async Task<IActionResult> Index(SubProjectSearchViewModel searchModel)
        {

            var model = await _subProjectRepository.LoadEmployeeCoveringAsyncCount(
                this.CurrentPage,
                this.PageSize,
                searchModel);

            this.TotalNumber = model.Item1;

            ViewBag.SearchModel = searchModel;

            return View(model.Item2);
        }


        #region New
        [ActionRole("Add item covered")]
        [HasAccess]
        public async Task<IActionResult> DoPrint(int Id)
        {
            var model = await _subProjectRepository.GetByIdAsync(Id);

            if (model.Number == model.NumOfCovering)
                return RedirectToAction("Index");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DoPrint(int numberOfDo, int subProjectId)
        {

            TempData.AddResult(await _subProjectRepository.AddDoneCovering(numberOfDo, subProjectId));
            return RedirectToAction("Index");
        }

        #endregion
    }
}