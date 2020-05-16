using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.CustomAttributes;
using Microsoft.AspNetCore.Mvc;
using Service.Repos;
using Service.Repos.User;
using WebFramework.Authenticate;
using WebFramework.Base;

namespace PrintingSolutionAdmin.Areas.UserAdminCutomer.Controllers
{
    

    [Area("UserAdminCutomer")]
    [ControllerRole("Manage Bill for admin customer")]
    public class ManageBillACController : BaseAdminController
    {
        private readonly BillRepository _billRepository;


        public ManageBillACController(UsersAccessRepository usersAccessRepository,
            BillRepository billRepository) : base(usersAccessRepository)
        {
            _billRepository = billRepository;
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