using System;
using System.Collections.Generic;

namespace DCounter
{
    /// <summary>
    /// Abstract Distribute Counter Service
    /// </summary>
    public abstract class AbstractDCounterService : IDCounterService
    {

        /// <summary>
        /// Configure Distribute Counter Provider
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="typeName"></param>
        /// <param name="config"></param>
        /// <param name="initProvider"></param>
        protected void ConfigureProvider(string assemblyName, string typeName, Dictionary<string, string> config, Action<IDCounterProvider> initProvider)
        {
            var assem = System.Reflection.Assembly.Load(assemblyName);
            Provider = assem.CreateInstance(typeName) as IDCounterProvider;
            Provider.Configure(config, initProvider);
        }

        /// <summary>
		/// Service Name
		/// </summary>
		/// <value>The name of the service.</value>
		public abstract string ServiceName { get; }

        /// <summary>
        /// Distribute Counter Provider
        /// </summary>
        public IDCounterProvider Provider
        {
            get; private set;
        }
    }
}
