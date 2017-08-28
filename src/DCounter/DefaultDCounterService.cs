using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DCounter
{
    internal class DefaultDCounterService : AbstractDCounterService
    {
        internal DefaultDCounterService(Action<IDCounterProvider> initFunc)
        {
            Configure(initFunc);
        }

        /// <summary>
		/// Service Name
		/// </summary>
		/// <value>The name of the service.</value>
		public override string ServiceName
		{
			get { return "stream_storage"; }
		}

        private void Configure(Action<IDCounterProvider> initFunc)
        {
			string configFile = RuntimeEnvironment.GetPhysicalApplicationPath() + Path.DirectorySeparatorChar + "DCounter.ini";
                try
            {
                IniParser.StreamIniDataParser parser = new IniParser.StreamIniDataParser();
                string assemblyName = "";
                string typeName = "";
                Dictionary<string, string> config = new Dictionary<string, string>();
                using (StreamReader sr = File.OpenText(configFile))
                {
                    var data = parser.ReadData(sr);
                    var globalConfig = data["dcounter"];
                    string configType = globalConfig["counterType"];
                    var specificConfig = data[configType];
                    config = specificConfig.Where(c => c.KeyName != "__class").ToDictionary(c => c.KeyName, c => c.Value);
                    var className = specificConfig["__class"];
                    int classNameSepIndex = className.LastIndexOf(',');
                    assemblyName = className.Substring(0, classNameSepIndex).Trim();
                    typeName = className.Substring(classNameSepIndex + 1).Trim();
                }

				ConfigureProvider(assemblyName, typeName, config, initFunc);
            }
            catch(Exception ex)
            {
                throw new LoadConfigurationException("Load configuration file \"" + configFile + "\" error!", ex);
            }
        }
    }
}
