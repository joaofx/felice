namespace Felice.Core.Mvc
{
    using System.Web.Mvc;
    using Data;
    using Model;

    public class UnitOfWorkFilter : ActionFilterAttribute
    {
        private IUnitOfWork instance;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.instance = UnitOfWork.Instance();
            this.instance.Begin();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            ////var instance = UnitOfWork.Instance();

            try
            {
                if (filterContext.Controller.ShouldRollback())
                {
                    this.instance.RollBack();
                }
                else
                {
                    this.instance.Commit();    
                }
            }
            catch
            {
                this.instance.RollBack();
                throw;
            }
            finally
            {
                this.instance.Dispose();
            }
        }
    }
}