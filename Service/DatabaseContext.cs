using Core.Utilities;
using DataLayer.Entities;
using DataLayer.Entities.FAQs;
using DataLayer.Entities.Common;
using DataLayer.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    public class DatabaseContext : IdentityDbContext<Users, Roles, int, UserClams, UserRoles, UserLogin, RoleClams, UserTokens>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        #region Tables

        
        public DbSet<SiteSetting> SiteSetting { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<SubProject> SubProject { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<FAQ> FAQ { get; set; }
        public DbSet<FaqGroup> FaqGroup { get; set; }
        public DbSet<UsersAccess> UsersAccess { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<UserOrganization> UserOrganization { get; set; }

        #region News

        public DbSet<News> News { get; set; }
        public DbSet<NewsComment> NewsComment { get; set; }
        public DbSet<NewsGroup> NewsGroup { get; set; }
        public DbSet<NewsTag> NewsTag { get; set; }

        #endregion

        
        public DbSet<SlideShow> SlideShow { get; set; }

        
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);



            //modelBuilder.Entity<Organization>()
            //    .HasMany<SubProject>(g => g.SubProject)
            //    .WithOne(x=> x.Organization)
            //    .HasForeignKey(s => s.OrganizationId)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    ;





            var entitiesAssembly = typeof(IEntity).Assembly;

            //modelBuilder.RegisterAllEntities<IEntity>(entitiesAssembly);
            //modelBuilder.AddRestrictDeleteBehaviorConvention();

            modelBuilder.RegisterEntityTypeConfiguration(entitiesAssembly);
            modelBuilder.AddSequentialGuidForIdConvention();

            
        }

        #region CleanString
        // این بخش برای یکپارچه سازی کاراکتر ها می باشد به صورتی که اگر کاربری 
        // ی عربی وارد کرد تبدیل به ی فارسی و ....

        public override int SaveChanges()
        {
            _cleanString();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            _cleanString();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            _cleanString();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            _cleanString();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void _cleanString()
        {
            var changedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var item in changedEntities)
            {
                if (item.Entity == null)
                    continue;

                var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    var propName = property.Name;
                    var val = (string)property.GetValue(item.Entity, null);

                    if (val.HasValue())
                    {
                        var newVal = val.Fa2En().FixPersianChars();
                        if (newVal == val)
                            continue;
                        property.SetValue(item.Entity, newVal, null);
                    }
                }
            }
        }

        #endregion
    }
}
