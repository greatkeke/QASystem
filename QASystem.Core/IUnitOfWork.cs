using System;

namespace QASystem.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}
