﻿using Microsoft.EntityFrameworkCore;
using Project.Domain;
using Project.Infrastructure.Core;
using Project.Infrastructure.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Infrastructure.Repositories
{
    /// <summary>
    /// 功能描述    ：UnitRepository  
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/2/5 11:14:03 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/2/5 11:14:03 
    /// </summary>
    public class UnitRepository<TEntity> : IUnitRepository<TEntity> where TEntity : Entity
    {
        protected virtual ApplicationDbContext DbContext { get; set; }
        public virtual IUnitOfWork UnitOfWork => DbContext;
        /// <summary>
        /// 列表
        /// </summary>
        public virtual IQueryable<TEntity> Table => DbContext.Set<TEntity>();
        /// <summary>
        ///列表 AsNoTracking
        /// </summary>
        public virtual IQueryable<TEntity> TableNoTracking => DbContext.Set<TEntity>().AsNoTracking();

        public UnitRepository(ApplicationDbContext context)
        {
            this.DbContext = context;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Task<TEntity> AddAsync(TEntity entity)
        {

            return Task.FromResult(DbContext.Add(entity).Entity);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.FromResult(DbContext.Update(entity).Entity);
        }
        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Remove(Entity entity)
        {
            DbContext.Remove(entity);
            return true;
        }

        public virtual Task<bool> RemoveAsync(Entity entity)
        {
            return Task.FromResult(Remove(entity));
        }
    }
}
