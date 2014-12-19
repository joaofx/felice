namespace Felice.Data
{
    using System;
    using System.Data;
    using Core;
    using Felice.Core.Logs;
    using Felice.Core.Model;
    using NHibernate;
    using StructureMap;

    public class UnitOfWork : IUnitOfWork
    {
        public static Func<IUnitOfWork> Instance = () => Dependency.Resolve<IUnitOfWork>();
        private ISession _session;

        //public static ISession CurrentSession
        //{
        //    get
        //    {
        //        return Instance().Session();
        //    }
        //}

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
                this._session.Transaction.Dispose();
            }

            //// TODO: is this dependency resolving a smell?
            this._session = Dependency.Resolve<ISession>();
            this._session.BeginTransaction(isolationLevel);

            Log.Framework.DebugFormat(
                "Session {0}: transaction begun {1}", 
                this._session.GetHashCode(),
                this._session.Transaction.GetHashCode());

            return this;
        }

        private bool ThereIsActiveTransaction()
        {
            if (this._session != null && this._session.Transaction != null)
            {
                return this._session.Transaction.IsActive;
            }

            return false;
        }

        public void Commit()
        {
            if (this.ThereIsActiveTransaction() == false)
            {
                throw new InvalidOperationException("There is no transaction in progress. Call Begin() before call Commit()");
            }

            if (this._session.Transaction.WasCommitted)
            {
                return;
            }

            this._session.Transaction.Commit();

            Log.Framework.DebugFormat(
                "Session {0}: transaction committed {1}",
                this._session.GetHashCode(),
                this._session.Transaction.GetHashCode());
        }

        public void RollBack()
        {
            if (this._session == null || this._session.Transaction == null)
            {
                return;
            }

            if (this._session.Transaction.IsActive)
            {
                this._session.Transaction.Rollback();

                Log.Framework.DebugFormat(
                    "Session {0}: transaction rolledback {1}",
                    this._session.GetHashCode(),
                    this._session.Transaction.GetHashCode());
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
                    this._session.GetHashCode());

                this._session.Transaction.Dispose();
                this._session.Dispose();
            }
        }
    }
}