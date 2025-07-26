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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PIPER.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KernelManager : Page
    {
        public ObservableCollection<Tuple<string, string>> PythonEnvironments { get; } = [];
        public ObservableCollection<Tuple<string, string>> PythonKernels { get; } = [];
        public KernelManager()
        {
            InitializeComponent();
            LoadPythonEnvironments();
            LoadPythonKernels();
        }

        private void comboKernel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var path = (string)((ComboBox)sender).SelectedValue;
            // now use “path” as the selected Python kernel
        }

        private void comboEnvironment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var path = (string)((ComboBox)sender).SelectedValue;
            // now use “path” as the selected Python environment
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            // Logic to delete the selected kernel
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            // Logic to create a new kernel
        }
        private void LoadPythonEnvironments()
        {
            PythonEnvironments.Add(Tuple.Create("Py38", @"C:\Python38\"));
            PythonEnvironments.Add(Tuple.Create("Py39", @"C:\Python39\"));
            PythonEnvironments.Add(Tuple.Create("Py310", @"C:\Python310\"));
        }

        private void LoadPythonKernels()
        {
            PythonKernels.Add(Tuple.Create("Py38", @"C:\Python38\"));
            PythonKernels.Add(Tuple.Create("Py39", @"C:\Python39\"));
            PythonKernels.Add(Tuple.Create("Py310", @"C:\Python310\"));
        }

    }
}
