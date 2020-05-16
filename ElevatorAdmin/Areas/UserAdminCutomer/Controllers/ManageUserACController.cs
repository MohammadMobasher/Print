using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.CustomAttributes;
using Core.Utilities;
using DataLayer.DTO.Organizations;
using DataLayer.Entities.Users;
using DataLayer.ViewModels.AdminCustomerUser;
using DataLayer.ViewModels.User;
using DataLayer.ViewModels.UserOrganization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Repos.Organizations;
using Service.Repos.User;
using WebFramework.Authenticate;
using WebFramework.Base;

namespace PrintingSolutionAdmin.Areas.UserAdminCutomer.Controllers
{
    [Area("UserAdminCutomer")]
    [ControllerRole("Manage user for admin customer")]
    public class ManageUserACController : BaseAdminController
    {
        private readonly UserOrganizationRepository _userOrganizationRepository;
        private readonly OrganizationRepository _organizationRepository;
        private readonly UserRepository _userRepository;
        private readonly UserManager<Users> _userManager;

        public ManageUserACController(UsersAccessRepository usersAccessRepository,
            UserOrganizationRepository userOrganizationRepository,
            OrganizationRepository organizationRepository,
             UserRepository userRepository,
             UserManager<Users> userManager
             ) : base(usersAccessRepository)
        {
            _userOrganizationRepository = userOrganizationRepository;
            _organizationRepository = organizationRepository;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        [ActionRole("User List")]
        [HasAccess]
        public async Task<IActionResult> Index(UsersAdminCustomerSearchViewModel searchModel)
        {

            ViewBag.organizations = await _userOrganizationRepository.GetOrganizationFullByUserId(this.UserId);

            var model = await _userRepository.LoadAsyncForAdminCustomerCount(
                this.UserId,
                this.CurrentPage,
                this.PageSize,
                searchModel);

            this.TotalNumber = model.Item1;

            ViewBag.SearchModel = searchModel;

            return View(model.Item2);

        }


        #region Insert
        [ActionRole("Insert")]
        [HasAccess]
        public async Task<IActionResult> Insert()
        {
            var model = await _userOrganizationRepository.GetOrganizationFullByUserId(this.UserId);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Insert(RegisterUserByAdminCustomerViewModel vm)
        {

            if (vm.Password != vm.RePassword)
            {
                TempData.AddResult(SweetAlertExtenstion.Error("کلمه عبور با تکرار آن یکسان نیست"));
                return RedirectToAction("Index");
            }

            var user = AutoMapper.Mapper.Map<Users>(vm);
            user.CreateDate = DateTime.Now;
            user.IsActive = true;



            // درصورتی که چنین کاربری از قبل وجود نداشته باشد
            var userResult = await _userRepository.GetByConditionAsync(x => x.UserName == vm.UserName);


            if (userResult == null)
            {
                var userResultPhoneNumber = await _userRepository.GetByConditionAsync(x => x.PhoneNumber == vm.PhoneNumber || x.Email == vm.Email);
                if (userResultPhoneNumber == null)
                {
                    var resultCreatUser = await _userManager.CreateAsync(user, vm.Password);
                    // درصورتیکه کاربر مورد نظر با موفقیت ثبت شد آن را لاگین میکنیم
                    if (resultCreatUser.Succeeded)
                    {
                        var userResult1 = await _userRepository.GetByConditionAsync(x => x.UserName == vm.UserName);
                        await _userOrganizationRepository.AddAsync<UserOrganizationInsertViewModel>(new UserOrganizationInsertViewModel {
                            UserId = userResult1.Id,
                            OrganizationId = vm.OrganizationId
                        });

                        TempData.AddResult(SweetAlertExtenstion.Ok());
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData.AddResult(SweetAlertExtenstion.Error("کاربری با این شماره تلفن یا این ایمیل از قبل وجود دارد"));
                    return RedirectToAction("Index");
                }
                //else
                //{
                //    if (resultCreatUser.Errors.Any(a => a.Code.Contains("DuplicateEmail")))
                //    {
                //        ViewBag.ErrorMessages = "ایمیل وارد شده تکراری می باشد";
                //    }

                //    TempData.AddResult(SweetAlertExtenstion.Error("عملیات با خطا مواجه شد لطفا مجددا تلاش نمایید"));
                //    return View(model);
                //}
            }
            else
            {
                TempData.AddResult(SweetAlertExtenstion.Error("چنین کاربری از قبل وجود دارد"));
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        #endregion


        #region فعال/غیرفعال کردن کاربر

        [ActionRole("Active / DeActive")]
        [HasAccess]

        public async Task<IActionResult> UserChangeStatus(int id)
        {
            var swMessage = await _userRepository.ChangeUserActivity(id);

            TempData.AddResult(swMessage);

            return RedirectToAction(nameof(Index));
        }

        #endregion


        #region Change Organization
        [ActionRole("Change Organization")]
        [HasAccess]
        public async Task<IActionResult> ChangeOrganization(int id)
        {
            ViewBag.HasOrganization = await _userOrganizationRepository.GetOrganizationFullByUserId(id);
            ViewBag.UserId = id;

            var model = await _userOrganizationRepository.GetOrganizationFullByUserId(this.UserId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeOrganization(List<UserOrganizationInsertViewModel> vm, int userId)
        {
            vm.ForEach(x => x.UserId = userId);
            TempData.AddResult(await _userOrganizationRepository.UpdateOrganizationForUser(vm, userId));
            return RedirectToAction("Index");
        }

        #endregion
    }
}