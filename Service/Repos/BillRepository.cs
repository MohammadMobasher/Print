using AutoMapper.QueryableExtensions;
using DataLayer.DTO.BIll;
using DataLayer.Entities;
using DataLayer.ViewModels.Bill;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repos
{
    public class BillRepository : GenericRepository<Bill>
    {
        public BillRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }



        /// <summary>
        /// get item by project id
        /// </summary>
        /// <param name="subProjectId">project id</param>
        /// <returns></returns>
        public async Task<Bill> GetBySubProjectIdAsync(int subProjectId)
        {
            return await Entities.SingleOrDefaultAsync(x=> x.SubProjectId == subProjectId);
        }


        public async Task<Tuple<int, List<BillFullInfoDTO>>> LoadAsyncCount(
           int skip = -1,
           int take = -1,
           BillSearchViewModel model = null)
        {

            //var query = (from bill in DbContext.Bill 
            //             join subProject in DbContext.SubProject on bill.SubProjectId equals subProject.Id

            //             );

            var query = Entities.ProjectTo<BillFullInfoDTO>();

          

            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<BillFullInfoDTO>>(Count, await query.ToListAsync());
        }


        /// <summary>
        /// get all bill for a project 
        /// </summary>
        /// <param name="projectId">project id</param>
        /// <returns></returns>
        public async Task<List<BillFullInfoDTO>> GetBillsByProjectId(int projectId)
        {
            return await (from project in DbContext.Project
                         where project.Id == projectId
                         join subProject in DbContext.SubProject on project.Id equals subProject.ProjectId
                         join bill in DbContext.Bill on subProject.Id equals bill.SubProjectId 
                         

                         select new BillFullInfoDTO {

                             #region BillInfo

                             IsPayed =  bill.IsPayed,
                             PriceEachPage =  bill.PriceEachPage,
                             SumPriceEachPage =  bill.SumPriceEachPage,
                             NumberOfPage =  bill.NumberOfPage,
                             PriceEachCover =  bill.PriceEachCover,
                             SumPriceEachCover =  bill.SumPriceEachCover,
                             PriceDelivery =  bill.PriceDelivery,
                             SumPrice =  bill.SumPrice,
                             Created =  bill.Created,
                             
                             #endregion

                             #region ProjectInfo

                             ProjectTitle = project.Title,
                             ProjectId = project.Id,

                             #endregion

                             #region SubProjectInfo

                             SubProjectId = subProject.Id,
                             SubProjectTitle = subProject.Title,
                             SubProjectType = subProject.SubProjectType,
                             Color = subProject.Color,
                             Size = subProject.Size,
                             Height = subProject.Height,
                             Width = subProject.Width,
                             PaperMaterial = subProject.PaperMaterial,
                             BindingType = subProject.BindingType,
                             BindingNumber = subProject.BindingNumber,
                             BookCoverColor = subProject.BookCoverColor,
                             BookCoverMaterial = subProject.BookCoverMaterial,
                             Priority = subProject.Priority,

                             #endregion

                         }).ToListAsync(); ;

        }


    }
}
