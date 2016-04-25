using System;

namespace DCounter
{
    /// <summary>
    /// 
    /// </summary>
    public class LoadConfigurationException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public LoadConfigurationException(string message, Exception innerException) :base(message, innerException) { }
    }
}
