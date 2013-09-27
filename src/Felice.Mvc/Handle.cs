namespace Felice.Mvc
{
    using System;
    using System.Web.Mvc;

    public static class Handle
    {
        public static FormActionResult<T> With<T>(this FormActionResult<T> result, Action<T> handler)
        {
            result.Handler = handler;
            return result;
        }

        public static FormActionResult<T> OnSuccess<T>(
            this FormActionResult<T> result, 
            Func<T, ActionResult> successResult, 
            string message = "",
            params object[] messageArgs)
        {
            result.SuccessMessage = string.Format(message, messageArgs);
            result.SuccessResult = successResult;
            return result;
        }

        public static FormActionResult<T> OnFailure<T>(
            this FormActionResult<T> result, 
            Func<T, ActionResult> failureResult)
        {
            result.FailureResult = failureResult;
            return result;
        }
    }
}
