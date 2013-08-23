namespace Felice.Core.Model
{
    using System;
    using System.Data;

    public interface IUnitOfWork : IDisposable
    {
        IUnitOfWork Begin(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Commit();
        void RollBack();
    }
}