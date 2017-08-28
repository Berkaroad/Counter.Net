using System;

namespace DCounter
{
    /// <summary>
    /// Distribute Counter Provider
    /// </summary>
    public interface IDCounterProvider : IDCounterConfig
    {
        /// <summary>
		/// Provider Name
        /// </summary>
        string ProviderName { get; }

        /// <summary>
        /// Increase By specific step(absolute value) at specific key
        /// </summary>
        /// <param name="key">Sync: key1/key2, or key1</param>
        /// <param name="step">absolute value</param>
        void IncreaseBy(string key, long step);

        /// <summary>
        /// Decrease By specific step(absolute value) at specific key
        /// </summary>
        /// <param name="key">Sync: key1/key2, or key1</param>
        /// <param name="step">absolute value</param>
        void DecreaseBy(string key, long step);

        /// <summary>
        /// Get value at specific key
        /// </summary>
        /// <param name="key">Sync: key1/key2, or key1</param>
        /// <returns></returns>
        long Get(string key);

        /// <summary>
        /// Set value at specific key
        /// </summary>
        /// <param name="key">Sync: key1/key2, or key1</param>
        /// <param name="val"></param>
        void Set(string key, long val);
    }
}
