using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Utilities;
using DataLayer.DTO.Organizations;
using DataLayer.Entities;
using DataLayer.ViewModels.Organizations;
using Microsoft.EntityFrameworkCore;

namespace Service.Repos.Organizations
{
    public class OrganizationRepository : GenericRepository<Organization>
    {
        public OrganizationRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }


        public async Task<Tuple<int, List<OrganizationDTO>>> LoadAsyncCount(
           int skip = -1,
           int take = -1,
           OrganizationSearchViewModel model = null)
        {
            var query = Entities.ProjectTo<OrganizationDTO>();

            if (!string.IsNullOrEmpty(model.OrganizationTitle))
                query = query.Where(x => x.OrganizationTitle.Contains(model.OrganizationTitle));


            if (!string.IsNullOrEmpty(model.OrganizationAddress))
                query = query.Where(x => x.OrganizationAddress.Contains(model.OrganizationAddress));


            if (!string.IsNullOrEmpty(model.OrganizationPhone))
                query = query.Where(x => x.OrganizationPhone.Contains(model.OrganizationPhone));

           
            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<OrganizationDTO>>(Count, await query.ToListAsync());
        }



        
    }
}
