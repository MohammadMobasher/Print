using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Utilities;
using DataLayer.DTO.ProjectAndSubProject.SubProjectDTO;
using DataLayer.Entities;
using DataLayer.ViewModels.ProjectAndSubProject.ProjectViewModel;
using DataLayer.ViewModels.ProjectAndSubProject.SubProjectViewModel;
using Microsoft.EntityFrameworkCore;
using Service.Repos.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.IO;
using DataLayer.SSOT;
using DataLayer.DTO;

namespace Service.Repos.ProjectAndSubProject
{
    public class SubProjectRepository : GenericRepository<SubProject>
    {
        private readonly UserOrganizationRepository _userOrganizationRepository;
        //private readonly ProjectRepository _projectRepository;

        public SubProjectRepository(DatabaseContext dbContext,
            UserOrganizationRepository userOrganizationRepository
            //ProjectRepository projectRepository
            ) : base(dbContext)
        {
            _userOrganizationRepository = userOrganizationRepository;
            //_projectRepository = projectRepository;
        }

        public async Task<Tuple<int, List<SubProjectADTO>>> LoadAsyncCount(
           int projectId,
           int userId,
           int skip = -1,
           int take = -1,
           SubProjectSearchViewModel model = null)
        {
            var query = Entities.ProjectTo<SubProjectADTO>();




            query = query.Where(x => x.ProjectId == projectId);

            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(x => x.Title.Contains(model.Title));



            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<SubProjectADTO>>(Count, await query.ToListAsync());
        }


        public async Task<Tuple<int, List<SubProjectACDTO>>> LoadAdminCustomerAsyncCount(
           int projectId,
           int skip = -1,
           int take = -1,
           SubProjectSearchViewModel model = null)
        {
            var query = Entities.ProjectTo<SubProjectACDTO>();




            query = query.Where(x => x.ProjectId == projectId);

            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(x => x.Title.Contains(model.Title));



            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<SubProjectACDTO>>(Count, await query.ToListAsync());
        }


        public async Task<Tuple<int, List<SubProjectCDTO>>> LoadCustomerAsyncCount(
           int projectId,
           int skip = -1,
           int take = -1,
           SubProjectSearchViewModel model = null)
        {
            var query = Entities.ProjectTo<SubProjectCDTO>();

            query = query.Where(x => x.ProjectId == projectId);

            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(x => x.Title.Contains(model.Title));

            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<SubProjectCDTO>>(Count, await query.ToListAsync());
        }


        public async Task<Tuple<int, List<SubProjectADTO>>> LoadAdminAsyncCount(
           int projectId,
           int userId,
           int skip = -1,
           int take = -1,
           SubProjectSearchViewModel model = null)
        {

            var query = (from subProject in DbContext.SubProject
                         where subProject.ProjectId == projectId

                         join bill in DbContext.Bill on subProject.Id equals bill.SubProjectId into temp
                         from leftBill in temp.DefaultIfEmpty()


                         select new SubProjectADTO
                         {
                             Id = subProject.Id,
                             ProjectId = projectId,
                             Title = subProject.Title,
                             UserId = userId,
                             SubProjectType = subProject.SubProjectType,
                             OrganizationId = subProject.OrganizationId,
                             NumberOfPage = subProject.BookPageNumber,


                             //price info
                             HasBill = leftBill != null ? true : false,
                             PriceEachPage = leftBill.PriceEachPage ?? 0,
                             SumPriceEachPage = leftBill.SumPriceEachPage ?? 0,
                             PriceEachCover = leftBill.PriceEachCover ?? 0,
                             SumPriceEachCover = leftBill.SumPriceEachCover ?? 0,
                             PriceDelivery = leftBill.PriceDelivery ?? 0,
                             SumPrice = leftBill.SumPrice != null ? leftBill.SumPrice.Value : 0

                         });



            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(x => x.Title.Contains(model.Title));



            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<SubProjectADTO>>(Count, await query.ToListAsync());
        }


        public async Task<Tuple<int, List<SubProjectEmployeeDTO>>> LoadEmployeePrintingAsyncCount(

           int skip = -1,
           int take = -1,
           SubProjectSearchViewModel model = null)
        {

            var query = Entities.Include(x => x.Project)
                // درصورتی که هنوز چیزی برای پرینت وجود داشته باشد
                .Where(x => x.NumOfPrinting < x.Number || x.Status == SubProjectRoutineStatusSSOT.PrintingProgress)
                .ProjectTo<SubProjectEmployeeDTO>();



            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(x => x.Title.Contains(model.Title));

            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<SubProjectEmployeeDTO>>(Count, await query.ToListAsync());
        }

        /// <summary>
        /// اطلاعات مورد نیاز برای تقویم که قرار است به مدیر نمایش داده شود
        /// </summary>
        /// <returns></returns>
        public async Task<List<CalenderDTO>> GetCalenderInfo()
        {
            List<CalenderDTO> model = new List<CalenderDTO>();


            
            var result = await Entities.Include(x=> x.Project).Where(x => 
                (x.Status == SubProjectRoutineStatusSSOT.BindingProgress ||
                    x.Status == SubProjectRoutineStatusSSOT.CoveringProgress ||
                    x.Status == SubProjectRoutineStatusSSOT.PrintingProgress) &&
                (x.Project.Status == ProjectStatusSSOT.Progressing)).ToListAsync();

            foreach (var item in result)
            {
                model.Add(new CalenderDTO {

                   // start = item.SuggestedTime.ToString("yyyy-MM-dd"),
                    title = item.Title + "(" + item.Project.Title + ")",
                    description = item.SubProjectType.ToDisplay() + "\n" + item.Number

                });
            }
            return model;

        }

        public async Task<Tuple<int, List<SubProjectEmployeeDTO>>> LoadEmployeeBindingAsyncCount(
           int skip = -1,
           int take = -1,
           SubProjectSearchViewModel model = null)
        {

            var query = Entities.Include(x => x.Project)
                // درصورتی که هنوز چیزی برای منگنه وجود داشته باشد
                .Where(x => x.NumOfBinding < x.Number || x.Status == SubProjectRoutineStatusSSOT.BindingProgress)
                .ProjectTo<SubProjectEmployeeDTO>();



            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(x => x.Title.Contains(model.Title));

            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<SubProjectEmployeeDTO>>(Count, await query.ToListAsync());
        }


        public async Task<Tuple<int, List<SubProjectEmployeeDTO>>> LoadEmployeeCoveringAsyncCount(
           int skip = -1,
           int take = -1,
           SubProjectSearchViewModel model = null)
        {

            var query = Entities.Include(x => x.Project)
                // درصورتی که هنوز چیزی برای منگنه وجود داشته باشد
                .Where(x => x.NumOfCovering < x.Number || x.Status == SubProjectRoutineStatusSSOT.CoveringProgress)
                .ProjectTo<SubProjectEmployeeDTO>();



            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(x => x.Title.Contains(model.Title));

            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<SubProjectEmployeeDTO>>(Count, await query.ToListAsync());
        }



        /// <summary>
        /// ثبت یک آیتم در جدول مورد نظر
        /// </summary>
        /// <param name="model">مدلی که از سمت کلاینت در حال پاس دادن آن هستیم</param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> AddAsync(SubProjectInsertViewModel model)
        {

            try
            {
                var entity = Mapper.Map<SubProject>(model);

                #region InsertFiles

                #region Book Or Sheet
                entity.BookOrSeet = await MFile.Save(model.BookOrSeetAddress, "Uploads/BookOrSeet");
                #endregion

                #region Book Cover
                if (model.BookCoverAddress != null)
                {
                    entity.BookCover = await MFile.Save(model.BookCoverAddress, "Uploads/BookCover");
                }
                #endregion

                #endregion

                if (entity.SubProjectType == DataLayer.SSOT.ProjectTypeSSOT.Book)
                {

                    //TODO check .PDF
                    //if (Path.GetExtension(entity.BookOrSeet).ToLower() == "pdf")
                    {
                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + entity.BookOrSeet);
                        PdfReader pdfReader = new PdfReader(filePath);
                        entity.BookPageNumber = pdfReader.NumberOfPages;
                    }
                }

                await Entities.AddAsync(entity);
                await DbContext.SaveChangesAsync();
                return SweetAlertExtenstion.Ok();
            }
            catch (Exception e)
            {
                return SweetAlertExtenstion.Error();
            }

        }



        /// <summary>
        /// ویرایش یک آیتم
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> UpdateAsync(SubProjectUpdateViewModel model)
        {
            try
            {
                var entity = Mapper.Map<SubProject>(model);

                #region InsertFiles

                #region Book Or Sheet
                if (model.BookOrSeetAddress != null)
                {
                    await MFile.Delete(model.BookOrSeet);
                    entity.BookOrSeet = await MFile.Save(model.BookOrSeetAddress, "Uploads/BookOrSeet");

                }
                #endregion

                #region Book Cover
                if (model.BookCoverAddress != null)
                {
                    await MFile.Delete(model.BookCover);
                    entity.BookCover = await MFile.Save(model.BookCoverAddress, "Uploads/BookCover");
                }
                #endregion

                #endregion

                if (model.SubProjectType == DataLayer.SSOT.ProjectTypeSSOT.Sheet)
                {
                    model.BindingNumber = null;
                    model.BindingType = null;
                    model.BookCoverColor = null;
                    model.BookCoverMaterial = null;
                    model.BookCover = null;
                }

                //// TODO
                //if (model.Size != DataLayer.SSOT.SizeSSOT.Cutsom)
                //{
                //    model.Width = null;
                //    model.Height = null;
                //}

                Entities.Update(entity);
                await DbContext.SaveChangesAsync();
                return SweetAlertExtenstion.Ok();
            }
            catch (Exception e)
            {
                return SweetAlertExtenstion.Error();
            }
        }


        /// <summary>
        ///Delete from this table
        /// </summary>
        /// <param name="Id">record number</param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> DeleteAsync(int Id)
        {
            try
            {
                var entity = await GetByIdAsync(Id);

                if (!string.IsNullOrEmpty(entity.BookOrSeet))
                    await MFile.Delete(entity.BookOrSeet);

                if (!string.IsNullOrEmpty(entity.BookCover))
                    await MFile.Delete(entity.BookCover);

                DbContext.Remove(entity);
                await DbContext.SaveChangesAsync();
                return SweetAlertExtenstion.Ok();
            }
            catch
            {
                return SweetAlertExtenstion.Error();
            }
        }


        /// <summary>
        /// number of SubProject By Project Id
        /// </summary>
        /// <param name="projectId">project Id</param>
        /// <returns></returns>
        public async Task<int> HasSubProjectByProjectId(int projectId)
        {
            return Entities.Where(x => x.ProjectId == projectId).Count();
        }


        /// <summary>
        /// Delete by ProjectId
        /// </summary>
        /// <param name="projectId">Project Id</param>
        /// <returns></returns>
        public async Task DeleteByProjectIdAsync(int projectId)
        {


            var entities = await Entities.Where(x => x.ProjectId == projectId).ToListAsync();
            if (entities != null)
                DbContext.RemoveRange(entities);


        }


        /// <summary>
        /// آیا این پروژه تسکی که تمام نشده باشد دارد یا نه
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<bool> AllTaskPrinted(int projectId)
        {
            var result = await Entities.Where(x => x.ProjectId == projectId && x.Status != SubProjectRoutineStatusSSOT.End).ToListAsync();

            if (result != null && result.Count > 0)
                return false;

            return true;
        }


        /// <summary>
        /// کارمند بخش پرینت بعد از گرفتن تعدادی پرینت این تابع را صدا میزند
        /// تا به تعدادی که پرینت گرفته است اضافه کند
        /// </summary>
        /// <param name="numberOfDo">تعدادی که انجام داده است</param>
        /// <param name="subProjectId">شماره زیر پروژه</param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> AddDonePrinting(int numberOfDo, int subProjectId)
        {
            try
            {
                var entity = await GetByIdAsync(subProjectId);

                entity.NumOfPrinting += numberOfDo;

                // درصورتی که گار پرینت انجام شده باشد 
                // باید به مرحله بعدی بروی
                if (entity.NumOfPrinting == entity.Number)
                {
                    if (entity.SubProjectType == ProjectTypeSSOT.Book)
                    {
                        entity.Status = SubProjectRoutineStatusSSOT.BindingProgress;
                    }
                    else
                    {
                        entity.Status = SubProjectRoutineStatusSSOT.End;

                        var result = await TableNoTracking.Where(x => x.ProjectId == entity.ProjectId &&
                            x.Status != SubProjectRoutineStatusSSOT.End
                        ).ToListAsync();

                        if (result == null)
                        {
                            var projectEntity = await DbContext.Project.Where(x => x.Id == entity.ProjectId).SingleOrDefaultAsync();
                            projectEntity.Status = projectEntity.Status + 1;
                        }
                    }
                }

                await DbContext.SaveChangesAsync();
                return SweetAlertExtenstion.Ok();
            }
            catch
            {
                return SweetAlertExtenstion.Error();
            }
        }


        /// <summary>
        /// کارمند بخش منگنه بعد از منگنه کردن تعدادی کتاب این تابع را صدا میزند
        /// تا به تعدادی که منگنه کرده است اضافه کند
        /// </summary>
        /// <param name="numberOfDo">تعدادی که انجام داده است</param>
        /// <param name="subProjectId">شماره زیر پروژه</param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> AddDoneBinding(int numberOfDo, int subProjectId)
        {
            try
            {
                var entity = await GetByIdAsync(subProjectId);

                entity.NumOfBinding += numberOfDo;

                // درصورتی که گار پرینت انجام شده باشد 
                // باید به مرحله بعدی بروی
                if (entity.NumOfBinding == entity.Number)
                {
                    entity.Status = SubProjectRoutineStatusSSOT.CoveringProgress;
                }

                await DbContext.SaveChangesAsync();
                return SweetAlertExtenstion.Ok();
            }
            catch
            {
                return SweetAlertExtenstion.Error();
            }
        }

        /// <summary>
        /// کارمند بخش کاور بعد از جلد کردن تعدادی کتاب این تابع را صدا میزند
        /// تا به تعدادی که جلد کرده است اضافه کند
        /// </summary>
        /// <param name="numberOfDo">تعدادی که انجام داده است</param>
        /// <param name="subProjectId">شماره زیر پروژه</param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> AddDoneCovering(int numberOfDo, int subProjectId)
        {
            try
            {
                var entity = await GetByIdAsync(subProjectId);

                entity.NumOfCovering += numberOfDo;

                // درصورتی که گار پرینت انجام شده باشد 
                // باید به مرحله بعدی بروی
                if (entity.NumOfCovering == entity.Number)
                {
                    entity.Status = SubProjectRoutineStatusSSOT.End;

                    await DbContext.SaveChangesAsync();

                    var result = await TableNoTracking.Where(x => x.ProjectId == entity.ProjectId &&
                        x.Status != SubProjectRoutineStatusSSOT.End
                    ).ToListAsync();

                    if (result == null || result.Count == 0)
                    {
                        var projectEntity = await DbContext.Project.Where(x => x.Id == entity.ProjectId).SingleOrDefaultAsync();
                        projectEntity.Status = projectEntity.Status + 1;
                    }

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
