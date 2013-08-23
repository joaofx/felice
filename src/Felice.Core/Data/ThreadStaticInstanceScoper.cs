namespace Felice.Core.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ThreadStaticInstanceScoper<T> : InstanceScoperBase<T>
    {
        [ThreadStatic]
        private static readonly IDictionary dictionary = new Dictionary<string, T>();

        protected override IDictionary GetDictionary()
        {
            return dictionary;
        }
    }
}