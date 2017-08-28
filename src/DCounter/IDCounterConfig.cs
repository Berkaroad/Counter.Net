using System;
using System.Collections.Generic;

namespace DCounter
{
    /// <summary>
    /// Storage Configuration
    /// </summary>
    public interface IDCounterConfig
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="config">key-value config</param>
        /// <param name="initFunc"></param>
        void Configure(Dictionary<string, string> config, Action<IDCounterProvider> initFunc);
    }
}
