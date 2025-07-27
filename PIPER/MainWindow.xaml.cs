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
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinRT.Interop;
using static System.Net.WebRequestMethods;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PIPER
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetAppIcon();
        }

        private void SetAppIcon()
        {
            if (AppWindowTitleBar.IsCustomizationSupported()) // Optional: Check if title bar customization is supported
            {
                IntPtr hWnd = WindowNative.GetWindowHandle(this);
                WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);
                AppWindow appWindow = AppWindow.GetFromWindowId(wndId);

                // Set the icon
                appWindow.SetIcon("CustomAssets\\AppLogo.ico");
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            FrameNavigationOptions navOptions = new FrameNavigationOptions();
            navOptions.TransitionInfoOverride = args.RecommendedNavigationTransitionInfo;
            if (sender.PaneDisplayMode == NavigationViewPaneDisplayMode.Top)
            {
                navOptions.IsNavigationStackEnabled = false;
            }

            Type pageType;
            if (args.IsSettingsInvoked == true)
            {
                pageType = typeof(Views.Settings);
            }
            else if((NavigationViewItem)args.InvokedItemContainer == homePage)
            {
                pageType = typeof(Views.Home);
            }
            else if ((NavigationViewItem)args.InvokedItemContainer == pythonDownloadPage)
            {
                pageType = typeof(Views.PythonDownload);
            }
            else if ((NavigationViewItem)args.InvokedItemContainer == environmentPage)
            {
                pageType = typeof(Views.EnvironmentManager);
            }
            else if ((NavigationViewItem)args.InvokedItemContainer == packageInstallPage)
            {
                pageType = typeof(Views.PackageManager);
            }
            else if ((NavigationViewItem)args.InvokedItemContainer == kernelPage)
            {
                pageType = typeof(Views.KernelManager);
            }
            else if((NavigationViewItem)args.InvokedItemContainer == logPage)
            {
                pageType = typeof(Views.LogPage);
            }
            else
            {
                throw new ArgumentException("Invalid navigation item invoked", nameof(args.InvokedItem));
            }
             contentFrame.NavigateToType(pageType, null, navOptions);
        }

    }
}
