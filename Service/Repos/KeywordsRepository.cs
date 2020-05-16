using AutoMapper.QueryableExtensions;
using DataLayer.DTO;
using DataLayer.Entities;
using DataLayer.ViewModels.Keyword;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repos
{
    public class KeywordsRepository : GenericRepository<Keywords>
    {
        public KeywordsRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<Tuple<int, List<KeywordsFullDTO>>> LoadAsyncCount(
           int skip = -1,
           int take = -1,
           KeywordsSearchViewModel model = null)
        {
            var query = Entities.ProjectTo<KeywordsFullDTO>();


            if (model.Id != null)
                query = query.Where(x => x.Id == model.Id);

            if (!string.IsNullOrEmpty(model.Keyword))
                query = query.Where(x => x.Keyword.Contains(model.Keyword));

            if (model.Type != null)
                query = query.Where(x => x.Type == model.Type);

            if(model.IsActive != null)
                query = query.Where(x => x.IsActive == model.IsActive);
            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);



            return new Tuple<int, List<KeywordsFullDTO>>(Count, await query.ToListAsync());
        }

        public async Task ChangeStatus(int id)
        {
            var model =await GetByIdAsync(id);
            if (model == null) return;

            model.IsActive = !model.IsActive;
            await UpdateAsync(model);
        }
    }
}
