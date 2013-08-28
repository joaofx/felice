namespace Felice.Data
{
    using System;

    public class HybridInstanceScoper<T> : IInstanceScoper<T>
    {
        private readonly ThreadStaticInstanceScoper<T> threadStaticInstanceScoper;
        private readonly HttpContextInstanceScoper<T> httpContextInstanceScoper;

        public HybridInstanceScoper()
        {
            this.threadStaticInstanceScoper = new ThreadStaticInstanceScoper<T>();
            this.httpContextInstanceScoper = new HttpContextInstanceScoper<T>();
        }

        public T GetScopedInstance(string key, Func<T> builder)
        {
            IInstanceScoper<T> scoper = this.GetScoperToUse();
            return scoper.GetScopedInstance(key, builder);
        }

        public void ClearScopedInstance(string key)
        {
            IInstanceScoper<T> scoper = this.GetScoperToUse();
            scoper.ClearScopedInstance(key);
        }

        private IInstanceScoper<T> GetScoperToUse()
        {
            if (this.httpContextInstanceScoper.IsEnabled())
            {
                return this.httpContextInstanceScoper;
            }

            return this.threadStaticInstanceScoper;
        }
    }
}