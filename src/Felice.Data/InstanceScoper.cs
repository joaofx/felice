namespace Felice.Data
{
    using System;
    using System.Collections;

    public abstract class InstanceScoperBase<T> : IInstanceScoper<T>
    {
        protected abstract IDictionary GetDictionary();

        public T GetScopedInstance(string key, Func<T> builder)
        {
            if (!this.GetDictionary().Contains(key))
            {
                this.BuildInstance(key, builder);
            }

            return (T)this.GetDictionary()[key];
        }

        public void ClearScopedInstance(string key)
        {
            if (this.GetDictionary().Contains(key))
            {
                this.ClearInstance(key);
            }
        }

        public void ClearInstance(string key)
        {
            lock (this.GetDictionary().SyncRoot)
            {
                if (this.GetDictionary().Contains(key))
                {
                    this.RemoveInstance(key);
                }
            }
        }

        private void RemoveInstance(string key)
        {
            this.GetDictionary().Remove(key);
        }

        private void BuildInstance(string key, Func<T> builder)
        {
            lock (this.GetDictionary().SyncRoot)
            {
                if (!this.GetDictionary().Contains(key))
                {
                    this.AddInstance(key, builder);
                }
            }
        }

        private void AddInstance(string key, Func<T> builder)
        {
            T instance = builder.Invoke();
            this.GetDictionary().Add(key, instance);
        }
    }
}