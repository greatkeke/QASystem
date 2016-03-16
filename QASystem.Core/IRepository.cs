using System.Collections.Generic;
using System.Linq;

namespace QASystem.Core
{
    /// <summary>
    /// 仓储
    /// </summary>
    public partial interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        T GetById(object id);

        /// <summary>
        /// 新增一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Insert(T entity);

        /// <summary>
        /// 新增实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Insert(IEnumerable<T> entities);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Update(T entity);

        /// <summary>
        /// 修改实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Update(IEnumerable<T> entities);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Delete(T entity);

        /// <summary>
        /// 删除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Delete(IEnumerable<T> entities);

        /// <summary>
        /// 数据表
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// 不被上下文跟踪的数据表(用它获取的数据只进行读操作)
        /// </summary>
        IQueryable<T> TableNoTracking { get; }
    }
}
