namespace Felice.Core.Mvc
{
    using System;
    using System.Web.Mvc;

    public class FormActionResult<T> : ActionResult
    {
        private readonly T form;
        public Action<T> Handler { get; set; }
        public string SuccessMessage;
        public Func<T, ActionResult> SuccessResult;
        public Func<T, ActionResult> FailureResult;

        public FormActionResult(T form)
        {
            this.form = form;
        }

        public FormActionResult(
            T form, 
            Action<T> handler, 
            Func<T, ActionResult> successResult,
            Func<T, ActionResult> failureResult)
        {
            this.form = form;
            this.Handler = handler;
            this.SuccessResult = successResult;
            this.FailureResult = failureResult;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var viewData = context.Controller.ViewData;

            if (viewData.ModelState.IsValid == false)
            {
                this.FailureResult(this.form).ExecuteResult(context);
            }
            else
            {
                try
                {
                    this.Handler(this.form);
                    this.SuccessResult(this.form).ExecuteResult(context);

                    if (string.IsNullOrEmpty(this.SuccessMessage) == false)
                    {
                        context.Controller.Success(this.SuccessMessage);    
                    }
                }
                catch (Exception exception)
                {
                    context.Controller.Error(exception.Message);
                    context.Controller.SetShouldRollback();
                    this.FailureResult(this.form).ExecuteResult(context);
                }
            }
        }
    }
}
