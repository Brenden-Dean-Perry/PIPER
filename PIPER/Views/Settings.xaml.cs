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
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class Settings : Page
    {
        readonly AppSettings appSettings = ConfigService.GetAppSettings();
        public Settings()
        {
            InitializeComponent();
            LoadAppSettings();
        }

        private async void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            await SaveData();
        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            LoadAppSettings();
        }

        private void LoadAppSettings()
        {
            // Load the app settings from the configuration
            PythonURL.Text = appSettings.Paths.PythonURL ?? string.Empty;
            InstallerDirectory.Text = appSettings.Paths.InstallerPath ?? string.Empty;
            EnvironmentDirectory.Text = appSettings.Paths.EnvironmentPath ?? string.Empty;
            KernelDirectory.Text = appSettings.Paths.JuypterKernelPath ?? string.Empty;
        }

        private async Task SaveData()
        {
            ContentDialog dialog = new ContentDialog();
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            dialog.XamlRoot = this.XamlRoot;
            dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog.Title = AppInfoService.GetAppInfo().AppName;
            dialog.PrimaryButtonText = "Save";
            //dialog.SecondaryButtonText = "Don't Save";
            dialog.CloseButtonText = "Cancel";
            dialog.DefaultButton = ContentDialogButton.Primary;
            dialog.Content = "Result:" + appSettings.Paths.PythonURL;

            var result = await dialog.ShowAsync();
        }
    }
}
