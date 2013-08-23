namespace Nails.Framework.Mvc
{
    using System;
    using System.Web;
    using System.Web.SessionState;
    using Data;
    using Model;

    public class UnitOfWorkModule : IHttpModule
    {
        public bool IsStaticFile(HttpApplication context)
        {
            return context.Context.Handler is IRequiresSessionState == false;
        }

        public void Init(HttpApplication context)
        {
            if (this.IsStaticFile(context))
            {
                return;
            }

            context.BeginRequest += this.ContextBeginRequest;
            context.EndRequest += this.ContextEndRequest;
        }

        public void Dispose() { }

        private void ContextBeginRequest(object sender, EventArgs e)
        {
            IUnitOfWork instance = UnitOfWorkFactory.GetDefault();
            instance.Begin();
        }

        private void ContextEndRequest(object sender, EventArgs e)
        {
            IUnitOfWork instance = UnitOfWorkFactory.GetDefault();
            try
            {
                instance.Commit();
            }
            catch
            {
                instance.RollBack();
                //throw;
            }
            finally
            {
                instance.Dispose();
            }
        }
    }
}