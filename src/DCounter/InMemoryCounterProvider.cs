using System;
using System.Collections.Generic;

namespace DCounter
{
    /// <summary>
    /// Counter in memory, just for test.
    /// </summary>
    public class InMemoryCounterProvider : IDCounterProvider
    {
        private static object locker = new object();
        private static Dictionary<string, long> store = new Dictionary<string, long>();

        public string ProviderName
        {
            get
            {
                return "in_memory";
            }
        }

        public void Configure(Dictionary<string, string> config, Action<IDCounterProvider> initFunc)
        {
            //
            if (initFunc != null)
            {
                initFunc(this);
            }
        }

        public long Get(string key)
        {
            lock (locker)
            {
                if (store.ContainsKey(key))
                {
                    return store[key];
                }
                else
                {
                    return 0;
                }
            }
        }

        public void IncreaseBy(string key, long step)
        {
            lock(locker)
            {
                step = Math.Abs(step);
                if (store.ContainsKey(key))
                {
                    store[key] += step;
                }
                else
                {
                    store.Add(key, step);
                }
            }
        }

        public void DecreaseBy(string key, long step)
        {
            lock (locker)
            {
                step = Math.Abs(step);
                if (store.ContainsKey(key))
                {
                    store[key] -= step;
                }
                else
                {
                    store.Add(key, -step);
                }
            }
        }

        public void Set(string key, long val)
        {
            lock (locker)
            {
                if (store.ContainsKey(key))
                {
                    store[key] = val;
                }
                else
                {
                    store.Add(key, val);
                }
            }
        }
    }
}
