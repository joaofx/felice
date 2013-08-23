namespace Felice.Core.Mvc
{
    using System.Web.Mvc;

    public static class FlashExtensions
    {
        private const string AlertKey = "Framework.Alert";
        private const string SuccessKey = "Framework.Success";
        private const string ErrorKey = "Framework.Error";

        public static void Alert(this ControllerBase controller, string message)
        {
            controller.TempData[AlertKey] = message;
        }

        public static void Success(this ControllerBase controller, string message)
        {
            controller.TempData[SuccessKey] = message;
        }

        public static void Error(this ControllerBase controller, string message)
        {
            controller.TempData[ErrorKey] = message;
        }

        public static MvcHtmlString GetAlert(this HtmlHelper helper)
        {
            return GetFlashMessage(helper, AlertKey, "warning");
        }

        public static MvcHtmlString GetSuccess(this HtmlHelper helper)
        {
            return GetFlashMessage(helper, SuccessKey, "notice");
        }

        public static MvcHtmlString GetError(this HtmlHelper helper)
        {
            return GetFlashMessage(helper, ErrorKey, "error");
        }

        private static MvcHtmlString GetFlashMessage(
            HtmlHelper helper, 
            string tempDataKey, 
            string cssClass)
        {
            if (helper.ViewContext.TempData.ContainsKey(tempDataKey))
            {
                var message = helper.ViewContext.TempData[tempDataKey];
                return new MvcHtmlString(string.Format(
                    @"<div class=""flash {1}"">{0}</div>", 
                    message,
                    cssClass));
            }

            return MvcHtmlString.Empty;
        }
    }
}
