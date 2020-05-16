using AutoMapper.QueryableExtensions;
using Core.Utilities;
using DataLayer.DTO.AdminCustomerUser;
using DataLayer.DTO.UserDTO;
using DataLayer.Entities;
using DataLayer.Entities.Users;
using DataLayer.SSOT;
using DataLayer.ViewModels.AdminCustomerUser;
using DataLayer.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Repos.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repos.User
{
    public class UserRepository : GenericRepository<Users>
    {
        private readonly UserManager<Users> _userManager;
        private readonly UserClaimsRepository _userClaimsRepository;
        private readonly UserOrganizationRepository _userOrganizationRepository;

        public UserRepository(DatabaseContext db) : base(db)
        {

        }
        public UserRepository(DatabaseContext db
            , UserManager<Users> userManager
            , UserClaimsRepository userClaimsRepository
            , UserOrganizationRepository userOrganizationRepository) : base(db)
        {
            _userManager = userManager;
            _userClaimsRepository = userClaimsRepository;
            _userOrganizationRepository = userOrganizationRepository;
        }

        /// <summary>
        /// لود اطلاعات برای نمایش در گیرید
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Tuple<int, List<UsersManageDTO>>> LoadAsyncCount(
            int skip = -1,
            int take = -1,
            UsersSearchViewModel model = null)
        {
            var query = Entities.ProjectTo<UsersManageDTO>();

            // نام کاربری
            if (!string.IsNullOrEmpty(model.UserName))
                query = query.Where(x => x.UserName.Contains(model.UserName));

            // ایمیل
            if (!string.IsNullOrEmpty(model.Email))
                query = query.Where(x => x.Email.Contains(model.Email));

            // شماره موبایل
            if (!string.IsNullOrEmpty(model.PhoneNumber))
                query = query.Where(x => x.PhoneNumber.Contains(model.PhoneNumber));


            // نام
            if (!string.IsNullOrEmpty(model.FirstName))
                query = query.Where(x => x.FirstName.Contains(model.FirstName));

            // نام خانوادگی
            if (!string.IsNullOrEmpty(model.LastName))
                query = query.Where(x => x.LastName.Contains(model.LastName));

            // فعال / غیرفعال
            if (model.IsActive != null)
                query = query.Where(x => x.IsActive == model.IsActive);

            if (model.IsModerator != null)
                query = query.Where(x => x.IsModerator == model.IsModerator);

            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            
            return new Tuple<int, List<UsersManageDTO>>(Count, await query.ToListAsync());
        }

        public async Task<Tuple<int, List<UsersAdminCustomerDTO>>> LoadAsyncForAdminCustomerCount(
            int userId,
            int skip = -1,
            int take = -1,
            UsersAdminCustomerSearchViewModel model = null)
        {

            /// لیست سازمان‌هایی که این کاربر به آنها دسترسی دارد
            List<int> organizationIds = await _userOrganizationRepository.GetOrganizationByUserId(userId);

            // درصورتی که این کاربر در هیچ سازمانی عضو نشده باشد
            // چیزی نداریم که به کاربر نمایش بدهیم
            if(organizationIds == null || organizationIds.Count == 0)
            {
                return new Tuple<int, List<UsersAdminCustomerDTO>>(0, new List<UsersAdminCustomerDTO>());
            }

            var query = (from user in DbContext.Users
                         where user.Id != userId

                         join userOrganization in DbContext.UserOrganization on user.Id equals userOrganization.UserId
                         where organizationIds.Contains(userOrganization.OrganizationId)

                         join organization in DbContext.Organization on userOrganization.OrganizationId equals organization.Id

                         select new UsersAdminCustomerDTO
                         {
                             Id = user.Id,
                             UserName = user.UserName,
                             FirstName = user.FirstName + " " + user.LastName,
                             LastName = user.LastName,
                             CreateDate = user.CreateDate,
                             Email = user.Email,
                             IsActive = user.IsActive,
                             IsModerator = user.IsModerator,
                             OrganizationId = organization.Id,
                             PhoneNumber = user.PhoneNumber,
                             OrganizationTitle = organization.OrganizationTitle
                         });

            // نام کاربری
            if (!string.IsNullOrEmpty(model.UserName))
                query = query.Where(x => x.UserName.Contains(model.UserName));

            // ایمیل
            if (!string.IsNullOrEmpty(model.Email))
                query = query.Where(x => x.Email.Contains(model.Email));

            // شماره موبایل
            if (!string.IsNullOrEmpty(model.PhoneNumber))
                query = query.Where(x => x.PhoneNumber.Contains(model.PhoneNumber));


            // نام
            if (!string.IsNullOrEmpty(model.FirstName))
                query = query.Where(x => x.FirstName.Contains(model.FirstName) || x.LastName.Contains(model.FirstName));


            // فعال / غیرفعال
            if (model.IsActive != null)
                query = query.Where(x => x.IsActive == model.IsActive);

            if (model.IsModerator != null)
                query = query.Where(x => x.IsModerator == model.IsModerator);

            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);


            return new Tuple<int, List<UsersAdminCustomerDTO>>(Count, await query.ToListAsync());
        }



        /// <summary>
        /// گرفتن کاربران شرایط خاص
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IQueryable<Users> GetUsers(FilterUserSSOT filter)
        {
            var model = TableNoTracking
                .WhereIf(filter == FilterUserSSOT.AllUser, a => true)
                .WhereIf(filter == FilterUserSSOT.ActiveUser, a => a.IsActive)
                .WhereIf(filter == FilterUserSSOT.DeActiveUser, a => !a.IsActive);

            return model;
        }

        /// <summary>
        /// تغییر رمز عبور توسط مدیریت
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> AdminChangePassword(AdminSetPasswordViewModel vm)
        {
            var model = await GetByIdAsync(vm.UserId);

            if (model == null) return SweetAlertExtenstion.Error("کاربری با این شناسه یافت نشد");

            var newHashPassword = _userManager.PasswordHasher.HashPassword(model, vm.Password);
            model.PasswordHash = newHashPassword;
            var change = await _userManager.UpdateAsync(model);

            return change.Succeeded ? SweetAlertExtenstion.Ok() : SweetAlertExtenstion.Error();
        }

        /// <summary>
        /// گرفتن اطلاعات شماره تماس بر اساس شناسه کاربری
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<string> PhoneNumberByUserId(int userId)
        {
            var userInfo = await GetByIdAsync(userId);

            return userInfo.PhoneNumber;
        }

        /// <summary>
        /// گرفتن اطلاعات شماره تماس تمامی کاربران
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> AllUserPhoneNumber()
        {
            var phoneNumbers = await TableNoTracking.Select(a => a.PhoneNumber).ToListAsync();

            return phoneNumbers;
        }

        /// <summary>
        /// گرفتن اطلاعات شماره تماس تمامی کاربران
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> AllUserPhoneNumber(FilterUserSSOT filter)
        {
            var phoneNumbers = GetUsers(filter);

            return await phoneNumbers.Select(a => a.PhoneNumber).ToListAsync();
        }



        /// <summary>
        /// تعداد تمامی کاربران
        /// </summary>
        /// <returns></returns>
        public int CountUsers() => TableNoTracking.Count();

        public async Task<SweetAlertExtenstion> ChangeUserActivity(int userId)
        {
            try
            {
                var userInfo = await GetByIdAsync(userId);

                if (userInfo == null) return SweetAlertExtenstion.Error("کاربری با این شناسه یافت نشد");

                userInfo.IsActive = !userInfo.IsActive;
                await UpdateAsync(userInfo);

                return SweetAlertExtenstion.Ok();
            }
            catch (Exception)
            {
                return SweetAlertExtenstion.Error("خطای نامشخصی رخ داده است لطفا پس از چند لحظه دوباره امتحان کنید و در صورت برطرف نشدن مشکل با پشتیبانی تماس بگیرید");
            }
        }


        //public async Task SetUserClaims(string username)
        //{
        //    var userinfo = await GetByConditionAsyncTracked(a => a.UserName == username);

        //    var claimsidentity = new List<Claim>()
        //        {
        //                new Claim("FirstName", userinfo.FirstName ?? ""),
        //                new Claim("LastName",  userinfo.LastName ?? ""),
        //                new Claim("FullName",  userinfo.FirstName + " "+ userinfo.LastName),
        //                new Claim("UserProfile" , userinfo.ProfilePic ?? "/Uploads/UserImage/NoPhoto.jpg")
        //                //...
        //        };


        //    await _userClaimsRepository.RemoveClamsByUserId(userinfo.Id);
        //    await _userManager.AddClaimsAsync(userinfo, claimsidentity);

        //}

        /// <summary>
        /// ویرایش عکس یک کاربر
        /// </summary>
        /// <param name="UserId">شماره کاربری</param>
        /// <param name="profilePic">عکس جدید کاربر</param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> UpdateProfilePic(int UserId, IFormFile profilePic)
        {
            try
            {
                var entity = await GetByIdAsync(UserId);
                if(entity.ProfilePic != null && !string.IsNullOrEmpty(entity.ProfilePic))
                    await MFile.Delete(entity.ProfilePic);
                entity.ProfilePic = await MFile.Save(profilePic, "Uploads/UserImage");
                await DbContext.SaveChangesAsync();
                return SweetAlertExtenstion.Ok("عملیات با موفقیت انجام شد");
            }
            catch
            {
                return SweetAlertExtenstion.Error();
            }

        }
    }
}
