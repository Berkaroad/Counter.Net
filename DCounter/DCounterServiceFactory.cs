using System;

namespace DCounter
{
    /// <summary>
    /// Distribute Counter Service Factory
    /// </summary>
    public abstract class DCounterServiceFactory
    {
        private static object locker = new object();
        private static IDCounterService instance = null;

        /// <summary>
        /// Create Distribute Counter Service
        /// </summary>
        /// <returns></returns>
        public static IDCounterService Create(Action<IDCounterProvider> initFunc)
        {
            lock(locker)
            {
                if (instance == null)
                {
                    instance = new DefaultDCounterService(initFunc);
                }
                return instance;
            }
        }
    }
}
