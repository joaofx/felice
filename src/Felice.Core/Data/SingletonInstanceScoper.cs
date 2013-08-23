namespace Felice.Core.Data
{
    using System.Collections;
    using System.Collections.Generic;

    public class SingletonInstanceScoper<T> : InstanceScoperBase<T>
    {
        private static readonly IDictionary dictionary = new Dictionary<string, T>();

        protected override IDictionary GetDictionary()
        {
            return dictionary;
        }
    }
}