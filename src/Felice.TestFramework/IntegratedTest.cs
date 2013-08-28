namespace Felice.TestFramework
{
    using System;
    using System.Linq.Expressions;
    using Core;
    using Core.Logs;
    using Core.Model;
    using Data;
    using NHibernate;

    public class IntegratedTest : AutomatedTest
    {
        protected IUnitOfWork unitOfWork;

        protected IntegratedTest()
        {
            var connectionString = SettingsConfig.DatabaseConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                return;
            }

            if ((connectionString.Contains("_test") || connectionString.Contains("_integration")) == false)
            {
                throw new NUnit.Framework.AssertionException(
                    "You are not using a test or integration database. Use a database with _test or _integration in the name.");
            }

            Database.Initialize();
            ////Database.ExportSchema();
            Database.MigrateToLastVersion();
        }

        public virtual void Scenario()
        {
        }

        public override void BeforeTest()
        {
            this.unitOfWork = UnitOfWork.Instance();

            using (this.unitOfWork.Begin())
            {
                this.CleanAllTables();
                this.Scenario();
            }

            this.unitOfWork.Begin();
        }

        public override void AfterTest()
        {
            this.unitOfWork.Commit();
            this.unitOfWork.Dispose();
        }

        public void CleanAllTables()
        {
            Log.Framework.Debug("Cleaning tables");
            var databaseCleaner = Dependency.Resolve<IDatabaseCleaner>();

            if (databaseCleaner == null)
            {
                throw new InvalidOperationException(
                    "Implementation of IDatabaseCleaner was not found. Couldn't clean database");
            }

            databaseCleaner.Execute();
            Log.Framework.Debug("Tables were cleaned");
        }

        protected void RecreateSession()
        {
            Log.Framework.Debug("Recreating session");

            this.unitOfWork.Dispose();
            this.unitOfWork = UnitOfWork.Instance();
            this.unitOfWork.Begin();
        }

        protected bool IsPropertyLazy<T, TProperty>(
            T entity,
            Expression<Func<T, TProperty>> action) where T : Entity
        {
            var expression = (MemberExpression)action.Body;
            string propertyName = expression.Member.Name;

            entity.Persist();
            this.RecreateSession();

            var fetched = this.unitOfWork.Session().Get<T>(entity.Id);
            return NHibernateUtil.IsPropertyInitialized(fetched, propertyName) == false;
        }
    }
}