namespace Felice.Mvc
{
    public class FormContext<T>
    {
        public FormContext(T form, object result)
        {
            this.Form = form;
            this.Result = result;
        }

        public T Form { get; private set; }
        public object Result { get; private set; }
    }
}
