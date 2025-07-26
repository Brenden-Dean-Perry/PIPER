using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIPER.Classes.Config
{
    public class PathsConfig
    {
        public string? InstallerPath { get; set; } = String.Empty;
        public string? EnvironmentPath { get; set; } = String.Empty;
        public string? JuypterKernelPath { get; set; } = String.Empty;
        public string? PythonURL { get; set; } = String.Empty;
    }
}
