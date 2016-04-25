using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCounter
{
    /// <summary>
    /// Stream Storage Service
    /// </summary>
    public interface IDCounterService
    {
		/// <summary>
		/// Service Name
		/// </summary>
		/// <value>The name of the service.</value>
		string ServiceName { get; }
		
        /// <summary>
        /// Distribute Counter Provider
        /// </summary>
        IDCounterProvider Provider { get; }
	}
}
