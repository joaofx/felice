namespace Felice.Core
{
    using System;

    public class AbstractFactoryBase<T>
    {
        protected static T DefaultUnconfiguredState()
        {
            throw new Exception(typeof(T).Name + " not configured.");
        }
    }
}