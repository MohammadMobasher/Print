using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Utilities;
using DataLayer.DTO.Organizations;
using DataLayer.Entities;
using DataLayer.ViewModels.Organizations;
using DataLayer.ViewModels.UserOrganization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repos.Organizations
{
    public class UserOrganizationRepository : GenericRepository<UserOrganization>
    {
        public UserOrganizationRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }



        public async Task<Tuple<int, List<UserOrganizationDTO>>> LoadAsyncCount(
           int skip = -1,
           int take = -1,
           UserOrganizationSearchViewModel model = null)
        {
            var query = Entities.Include(x=> x.Users) .ProjectTo<UserOrganizationDTO>();

            if (!string.IsNullOrEmpty(model.OrganizationTitle))
                query = query.Where(x => x.Organization.OrganizationTitle.Contains(model.OrganizationTitle));


            if (!string.IsNullOrEmpty(model.UserNameFamily))
                query = query.Where(x => 
                    x.Users.FirstName.Contains(model.UserNameFamily) ||
                    x.Users.LastName.Contains(model.UserNameFamily));


            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<UserOrganizationDTO>>(Count, await query.ToListAsync());
        }


        /// <summary>
        /// گرفتن لیست سازمان‌هایی که یک کاربر در آنها عضو است
        /// </summary>
        /// <param name="userId">شماره کاربری</param>
        /// <returns></returns>
        public async Task<List<int>> GetOrganizationByUserId(int userId)
        {

            return await TableNoTracking.Where(x => x.UserId == userId).Select(x => x.OrganizationId).ToListAsync();

        }


        /// <summary>
        /// گرفتن لیست سازمان‌هایی که یک کاربر در آنها عضو است
        /// </summary>
        /// <param name="userId">شماره کاربری</param>
        /// <returns></returns>
        public async Task<List<OrganizationIdTitleDTO>> GetOrganizationFullByUserId(int userId)
        {

            return await (from userOrganization in DbContext.UserOrganization
                          where userOrganization.UserId == userId

                          join organization in DbContext.Organization on userOrganization.OrganizationId equals organization.Id

                          select new OrganizationIdTitleDTO
                          {
                              Id = organization.Id,
                              OrganizationTitle = organization.OrganizationTitle
                          }).ToListAsync();

        }



        /// <summary>
        /// از این تابع زمانی استفاده می شود که بخواهیم سازمان‌های مربوط به یک شخص را ویرایش کنیم
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> UpdateOrganizationForUser(List<UserOrganizationInsertViewModel> vm, int userId)
        {
            try
            {
                var OldEntity = await Entities.Where(x => x.UserId == userId).ToListAsync();
                Entities.RemoveRange(OldEntity);

                foreach (UserOrganizationInsertViewModel item in vm)
                {
                    var entity = Mapper.Map<UserOrganization>(item);
                    await Entities.AddAsync(entity);
                }
                await DbContext.SaveChangesAsync();
                return SweetAlertExtenstion.Ok();
            }
            catch(Exception e)
            {
                return SweetAlertExtenstion.Error();
            }
        }
    }
}
