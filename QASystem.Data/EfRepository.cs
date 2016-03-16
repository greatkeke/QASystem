using System;
using System.Collections.Generic;
using System.Linq;
using QASystem.Core;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace QASystem.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        #region Fields

        private readonly DbContext _context;
        private IDbSet<T> _entities;

        #endregion

        #region Ctor

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="context">支持事务的上下文对象</param>
        public EfRepository(IUnitOfWork uow)
        {
            this._context = uow as QASystemDbContext;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// 获取所有的错误
        /// </summary>
        /// <param name="exc">异常</param>
        /// <returns>异常文本</returns>
        protected string GetFullErrorText(DbEntityValidationException exc)
        {
            var msg = string.Empty;
            foreach (var validationErrors in exc.EntityValidationErrors)
                foreach (var error in validationErrors.ValidationErrors)
                    msg += string.Format("Property: {0} Error: {1}", error.PropertyName, error.ErrorMessage) + Environment.NewLine;
            return msg;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public virtual T GetById(object id)
        {
            //缓存
            return this.Entities.Find(id);
        }

        /// <summary>
        /// 新增一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual T Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                return this.Entities.Add(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// 新增实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");
                foreach (var entity in entities)
                    this.Entities.Add(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// 修改实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                this.Entities.Remove(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// 删除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    this.Entities.Remove(entity);

            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 数据表
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        /// <summary>
        /// 不被上下文跟踪的数据表(用它获取的数据只进行读操作)
        /// </summary>
        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }

        /// <summary>
        /// 实体集合
        /// </summary>
        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }

        #endregion
    }
}
