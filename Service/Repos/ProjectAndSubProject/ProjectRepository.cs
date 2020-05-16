using AutoMapper.QueryableExtensions;
using Core.Utilities;
using DataLayer.DTO.ProjectAndSubProject.ProjectDTO;
using DataLayer.Entities;
using DataLayer.SSOT;
using DataLayer.ViewModels.ProjectAndSubProject.ProjectViewModel;
using Microsoft.EntityFrameworkCore;
using Service.Repos.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repos.ProjectAndSubProject
{
    public class ProjectRepository : GenericRepository<Project>
    {
        private readonly UserOrganizationRepository _userOrganizationRepository;
        private readonly SubProjectRepository _subProjectRepository;

        public ProjectRepository(DatabaseContext dbContext,
            UserOrganizationRepository userOrganizationRepository,
            SubProjectRepository subProjectRepository) : base(dbContext)
        {
            _userOrganizationRepository = userOrganizationRepository;
            _subProjectRepository = subProjectRepository;
        }


        public async Task<Tuple<int, List<ProjectDTO>>> LoadAsyncCountAdminCustomer(
           int userId,
           int skip = -1,
           int take = -1,
           ProjectSearchViewModel model = null)
        {
            var OrganizationIds = await _userOrganizationRepository.GetOrganizationByUserId(userId);


            var query = Entities

                .ProjectTo<ProjectDTO>();

            switch (model.RoutinStatus)
            {
                case RoutineSSOT.New:
                    query = query.Where(x => x.Status == ProjectStatusSSOT.AdminCustomer ||
                    x.Status == ProjectStatusSSOT.AdminCustomerShoudPay);
                    break;
                case RoutineSSOT.Posted:
                    query = query.Where(x => x.Status > ProjectStatusSSOT.AdminCustomer &&
                    x.Status != ProjectStatusSSOT.AdminCustomerShoudPay &&
                    x.Status != ProjectStatusSSOT.Customer &&
                    x.Status != ProjectStatusSSOT.Success &&
                    x.Status != ProjectStatusSSOT.Deny);
                    break;
                case RoutineSSOT.Ended:
                    query = query.Where(x => x.Status == ProjectStatusSSOT.Success || x.Status == ProjectStatusSSOT.Deny);
                    break;
                default:
                    query = query.Where(x => x.Status == ProjectStatusSSOT.AdminCustomer);
                    break;
            }


            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(x => x.Title.Contains(model.Title));


            if (OrganizationIds != null)
                query = query.Where(x => OrganizationIds.Contains(x.OrganizationId));
            // درصورتی که به هیچ سازمانی متصل نباشد نباید هیچ آیتمی نمایش داده شود
            else
                query = query.Where(x => x.OrganizationId == -1);


            // در صورتی که کاربر برای حدول مورد نظر جستجو سازمان زده باشد
            if (model.OrganizationId != null)
                query = query.Where(x => x.OrganizationId == model.OrganizationId);


            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<ProjectDTO>>(Count, await query.ToListAsync());
        }


        public async Task<Tuple<int, List<ProjectDTO>>> LoadAsyncCountCustomer(
           int userId,
           int skip = -1,
           int take = -1,
           ProjectSearchViewModel model = null)
        {


            var query = Entities

                .ProjectTo<ProjectDTO>();

            query = query.Where(x => x.UserId == userId);

            switch (model.RoutinStatus)
            {
                case RoutineSSOT.New:
                    query = query.Where(x => x.Status == ProjectStatusSSOT.Customer);
                    break;
                case RoutineSSOT.Posted:
                    query = query.Where(x => x.Status > ProjectStatusSSOT.Customer &&
                    x.Status != ProjectStatusSSOT.Success &&
                    x.Status != ProjectStatusSSOT.Deny);
                    break;
                case RoutineSSOT.Ended:
                    query = query.Where(x => x.Status == ProjectStatusSSOT.Success || x.Status == ProjectStatusSSOT.Deny);
                    break;
                default:
                    query = query.Where(x => x.Status == ProjectStatusSSOT.Customer);
                    break;
            }


            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(x => x.Title.Contains(model.Title));





            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<ProjectDTO>>(Count, await query.ToListAsync());
        }

        public async Task<Tuple<int, List<ProjectDTO>>> LoadAsyncCountAdmin(

           int skip = -1,
           int take = -1,
           ProjectSearchViewModel model = null)
        {


            var query = Entities

                .ProjectTo<ProjectDTO>();



            switch (model.RoutinStatus)
            {
                case RoutineSSOT.New:
                    query = query.Where(x => x.Status == ProjectStatusSSOT.Admin);
                    break;
                case RoutineSSOT.Posted:
                    query = query.Where(x => x.Status > ProjectStatusSSOT.Admin
                    &&
                    x.Status != ProjectStatusSSOT.Success &&
                    x.Status != ProjectStatusSSOT.Deny);
                    break;
                case RoutineSSOT.Ended:
                    query = query.Where(x => x.Status == ProjectStatusSSOT.Success || x.Status == ProjectStatusSSOT.Deny);
                    break;
                default:
                    query = query.Where(x => x.Status == ProjectStatusSSOT.Customer);
                    break;
            }


            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(x => x.Title.Contains(model.Title));



            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<ProjectDTO>>(Count, await query.ToListAsync());
        }


        public async Task<Tuple<int, List<ProjectDTO>>> LoadAsyncCountPrintingEmployee(

           int skip = -1,
           int take = -1,
           ProjectSearchViewModel model = null)
        {


            var query = Entities

                .ProjectTo<ProjectDTO>();



            //switch (model.RoutinStatus)
            //{
            //    case RoutineSSOT.New:
            //        query = query.Where(x => x.Status == ProjectStatusSSOT.Printing);
            //        break;
            //    case RoutineSSOT.Posted:
            //        query = query.Where(x => x.Status > ProjectStatusSSOT.Printing);
            //        break;
            //    case RoutineSSOT.Ended:
            //        query = query.Where(x => x.Status == ProjectStatusSSOT.Success || x.Status == ProjectStatusSSOT.Deny);
            //        break;
            //    default:
            //        query = query.Where(x => x.Status == ProjectStatusSSOT.Printing);
            //        break;
            //}


            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(x => x.Title.Contains(model.Title));



            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<ProjectDTO>>(Count, await query.ToListAsync());
        }


        /// <summary>
        /// وضعیت یک پروژه را برمی‌گرداند
        /// </summary>
        /// <param name="projectId">شماره پروژه مورد نظر</param>
        /// <returns></returns>
        public async Task<ProjectStatusSSOT> GetStatus(int projectId)
        {
            var result = await GetByIdAsync(projectId);
            if (result == null)
                return ProjectStatusSSOT.NoRecord;
            else
                return result.Status;
        }

        /// <summary>
        /// Send project to next step
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> SendProject(int projectId)
        {
            try
            {


                var entity = await GetByIdAsync(projectId);

                // زمانی که پروژه در دست ادمین کاستومر هست و منتظر پرداخت است 
                // نباید اجازه تغییر وضعیت آن را بدهیم
                if (entity.Status == ProjectStatusSSOT.AdminCustomerShoudPay)
                {
                    if (!entity.IsPayed)
                    {
                        return SweetAlertExtenstion.Error("Please pay first");
                    }
                }

                entity.Status = entity.Status + 1;
                await DbContext.SaveChangesAsync();

                return SweetAlertExtenstion.Ok();
            }
            catch (Exception e)
            {
                return SweetAlertExtenstion.Error();
            }
        }


        public async Task<SweetAlertExtenstion> DenyProject(int projectId)
        {
            try
            {

                var entity = await GetByIdAsync(projectId);
                entity.Status = ProjectStatusSSOT.Deny;
                await DbContext.SaveChangesAsync();

                return SweetAlertExtenstion.Ok();
            }
            catch (Exception e)
            {
                return SweetAlertExtenstion.Error();
            }
        }


        /// <summary>
        /// پرداخت یک پروژه توسط ادمین کارتومر
        /// </summary>
        /// <param name="projectId">شمار پروژه</param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> PayProject(int projectId)
        {
            try
            {

                var entity = await GetByIdAsync(projectId);
                entity.IsPayed = true;
                entity.Status = entity.Status + 1;
                await DbContext.SaveChangesAsync();



                return SweetAlertExtenstion.Ok();
            }
            catch (Exception e)
            {
                return SweetAlertExtenstion.Error();
            }
        }

        


        /// <summary>
        /// Get All Task for a project
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns></returns>
        public async Task<List<SubProject>> GetAllTask(int projectId)
        {
            return await DbContext.SubProject.Where(x => x.ProjectId == projectId).ToListAsync();
        }

        /// <summary>
        /// ثبت یک آیتم در جدول مورد نظر
        /// </summary>
        /// <param name="model">مدلی که از سمت کلاینت در حال پاس دادن آن هستیم</param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> DeleteAsync(int projectId)
        {

            try
            {
                var entity = await GetByIdAsync(projectId);
                DbContext.Remove(entity);
                await _subProjectRepository.DeleteByProjectIdAsync(projectId);

                await DbContext.SaveChangesAsync();
                return SweetAlertExtenstion.Ok();
            }
            catch
            {
                return SweetAlertExtenstion.Error();
            }

        }
    }
}
