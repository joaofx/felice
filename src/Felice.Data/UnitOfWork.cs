namespace Felice.Data
{
    using System;
    using System.Data;
    using Core;
    using Felice.Core.Logs;
    using Felice.Core.Model;
    using NHibernate;

    public class UnitOfWork : IUnitOfWork
    {
        public static Func<IUnitOfWork> Instance = () => Dependency.Resolve<IUnitOfWork>();
        private readonly ISessionBuilder sessionBuilder;
        private ISession session;

        public UnitOfWork(ISessionBuilder sessionBuilder)
        {
            this.sessionBuilder = sessionBuilder;
        }

        public static ISession CurrentSession
        {
            get
            {
                return Instance().Session();
            }
        }

        public static void Using(Action action)
        {
            using (UnitOfWork.Instance().Begin())
            {
                action();
            }
        }

        public IUnitOfWork Begin(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (this.ThereIsActiveTransaction())
            {
                this.session.Transaction.Dispose();
            }

            this.session = this.sessionBuilder.GetSession();
            this.session.BeginTransaction(isolationLevel);

            Log.Framework.DebugFormat(
                "Session {0}: transaction begun {1}", 
                this.session.GetHashCode(),
                this.session.Transaction.GetHashCode());

            return this;
        }

        private bool ThereIsActiveTransaction()
        {
            if (this.session != null && this.session.Transaction != null)
            {
                return this.session.Transaction.IsActive;
            }

            return false;
        }

        public void Commit()
        {
            if (this.ThereIsActiveTransaction() == false)
            {
                throw new InvalidOperationException("There is no transaction in progress. Call Begin() before call Commit()");
            }

            if (this.session.Transaction.WasCommitted)
            {
                return;
            }

            this.session.Transaction.Commit();

            Log.Framework.DebugFormat(
                "Session {0}: transaction committed {1}",
                this.session.GetHashCode(),
                this.session.Transaction.GetHashCode());
        }

        public void RollBack()
        {
            if (this.session == null || this.session.Transaction == null)
            {
                return;
            }

            if (this.session.Transaction.IsActive)
            {
                this.session.Transaction.Rollback();

                Log.Framework.DebugFormat(
                    "Session {0}: transaction rolledback {1}",
                    this.session.GetHashCode(),
                    this.session.Transaction.GetHashCode());
            }
        }

        public void Dispose()
        {
            try
            {
                if (this.ThereIsActiveTransaction())
                {
                    this.Commit();
                }
            }
            catch
            {
                this.RollBack();
                throw;
            }
            finally
            {
                Log.Framework.DebugFormat(
                    "Session {0}: disposing",
                    this.session.GetHashCode());

                this.session.Transaction.Dispose();
                this.session.Dispose();
            }
        }
    }
}