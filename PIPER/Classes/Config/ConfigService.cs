using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PIPER.Classes.Config
{
    
    internal static class ConfigService
    {
        public static IConfigurationRoot Configuration { get; private set; }

        static ConfigService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }

        /// <summary>
        /// Retrieves the application settings by binding configuration values to an <see cref="AppSettings"/> instance.
        /// </summary>
        /// <remarks>This method initializes a new instance of the <see cref="AppSettings"/> class and
        /// populates it  with values from the application's configuration source using the default binding
        /// mechanism.</remarks>
        /// <returns>An <see cref="AppSettings"/> object containing the application's configuration settings.</returns>
        internal static AppSettings GetAppSettings()
        {
            var settings = new AppSettings();
            Configuration.Bind(settings);
            return settings;
        }

        /// <summary>
        /// Retrieves the configuration settings for paths from the application's configuration.
        /// </summary>
        /// <remarks>This method reads the "Paths" section from the application's configuration and
        /// deserializes it into a <see cref="PathsConfig"/> object. If the "Paths" section is missing or invalid, an
        /// exception is thrown.</remarks>
        /// <returns>A <see cref="PathsConfig"/> object containing the configuration settings for paths.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the "Paths" configuration section is missing or cannot be deserialized into a <see
        /// cref="PathsConfig"/> object.</exception>
        internal static PathsConfig GetPathsConfig()
        {
            PathsConfig? results = Configuration.GetSection("Paths").Get<PathsConfig>();
            if (results != null)
            {
                return results;
            }
            else
            {
                throw new InvalidOperationException("Paths configuration section is missing or invalid.");
            }
        }
    }

}
