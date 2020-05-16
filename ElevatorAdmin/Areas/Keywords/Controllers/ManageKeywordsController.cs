using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.CustomAttributes;
using Core.Utilities;
using DataLayer.ViewModels.Keyword;
using Microsoft.AspNetCore.Mvc;
using Service.Repos;
using Service.Repos.User;
using WebFramework.Authenticate;
using WebFramework.Base;

namespace PrintingSolutionAdmin.Areas.Keywords.Controllers
{
    [Area("Keywords")]
    [ControllerRole("Manage Keywords")]
    public class ManageKeywordsController : BaseAdminController
    {
        private readonly KeywordsRepository _keywordsRepository;

        public ManageKeywordsController(KeywordsRepository keywordsRepository, UsersAccessRepository usersAccessRepository)
            :base(usersAccessRepository)
        {
            _keywordsRepository = keywordsRepository;
        }

        [ActionRole("List Keywords")]
        [HasAccess]
        public async Task<IActionResult> Index(KeywordsSearchViewModel searchModel)
        {
            var model = await _keywordsRepository.LoadAsyncCount(
               this.CurrentPage,
               this.PageSize,
               searchModel);

            this.TotalNumber = model.Item1;

            ViewBag.SearchModel = searchModel;

            return View(model.Item2);
        }

        [ActionRole("Insert Keyword")]
        [HasAccess]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(KeywordsCreateViewModel vm)
        {
            await _keywordsRepository.MapAddAsync(vm);

            TempData.AddResult(SweetAlertExtenstion.Ok());

            return RedirectToAction(nameof(Index));
        }


        [ActionRole("Update Keyword")]
        [HasAccess]
        public IActionResult Update(int id)
        {
            var model = _keywordsRepository.GetById(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(KeywordsUpdateViewModel vm)
        {
            await _keywordsRepository.MapUpdateAsync(vm , vm.Id);

            TempData.AddResult(SweetAlertExtenstion.Ok());

            return RedirectToAction(nameof(Index));
        }

        [ActionRole("Change Status")]
        [HasAccess]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            await _keywordsRepository.ChangeStatus(id);

            return RedirectToAction(nameof(Index));
        }

        //[ActionRole("حذف کلیدواژه ها")]
        //[HasAccess]
        //public IActionResult Delete(int id)
        //{

        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPost]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    return RedirectToAction(nameof(Index));
        //}
    }
}