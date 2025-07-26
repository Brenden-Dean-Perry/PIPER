using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PIPER.Classes.Config
{
    internal static class AppInfoService
    {
        internal static AppInfo GetAppInfo()
        {
            return new AppInfo
            {
                AppName = Assembly.GetEntryAssembly()?.GetName().Name ?? "Unknown App",
                Version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "Unknown Version"
            };
        }
    }
}
