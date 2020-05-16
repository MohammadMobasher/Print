using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.CustomAttributes;
using DataLayer.ViewModels.Bill;
using Microsoft.AspNetCore.Mvc;
using Service.Repos;
using Service.Repos.Organizations;
using Service.Repos.ProjectAndSubProject;
using Service.Repos.User;
using WebFramework.Authenticate;
using WebFramework.Base;

namespace PrintingSolutionAdmin.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ControllerRole("Manage Bill for admin")]
    public class ManageBillController : BaseAdminController
    {
        private readonly ProjectRepository _projectRepository;
        private readonly UserOrganizationRepository _userOrganizationRepository;
        private readonly SubProjectRepository _subProjectRepository;
        private readonly OrganizationRepository _organizationRepository;
        private readonly BillRepository _billRepository;

        public ManageBillController(UsersAccessRepository usersAccessRepository,
            ProjectRepository projectRepository,
            UserOrganizationRepository userOrganizationRepository,
            SubProjectRepository subProjectRepository,
            OrganizationRepository organizationRepository,
            BillRepository billRepository) : base(usersAccessRepository)
        {
            _projectRepository = projectRepository;
            _userOrganizationRepository = userOrganizationRepository;
            _subProjectRepository = subProjectRepository;
            _organizationRepository = organizationRepository;
            _billRepository = billRepository;
        }


        [ActionRole("Bill List")]
        [HasAccess]
        public async Task<IActionResult> Index(BillSearchViewModel searchModel)
        {
            //ViewBag.Organizations = await _organizationRepository.GetAllMapAsync<OrganizationIdTitleDTO>();

            var model = await _billRepository.LoadAsyncCount(
                this.CurrentPage,
                this.PageSize,
                searchModel);

            this.TotalNumber = model.Item1;
            ViewBag.SearchModel = searchModel;

            return View(model.Item2);
        }


        [ActionRole("Bill List for project")]
        [HasAccess]
        public async Task<IActionResult> ProjectBills(int id)
        {
            var model = await _billRepository.GetBillsByProjectId(id);
            return View(model);
        }

    }
}