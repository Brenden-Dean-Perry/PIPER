using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PIPER
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private Type? _lastPageType = null;
        public MainWindow()
        {
            InitializeComponent();
            SetAppIcon();

            // Initialize the NavigationView
            homePage.IsSelected = true;
            contentFrame.Navigate(typeof(Views.Home));
        }

        private void SetAppIcon()
        {
            if (AppWindowTitleBar.IsCustomizationSupported()) // Optional: Check if title bar customization is supported
            {
                IntPtr hWnd = WindowNative.GetWindowHandle(this);
                WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);
                AppWindow appWindow = AppWindow.GetFromWindowId(wndId);
                appWindow.SetIcon("CustomAssets\\AppLogo.ico");
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            FrameNavigationOptions navOptions = new FrameNavigationOptions
            {
                TransitionInfoOverride = args.RecommendedNavigationTransitionInfo
            };

            if (sender.PaneDisplayMode == NavigationViewPaneDisplayMode.Top)
            {
                navOptions.IsNavigationStackEnabled = false;
            }

            Type? pageType = args.IsSettingsInvoked switch
            {
                true => typeof(Views.Settings),
                false when args.InvokedItemContainer == homePage => typeof(Views.Home),
                false when args.InvokedItemContainer == pythonDownloadPage => typeof(Views.PythonDownload),
                false when args.InvokedItemContainer == environmentPage => typeof(Views.EnvironmentManager),
                false when args.InvokedItemContainer == packageInstallPage => typeof(Views.PackageManager),
                false when args.InvokedItemContainer == kernelPage => typeof(Views.KernelManager),
                false when args.InvokedItemContainer == logPage => typeof(Views.LogPage),
                _ => null
            };

            if (pageType == null)
            {
                return;
            }

            if (_lastPageType == pageType)
            {
                return;
            }

            contentFrame.NavigateToType(pageType, null, navOptions);
            _lastPageType = pageType;
        }

    }
}
