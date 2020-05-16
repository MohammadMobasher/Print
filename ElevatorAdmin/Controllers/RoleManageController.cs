using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Core.CustomAttributes;
using Core.Utilities;
using DataLayer.DTO;
using DataLayer.DTO.UserDTO;
using DataLayer.ViewModels;
using DataLayer.ViewModels.Role;
using DataLayer.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Repos.Basic;
using Service.Repos.User;
using WebFramework.Authenticate;
using WebFramework.Base;

namespace ElevatorAdmin.Controllers
{
    [ControllerRole("مدیریت نقش ها")]

    public class RoleManageController : BaseAdminController
    {
        private readonly RoleRepository _roleRepository;
        private readonly UsersRoleRepository _usersRoleRepository;
        private readonly BasicRepository _basicRepository;
        private readonly UsersAccessRepository _usersAccessRepository;
        

        public RoleManageController(RoleRepository roleRepository
            , UsersRoleRepository usersRoleRepository
            , BasicRepository basicRepository
            , UsersAccessRepository usersAccessRepository
            ) : base(usersAccessRepository)
        {
            _roleRepository = roleRepository;
            _usersRoleRepository = usersRoleRepository;
            _basicRepository = basicRepository;
            _usersAccessRepository = usersAccessRepository;
            
        }

        [ActionRole("لیست نقش ها")]
        [HasAccess]
        public async Task<IActionResult> Index(RolesSearchViewModel searchModel)
        {

            var model = await _roleRepository.LoadAsyncCount(
                this.CurrentPage,
                this.PageSize,
                searchModel);

            this.TotalNumber = model.Item1;

            ViewBag.SearchModel = searchModel;

            return View(model.Item2);


            //            var model = await _roleRepository.TableNoTracking.Where(a => a.NormalizedName != ImportantNames.AdminNormalTitle()).ProjectTo<RoleManageDTO>().ToListAsync();

        }

        //            var actionInfos = _basicRepository.GetControllerAndActionByCustomAttribute(asm);

        [ActionRole("ایجاد نقش جدید")]
        [HasAccess]
        public IActionResult Create()
        {
            var assembly = typeof(HomeController).Assembly;
            var controllerInfo = _basicRepository.GetAllControllerUseControllerRoleAttribute(assembly);
            controllerInfo.RemoveAll(x => x.Name == "HomeController");
            var actionInfos = _basicRepository.GetControllerAndActionByCustomAttribute(controllerInfo);

            ViewBag.ActionInfo = actionInfos;
            ViewBag.ControllerInfo = controllerInfo;

            //            var roleId= await _roleRepository.AddAsync(name, roleTitle);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(List<UserAccessSubmitViewModel> vm, RoleInsertViewModel role)
        {
            // اضافه کردن نقش جدید
            var roleId = await _roleRepository.AddRole(role);

            vm.Add(new UserAccessSubmitViewModel { Actions = new List<string> { "Index", "Profile" }, Controller = "HomeController" });

            // اضافه کردن دسترسی های نقش جاری
            _usersAccessRepository.AddAccessRole(vm, roleId);

            return RedirectToAction("Index");
        }


        [ActionRole("تنظیمات نقش")]
        [HasAccess]
        public IActionResult Edit(int id)
        {
            var assembly = typeof(HomeController).Assembly;
            var controllerInfo = _basicRepository.GetAllControllerUseControllerRoleAttribute(assembly);
            controllerInfo.RemoveAll(x => x.Name == "HomeController");

            var actionInfos = _basicRepository.GetControllerAndActionByCustomAttribute(controllerInfo);
            

            ViewBag.ActionInfo = actionInfos;
            ViewBag.ControllerInfo = controllerInfo;

            var role = _roleRepository.GetById(id);
            ViewBag.Accesss = _usersAccessRepository.TableNoTracking.Where(a => a.RoleId == role.Id).ToList();


            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(List<UserAccessSubmitViewModel> vm, RoleUpdateViewModel role)
        {
            // ویرایش کردن نقش 
            var result = await _roleRepository.UpdateRole(role);

            if (result.Succeed)
            {
                vm.Add(new UserAccessSubmitViewModel { Actions = new List<string> { "Index", "Profile" }, Controller = "HomeController" });
                // اضافه کردن دسترسی های نقش جاری
                TempData.AddResult(await _usersAccessRepository.UpdateAccessRole(vm, role.Id));
            }
            else
                TempData.AddResult(result);
            
            return RedirectToAction("Index");
        }


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
            //TODO
            // 1 => delete from UserAccess
            if (await _usersAccessRepository.RemoveAccessRole(model.Id))
            {
                // 2 => delete from userRole
                if(await _usersRoleRepository.DeleteByRoleId(model.Id))
                {
                    // 2 => delete from Role 
                    TempData.AddResult(await _roleRepository.DeleteAsync(model.Id));
                }
            }
            else
            {
                TempData.AddResult(SweetAlertExtenstion.Error());
            }

            return RedirectToAction("Index");
        }

        #endregion


    }
}