using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using PIPER.Classes.Config;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PIPER.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PythonDownload : Page
    {
        public string FooterText => $"Version {AppInfoService.GetAppInfo().Version}";
        public PythonDownload()
        {
            InitializeComponent();
            this.DataContext = this;
            string? URL = ConfigService.GetAppSettings().Paths.PythonURL;
            if (URL is not null)
            {
                MyWebView2.Source = new System.Uri(URL);
            }
        }
    }
}
