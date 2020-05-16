using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ElevatorAdmin.Models;
using Core.CustomAttributes;
using Core.Utilities;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using WebFramework.Base;
using WebFramework.Authenticate;
using Service.Repos.User;
using DataLayer.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using DataLayer.Entities.Users;

namespace ElevatorAdmin.Controllers
{
    [ControllerRole("مدیریت داشبورد")]
    public class HomeController : BaseAdminController
    {
        private readonly UserRepository _userRepository;
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        public HomeController(
            SignInManager<Users> signInManager,
            UsersAccessRepository usersAccessRepository,
            UserRepository userRepository,
            UserManager<Users> userManager) : base(usersAccessRepository)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [ActionRole("صفحه اصلی داشبورد")]
        //[HasAccess]
        public IActionResult Index()
        {
            ViewBag.User = User?.Identity?.Name;
            return View();
        }


        #region Profile

        public async Task<IActionResult> Profile()
        {
            var model = _userRepository.TableNoTracking.FirstOrDefault(a => a.Id == this.UserId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(ProfileViewModel vm)
        {
            var user = await _userRepository.GetByIdAsync(this.UserId);

            #region 
            user.UserName = vm.UserName;
            user.NormalizedUserName = vm.NormalizedUserName;

            user.FirstName = vm.FirstName;
            user.LastName = vm.LastName;

            user.Email = vm.Email;
            user.NormalizedEmail = vm.NormalizedEmail;

            user.PhoneNumber = vm.PhoneNumber;
            #endregion

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData.AddResult(SweetAlertExtenstion.Ok());
                await _signInManager.RefreshSignInAsync(user);
            }
            else
                TempData.AddResult(SweetAlertExtenstion.Error());

            return RedirectToAction("Profile");
        }
        
        [HttpPost]
        public async Task<IActionResult> EditPassword(UserChangePasswordViewModel vm)
        {
            if (vm.newPassword != vm.conPassword)
            {
                TempData.AddResult(SweetAlertExtenstion.Error("NewPassword and Confirm not equal"));
                return RedirectToAction("Index");
            }

            var user = await _userRepository.GetByIdAsync(this.UserId);

            //if (user.PasswordHash == vm.oldPassword)
            //{

                var newVm = new AdminSetPasswordViewModel
                {
                    UserId = this.UserId,
                    Password = vm.Password
                };

                var sweetMessage = await _userRepository.AdminChangePassword(newVm);

                TempData.AddResult(sweetMessage);
            //}
            //else
            //{
            //    TempData.AddResult(SweetAlertExtenstion.Error("Old Password is incorect"));
            //}

            return RedirectToAction("Profile");
        }

        #endregion


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //[HasAccess]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAccess]
        public IActionResult Error404()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAccess]
        public IActionResult Error403()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TestFile()
        {
            return View();
        }
    }
}
