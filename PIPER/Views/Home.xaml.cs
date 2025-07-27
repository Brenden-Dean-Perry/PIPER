using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using PIPER.Classes.Config;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PIPER.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        // Property to bind to the ComboBox  
        public ObservableCollection<Tuple<string, string>> PythonVersions { get; } = [];
        public ObservableCollection<Tuple<string, string>> InstallablePythonVersions { get; } = [];

        public Home()
        {
            this.InitializeComponent();
            LoadPythonVersions();
            LoadPythonVersionsAvilableForInstall();
        }

        private void comboPythonVersions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var path = (string)((ComboBox)sender).SelectedValue;
            // now use “path” as the selected Python installation folder
        }

        private void comboInstallablePythonVersions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var path = (string)((ComboBox)sender).SelectedValue;
            // now use “path” as the selected Python installation folder
        }

        private void Open_Install_Location_Button_Click(object sender, RoutedEventArgs e)
        {
            var path = Classes.Config.ConfigService.GetAppSettings().Paths.InstallerPath;
            if (Directory.Exists(path))
            {
                // Open the directory in File Explorer
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "explorer.exe",
                    Arguments = path,
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }
        }

        private void LoadPythonVersions()
        {
            PythonVersions.Add(Tuple.Create("3.8.10", @"C:\Python38\"));
            PythonVersions.Add(Tuple.Create("3.9.5", @"C:\Python39\"));
            PythonVersions.Add(Tuple.Create("3.10.7", @"C:\Python310\"));
        }

        private void LoadPythonVersionsAvilableForInstall()
        {
            InstallablePythonVersions.Add(Tuple.Create("3.8.10", @"C:\Python38\"));
            InstallablePythonVersions.Add(Tuple.Create("3.9.5", @"C:\Python39\"));
            InstallablePythonVersions.Add(Tuple.Create("3.10.7", @"C:\Python310\"));
        }

    }
}
