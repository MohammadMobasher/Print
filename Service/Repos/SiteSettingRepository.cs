using Core.Utilities;
using DataLayer.Entities;
using DataLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Service.Repos
{
    public class SiteSettingRepository : GenericRepository<SiteSetting>
    {
        public SiteSettingRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<SiteSetting> GetInfo()
        {
            return await TableNoTracking.SingleOrDefaultAsync();
        }

        public async Task<SweetAlertExtenstion> UpdateInfo(SiteInfoUpdateViewModel vm)
        {
            var entity = await TableNoTracking.SingleOrDefaultAsync();
            
            if(vm.LogoFile != null)
            {
                entity.Logo = await MFile.Save(vm.LogoFile, "Uploads/SiteSetting");
            }

            if(vm.BackGroudLoginPageFile != null)
            {
                entity.BackGroudLoginPage = await MFile.Save(vm.BackGroudLoginPageFile, "Uploads/SiteSetting");
            }

            entity.SiteName = vm.SiteName;

            Entities.Update(entity);
            await DbContext.SaveChangesAsync();
            return SweetAlertExtenstion.Ok();
        }
    }
}
