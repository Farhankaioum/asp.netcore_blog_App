using System;

namespace ksp.blog.data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
