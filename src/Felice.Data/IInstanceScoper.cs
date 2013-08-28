namespace Felice.Data
{
    using System;

    public interface IInstanceScoper<T>
    {
        T GetScopedInstance(string key, Func<T> builder);

        void ClearScopedInstance(string key);
    }
}