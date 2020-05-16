﻿using Core.Utilities;
using DataLayer.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Service
{

    public class GenericRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DatabaseContext DbContext;
        protected DbSet<TEntity> Entities { get; }
        public virtual IQueryable<TEntity> Table => Entities;
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public GenericRepository(DatabaseContext dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<TEntity>(); // City => Cities
        }




        #region By Me

        #region Sync Method



        /// <summary>
        /// گرفتن تمام اطلاعات به‌صورت یک جا
        /// </summary>
        /// <returns></returns>
        public List<IDestination> Load<IDestination>(
            int skip = -1,
            int take = -1,
            Expression<Func<IDestination, bool>> condition = null)
        {
            var query = Entities
                .ProjectTo<IDestination>();

            if (condition != null)
                query = query.Where(condition);


            if (skip != -1)
                query = query.Skip(skip);

            if (take != -1)
                query = query.Take(take);


            return query
                .ToList();
        }

        #endregion

        #region Async Method






        /// <summary>
        /// گرفتن تمام اطلاعات به‌صورت یک جا
        /// </summary>
        /// <returns></returns>
        public async Task<List<IDestination>> LoadAsync<IDestination>(
            int skip = -1,
            int take = -1,
            Expression<Func<IDestination, bool>> condition = null)
        {
            var query = Entities

                .ProjectTo<IDestination>();

            if (condition != null)
                query = query.Where(condition);

            if (skip != -1)
                query = query.Skip(skip);

            if (take != -1)
                query = query.Take(take);




            return await query
                .ToListAsync();
        }


        public async Task<Tuple<int, List<IDestination>>> LoadAsyncCount<IDestination>(
            int skip = -1,
            int take = -1,
            Expression<Func<IDestination, bool>> condition = null)
        {
            var query = Entities.ProjectTo<IDestination>();



            // درصورتی که شرطی وجود داشته باشد آن را اعمال میکند
            if (condition != null)
                query = query.Where(condition);


            int Count = query.Count();


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<IDestination>>(Count, await query.ToListAsync());
        }

        #endregion

        #endregion


        #region Async Method

        /// <summary>
        /// ثبت یک آیتم در جدول مورد نظر
        /// </summary>
        /// <param name="model">مدلی که از سمت کلاینت در حال پاس دادن آن هستیم</param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> AddAsync<InsertViewModel>(InsertViewModel model)
        {

            try
            {
                var entity = Mapper.Map<TEntity>(model);
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
        /// ثبت یک آیتم در جدول مورد نظر
        /// </summary>
        /// <param name="model">مدلی که از سمت کلاینت در حال پاس دادن آن هستیم</param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> AddRangeAsync<InsertViewModel>(List<InsertViewModel> model)
        {

            try
            {
                foreach (InsertViewModel item in model)
                {
                    var entity = Mapper.Map<TEntity>(item);
                    await Entities.AddAsync(entity);
                }
                await DbContext.SaveChangesAsync();

                return SweetAlertExtenstion.Ok();
            }
            catch (Exception e)
            {
                return SweetAlertExtenstion.Error();
            }

        }



        /// <summary>
        /// ثبت یک آیتم در جدول مورد نظر
        /// </summary>
        /// <param name="model">مدلی که از سمت کلاینت در حال پاس دادن آن هستیم</param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> DeleteAsync(int Id)
        {

            try
            {
                var entity = await GetByIdAsync(Id);
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
        /// ثبت یک آیتم در جدول مورد نظر
        /// </summary>
        /// <param name="model">مدلی که از سمت کلاینت در حال پاس دادن آن هستیم</param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> UpdateAsync<UpdateViewModel>(UpdateViewModel model)
        {

            try
            {
                var entity = Mapper.Map<TEntity>(model);
                Entities.Update(entity);
                await DbContext.SaveChangesAsync();
                return SweetAlertExtenstion.Ok();
            }
            catch (Exception e)
            {
                return SweetAlertExtenstion.Error();
            }

        }

        public virtual async Task<List<TProject>> GetAllMapAsync<TProject>(Expression<Func<TEntity, bool>> where = null)
        {
            return await TableNoTracking.WhereIf(where != null, where).ProjectTo<TProject>().ToListAsync();
        }


        public virtual Task<TEntity> GetByIdAsync(params object[] ids)
        {
            return Entities.FindAsync(ids);
        }

        public virtual Task<TEntity> GetByConditionAsync(Expression<Func<TEntity, bool>> where = null)
        {
            var query = TableNoTracking;

            if (where != null) query = query.Where(where);

            return query.FirstOrDefaultAsync();
        }

        public virtual Task<TEntity> GetByConditionAsyncTracked(Expression<Func<TEntity, bool>> where = null)
        {
            var query = Table;

            if (where != null) query = query.Where(where);

            return query.FirstOrDefaultAsync();
        }

        public virtual async Task AddAsync(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            await Entities.AddAsync(entity).ConfigureAwait(false);
            if (saveNow)
                await DbContext.SaveChangesAsync();
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            await Entities.AddRangeAsync(entities).ConfigureAwait(false);
            if (saveNow)
                await DbContext.SaveChangesAsync();
        }





        public virtual async Task UpdateAsync(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Update(entity);
            if (saveNow)
                await DbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.UpdateRange(entities);
            if (saveNow)
                await DbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Remove(entity);
            if (saveNow)
                await DbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.RemoveRange(entities);
            if (saveNow)
                await DbContext.SaveChangesAsync();
        }
        #endregion

        #region Sync Methods
        public virtual TEntity GetById(params object[] ids)
        {
            return Entities.Find(ids);
        }

        public TEntity GetByCondition(Expression<Func<TEntity, bool>> where = null)
        {
            var query = TableNoTracking;

            if (where != null) query = query.Where(where);

            return query.FirstOrDefault();
        }

        public TEntity GetByConditionTracked(Expression<Func<TEntity, bool>> where = null)
        {
            var query = Table;

            if (where != null) query = query.Where(where);

            return query.FirstOrDefault();
        }

        public virtual void Add(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Add(entity);
            if (saveNow)
                DbContext.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.AddRange(entities);
            if (saveNow)
                DbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Update(entity);
            DbContext.SaveChanges();
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.UpdateRange(entities);
            if (saveNow)
                DbContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Remove(entity);
            if (saveNow)
                DbContext.SaveChanges();
        }


        public virtual void DeleteRange(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.RemoveRange(entities);
            if (saveNow)
                DbContext.SaveChanges();
        }
        #endregion

        #region Attach & Detach
        public virtual void Detach(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            var entry = DbContext.Entry(entity);
            if (entry != null)
                entry.State = EntityState.Detached;
        }

        public virtual void Attach(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            if (DbContext.Entry(entity).State == EntityState.Detached)
                Entities.Attach(entity);
        }
        #endregion

        #region Explicit Loading
        public virtual async Task LoadCollectionAsync<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty)
            where TProperty : class
        {
            Attach(entity);

            var collection = DbContext.Entry(entity).Collection(collectionProperty);
            if (!collection.IsLoaded)
                await collection.LoadAsync().ConfigureAwait(false);
        }

        public virtual void LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty)
            where TProperty : class
        {
            Attach(entity);
            var collection = DbContext.Entry(entity).Collection(collectionProperty);
            if (!collection.IsLoaded)
                collection.Load();
        }

        public virtual async Task LoadReferenceAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty)
            where TProperty : class
        {
            Attach(entity);
            var reference = DbContext.Entry(entity).Reference(referenceProperty);
            if (!reference.IsLoaded)
                await reference.LoadAsync().ConfigureAwait(false);
        }

        public virtual void LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty)
            where TProperty : class
        {
            Attach(entity);
            var reference = DbContext.Entry(entity).Reference(referenceProperty);
            if (!reference.IsLoaded)
                reference.Load();
        }
        #endregion


        #region SyncMapping

        public virtual List<TProject> GetAllMap<TProject>(Expression<Func<TEntity, bool>> where = null)
        {
            return TableNoTracking.WhereIf(where != null, where).ProjectTo<TProject>().ToList();
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null)
        {
            return TableNoTracking.WhereIf(where != null, where).ToList();
        }
        public async virtual Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where = null)
        {
            return await TableNoTracking.WhereIf(where != null, where).ToListAsync();
        }



        public virtual void MapAdd<TProject>(TProject mapEntity, bool saveNow = true)
        {
            var mapModel = Map(mapEntity);

            Add(mapModel, saveNow);
        }

        public virtual void MapAddRange<TProject>(List<TProject> mapEntity, bool saveNow = true)
        {
            var mapModel = MapToList(mapEntity);

            AddRange(mapModel, saveNow);
        }

        public virtual void MapUpdate<TProject>(TProject mapEntity, bool saveNow = true)
        {
            var mapModel = Map(mapEntity);

            Update(mapModel, saveNow);
        }

        public virtual void MapUpdateRange<TProject>(List<TProject> mapEntity, bool saveNow = true)
        {
            var mapModel = MapToList(mapEntity);

            UpdateRange(mapModel, saveNow);
        }

        #endregion

        #region AsyncMapping

        public async Task MapAddAsync<TProject>(TProject project, bool saveNow = true)
        {
            var mapModel = Map(project);

            await AddAsync(mapModel, saveNow);
        }


        public async Task MapAddRangeAsync<TProject>(List<TProject> project, bool saveNow = true)
        {
            var mapModel = MapToList(project);

            await AddRangeAsync(mapModel, saveNow);
        }

        public async Task MapUpdateAsync<TProject>(TProject project, int id, bool saveNow = true)
        {
            var oldEntity = GetById(id);

            Mapper.Map(project, oldEntity);

            if (saveNow)
                await DbContext.SaveChangesAsync();
        }

        public async Task MapUpdateRangeAsync<TProject>(List<TProject> project, bool saveNow = true)
        {
            var mapModel = MapToList(project);

            await UpdateRangeAsync(mapModel, saveNow);
        }

        #endregion

        #region MappingFactory
        /// <summary>
        /// مپ کردن یک لیست به انتیتی مد نظر
        /// </summary>
        /// <typeparam name="TProject"></typeparam>
        /// <param name="mapEntity"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> MapToList<TProject>(List<TProject> mapEntity)
        {
            foreach (var item in mapEntity)
                yield return Mapper.Map<TEntity>(item);

        }

        /// <summary>
        /// مپ کردن به انتیتی مورد نظر
        /// </summary>
        /// <typeparam name="TProject"></typeparam>
        /// <param name="project"></param>
        /// <returns></returns>
        public TEntity Map<TProject>(TProject project)
            => Mapper.Map<TEntity>(project);

        #endregion

        #region Save

        public async Task<SweetAlertExtenstion> SaveAsync()
        {
            return await DbContext.SaveChangesAsync() > 0 ? SweetAlertExtenstion.Ok() : SweetAlertExtenstion.Error();
        }

        public SweetAlertExtenstion Save()
        {
            return DbContext.SaveChanges() > 0 ? SweetAlertExtenstion.Ok() : SweetAlertExtenstion.Error();
        }

        #endregion
    }

}
