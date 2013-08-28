namespace Felice.Mvc
{
    using System.Web.Mvc;

    public static class ControllerExtensions
    {
        public static EnrichedViewResult<T> EnrichedView<T>(this ControllerBase controller, T model)
        {
            return EnrichedView(controller, null, model);
        }

        public static EnrichedViewResult<T> EnrichedView<T>(
            this ControllerBase controller, string viewName, T model)
        {
            if (model != null)
            {
                controller.ViewData.Model = model;
            }

            return new EnrichedViewResult<T>(viewName, controller.ViewData);
        }

        public static FormActionResult<T> Handle<T>(this ControllerBase controller, T form)
        {
            return new FormActionResult<T>(form)
            {
                FailureResult = cmd => controller.EnrichedView(cmd)
            };
        }

        public static bool ShouldRollback(this ControllerBase controller)
        {
            return controller.ViewBag.ShouldRollback != null && 
                controller.ViewBag.ShouldRollback == true;
        }

        public static void SetShouldRollback(this ControllerBase controller)
        {
            controller.ViewBag.ShouldRollback = true;
        }
    }
}
