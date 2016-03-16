using System;
using System.Threading;
using System.Threading.Tasks;

namespace QASystem.Core
{
    /// <summary>
    /// 仓储事务功能
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 提交到数据库
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
        /// <summary>
        /// 异步提交到数据库
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
        /// <summary>
        /// 异步可取消式提交到数据库
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
