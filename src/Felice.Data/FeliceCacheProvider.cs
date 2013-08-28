namespace Felice.Data
{
    using System.Collections.Generic;
    using NHibernate.Cache;
    using NHibernate.Caches.SysCache;

    public class FeliceCacheProvider : ICacheProvider
    {
        private static readonly Dictionary<string, ICache> caches = new Dictionary<string, ICache>();

        static FeliceCacheProvider()
        {
            caches.Add("10m", CreateCache("10m", 60 * 10, 1));
            caches.Add("30m", CreateCache("30m", 60 * 30, 1));
            caches.Add("1d", CreateCache("1d", 60 * 60 * 24, 1));
        }

        public ICache BuildCache(string regionName, IDictionary<string, string> properties)
        {
            if (regionName == null)
            {
                regionName = string.Empty;
            }

            ICache result;
            if (caches.TryGetValue(regionName, out result))
            {
                return result;
            }

            // create cache
            if (properties == null)
            {
                properties = new Dictionary<string, string>(1);
            }

            return new SysCache(regionName, properties);
        }

        public long NextTimestamp()
        {
            return Timestamper.Next();
        }

        public void Start(IDictionary<string, string> properties)
        {
        }

        public void Stop()
        {
        }

        private static ICache CreateCache(string region, int minutes, int priority)
        {
            return new SysCache(region, new Dictionary<string, string>
            {
                { "expiration", minutes.ToString() }, 
                { "priority", priority.ToString() }
            });
        }
    }
}
