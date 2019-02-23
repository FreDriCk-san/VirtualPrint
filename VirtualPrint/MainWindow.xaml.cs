using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace VirtualPrint
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                var uriSource = new Uri(openFileDialog.InitialDirectory + openFileDialog.FileName);

                var bitmapImage = new BitmapImage(uriSource);

                sourceImage.Source = bitmapImage;
            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            var printDLG = new PrintDialog();

            if (printDLG.ShowDialog() == true)
            {
                var text = new Run("ЗАРАБОТАЛО!!!!");

                var textBlock = new TextBlock();
                textBlock.Inlines.Add(numTextBox.Text);
                textBlock.Margin = new Thickness(50, 20, 0, 0);

                var pageSize = new Size(printDLG.PrintableAreaWidth, printDLG.PrintableAreaHeight);
                textBlock.Measure(pageSize);
                textBlock.Arrange(new Rect(370, 60, pageSize.Width, pageSize.Height));

                printDLG.PrintVisual(textBlock, "Visual element printing (VS)");

            }
        }
    }
}
