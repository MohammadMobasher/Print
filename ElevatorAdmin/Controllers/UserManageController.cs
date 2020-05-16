using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Core.CustomAttributes;
using Core.Utilities;
using DataLayer.DTO.UserDTO;
using DataLayer.Entities.Users;
using DataLayer.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Repos.User;
using WebFramework.Authenticate;
using WebFramework.Base;
using WebFramework.SmsManage;

using Microsoft.AspNetCore.Http;
using DataLayer.DTO.RolesDTO;
using System;
using Service.Repos.Organizations;
using DataLayer.ViewModels.UserOrganization;
using DataLayer.DTO.Organizations;

namespace ElevatorAdmin.Controllers
{
    [ControllerRole("Manage User")]
    public class UserManageController : BaseAdminController
    {
        private readonly UserRepository _userRepository;
        private readonly UserManager<Users> _userManager;
        private readonly UsersRoleRepository _usersRoleRepository;
        private readonly RoleRepository _roleRepository;
        private readonly SmsService _smsService;
        private readonly UserOrganizationRepository _userOrganizationRepository;
        private readonly OrganizationRepository _organizationRepository;

        public UserManageController
            (UserRepository userRepository,
            UserManager<Users> userManager

            , UsersRoleRepository usersRoleRepository
            , RoleRepository roleRepository
            , SmsService smsService
            , UsersAccessRepository usersAccessRepository,
            UserOrganizationRepository userOrganizationRepository,
            OrganizationRepository organizationRepository) : base(usersAccessRepository)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _usersRoleRepository = usersRoleRepository;
            _roleRepository = roleRepository;
            _smsService = smsService;
            _userOrganizationRepository = userOrganizationRepository;
            _organizationRepository = organizationRepository;
        }

        [ActionRole("User List")]
        [HasAccess]
        public async Task<IActionResult> Index(UsersSearchViewModel searchModel)
        {

            var model = await _userRepository.LoadAsyncCount(
                this.CurrentPage,
                this.PageSize,
                searchModel);

            this.TotalNumber = model.Item1;

            ViewBag.SearchModel = searchModel;

            return View(model.Item2);

        }


        


        #region ثبت کاربر جدید 
        [ActionRole("Insert")]
        [HasAccess]
        public async Task<IActionResult> NewUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewUser(RegisterUserAdminViewModel vm)
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
                var userResultPhoneNumber = await _userRepository.GetByConditionAsync(x => x.PhoneNumber == vm.PhoneNumber);
                if (userResultPhoneNumber == null)
                {
                    var resultCreatUser = await _userManager.CreateAsync(user, vm.Password);
                    // درصورتیکه کاربر مورد نظر با موفقیت ثبت شد آن را لاگین میکنیم
                    if (resultCreatUser.Succeeded)
                    {
                        TempData.AddResult(SweetAlertExtenstion.Ok());
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData.AddResult(SweetAlertExtenstion.Error("کاربری با این شماره تلفن از قبل وجود دارد"));
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

        #region دسترسی دادن به کاربران


        [ActionRole("Access Level")]
        [HasAccess]
        public IActionResult SetRole(int id)
        {
            // لیست تمامی نقش های تعریف شده در سایت
            ViewBag.Roles = _roleRepository.TableNoTracking.ToList();
            //  نقش کاربر انتخاب شده
            var userRole = _usersRoleRepository.TableNoTracking.FirstOrDefault(a => a.UserId == id);

            ViewBag.UserId = id;

            return View(userRole);
        }

        [HttpPost]
        public IActionResult SetRole(SetUserRoleViewModel vm)
        {
            var swMessage = _usersRoleRepository.SetRole(vm);

            TempData.AddResult(swMessage);

            return RedirectToAction(nameof(Index));
        }


        #endregion

        #region ویرایش رمز عبور

        [ActionRole("Change Password")]
        [HasAccess]
        public IActionResult EditPassword(int id) => View(id);

        [HttpPost]
        public async Task<IActionResult> EditPassword(AdminSetPasswordViewModel vm)
        {
            var sweetMessage = await _userRepository.AdminChangePassword(vm);

            TempData.AddResult(sweetMessage);

            return RedirectToAction(nameof(Index));
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

        #region تغییر عکس کاربر

        [AllowAccess]
        public async Task<IActionResult> ChangeUserPic()
        {
            Users user = await _userRepository.GetByIdAsync(this.UserId);

            return View(model: user.ProfilePic);
        }

        [HttpPost]
        [AllowAccess]
        public async Task<IActionResult> ChangeUserPic(IFormFile ProfilePic)
        {
            if (ProfilePic != null)
            {
                await _userRepository.UpdateProfilePic(this.UserId, ProfilePic);
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion

        

        #region SetOrganization

        [HasAccess]
        [ActionRole("Set Organization")]
        public async Task<IActionResult> SetOrganization(int id)
        {
            ViewBag.UserId = id;
            var model = await _organizationRepository.GetAllMapAsync<OrganizationIdTitleDTO>();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SetOrganization(UserOrganizationInsertViewModel vm)
        {
            TempData.AddResult(await _userOrganizationRepository.AddAsync<UserOrganizationInsertViewModel>(vm));
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}