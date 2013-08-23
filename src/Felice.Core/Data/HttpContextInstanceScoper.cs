namespace Felice.Core.Data
{
    using System.Collections;
    using System.Web;

    public class HttpContextInstanceScoper<T> : InstanceScoperBase<T>
    {
        public bool IsEnabled()
        {
            return this.GetHttpContext() != null;
        }

        private HttpContext GetHttpContext()
        {
            return HttpContext.Current;
        }

        protected override IDictionary GetDictionary()
        {
            return this.GetHttpContext().Items;
        }
    }
}