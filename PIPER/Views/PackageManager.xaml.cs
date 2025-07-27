using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PIPER.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PackageManager : Page
    {
        public ObservableCollection<Tuple<string, string>> PythonEnvironments { get; } = [];
        public PackageManager()
        {
            InitializeComponent();
            LoadPythonEnvironments();
        }

        private void Install_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadPythonEnvironments()
        {
            PythonEnvironments.Add(Tuple.Create("Py38", @"C:\Python38\"));
            PythonEnvironments.Add(Tuple.Create("Py39", @"C:\Python39\"));
            PythonEnvironments.Add(Tuple.Create("Py310", @"C:\Python310\"));
        }

        private void comboEnvironment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var path = (string)((ComboBox)sender).SelectedValue;

        }

        private void Generate_Requirements_Button_Click(object sender, RoutedEventArgs e)
        {
            // Logic to create a new kernel
        }

        private void Install_All_Requirements_Button_Click(object sender, RoutedEventArgs e)
        {
            // Logic to install requirements
        }

        private void Git_Install_Button_Click(object sender, RoutedEventArgs e)
        {
            // Logic to install from git repository
        }

        private async void PickAFileButton_Click(object sender, RoutedEventArgs e)
        {
            //disable the button to avoid double-clicking
            var senderButton = sender as Button;
            senderButton.IsEnabled = false;

            PickAFileOutputTextBlock.Text = "";
            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();

            // See the sample code below for how to make the window accessible from the App class.
            var window = App.MainWindow;

            // Retrieve the window handle (HWND) of the current WinUI 3 window.
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

            // Initialize the file picker with the window handle (HWND).
            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);

            // Set options for your file picker
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.FileTypeFilter.Add(".txt");

            // Open the picker for the user to pick a file
            var file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                PickAFileOutputTextBlock.Text = "Picked file: " + file.Name;
            }
            else
            {
                PickAFileOutputTextBlock.Text = "Operation cancelled.";
            }
            senderButton.IsEnabled = true;
        }
    }
}
