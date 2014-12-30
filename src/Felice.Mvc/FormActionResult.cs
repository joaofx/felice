namespace Felice.Mvc
{
    using System;
    using System.Web.Mvc;

    public class FormActionResult<T> : ActionResult
    {
        private readonly T _form;
        public Action<T> Handler { get; set; }
        public string SuccessMessage;
        public Func<T, ActionResult> SuccessResult;
        public Func<T, ActionResult> FailureResult;

        public FormActionResult(T form)
        {
            _form = form;
        }

        public FormActionResult(
            T form, 
            Action<T> handler, 
            Func<T, ActionResult> successResult,
            Func<T, ActionResult> failureResult)
        {
            _form = form;
            Handler = handler;
            SuccessResult = successResult;
            FailureResult = failureResult;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var viewData = context.Controller.ViewData;

            if (viewData.ModelState.IsValid == false)
            {
                FailureResult(_form).ExecuteResult(context);
            }
            else
            {
                try
                {
                    Handler(_form);
                    SuccessResult(_form).ExecuteResult(context);

                    if (string.IsNullOrEmpty(SuccessMessage) == false)
                    {
                        context.Controller.Success(SuccessMessage);    
                    }
                }
                catch (Exception exception)
                {
                    context.Controller.Error(exception.Message);

                    //// TODO: this rollback is smell?
                    context.Controller.SetShouldRollback();

                    FailureResult(_form).ExecuteResult(context);
                }
            }
        }
    }
}
