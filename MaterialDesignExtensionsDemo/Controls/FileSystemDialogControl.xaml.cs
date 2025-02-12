﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MaterialDesignExtensions.Controls;

using MaterialDesignExtensionsDemo.ViewModel;

namespace MaterialDesignExtensionsDemo.Controls
{
    public partial class FileSystemDialogControl : UserControl
    {
        public FileSystemDialogControl()
        {
            InitializeComponent();
        }

        private async void OpenDirectoryDialogButtonClickHandler(object sender, RoutedEventArgs args)
        {
            OpenDirectoryDialogArguments dialogArgs = new OpenDirectoryDialogArguments()
            {
                Width = 600,
                Height = 400,
                CreateNewDirectoryEnabled = true
            };

            OpenDirectoryDialogResult result = await OpenDirectoryDialog.ShowDialogAsync(MainWindow.DialogHostName, dialogArgs);

            if (DataContext is FileSystemDialogViewModel viewModel)
            {
                if (!result.Canceled)
                {
                    viewModel.SelectedAction = "Selected directory: " + result.DirectoryInfo.FullName;
                }
                else
                {
                    viewModel.SelectedAction = "Cancel open directory";
                }
            }
        }

        private async void OpenFileDialogButtonClickHandler(object sender, RoutedEventArgs args)
        {
            OpenFileDialogArguments dialogArgs = new OpenFileDialogArguments()
            {
                Width = 600,
                Height = 400,
                Filters = "All files|*.*|C# files|*.cs|XAML files|*.xaml"
            };

            OpenFileDialogResult result = await OpenFileDialog.ShowDialogAsync(MainWindow.DialogHostName, dialogArgs);

            if (DataContext is FileSystemDialogViewModel viewModel)
            {
                if (!result.Canceled)
                {
                    viewModel.SelectedAction = "Selected file: " + result.FileInfo.FullName;
                }
                else
                {
                    viewModel.SelectedAction = "Cancel open file";
                }
            }
        }

        private async void SaveFileDialogButtonClickHandler(object sender, RoutedEventArgs args)
        {
            SaveFileDialogArguments dialogArgs = new SaveFileDialogArguments()
            {
                Width = 600,
                Height = 400,
                Filters = "All files|*.*|C# files|*.cs|XAML files|*.xaml",
                CreateNewDirectoryEnabled = true
            };

            SaveFileDialogResult result = await SaveFileDialog.ShowDialogAsync(MainWindow.DialogHostName, dialogArgs);

            if (DataContext is FileSystemDialogViewModel viewModel)
            {
                if (!result.Canceled)
                {
                    viewModel.SelectedAction = "Selected file: " + result.FileInfo.FullName;
                }
                else
                {
                    viewModel.SelectedAction = "Cancel save file";
                }
            }
        }
    }
}
