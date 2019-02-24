using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
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

            var arrayOfModels = new Model.TextModel[]
            {
                new Model.TextModel(numTextBox.Text, 590, 120),
                new Model.TextModel(day.Text, 195, 140),
                new Model.TextModel(month.Text, 280, 140),
                new Model.TextModel(year.Text, 380, 140),
                new Model.TextModel(carBrand.Text, 240, 240),
                new Model.TextModel(licensePlate.Text, 330, 260),
                new Model.TextModel(driver.Text, 180, 280),
                new Model.TextModel(certificate.Text, 230, 310),
                new Model.TextModel(persNum.Text, 890, 275),
                new Model.TextModel(departure.Text, 190, 513),
                new Model.TextModel(returns.Text, 190, 535),
                new Model.TextModel(orderBySome.Text, 150, 650),
                //new Model.TextModel(workType.Text, 0, 0),
                //new Model.TextModel(dispatcherSign.Text, 0, 0),
                //new Model.TextModel(mechanicSign.Text, 0, 0),
                //new Model.TextModel(driverSign.Text, 0, 0),
                //new Model.TextModel(passedDriver.Text, 0, 0),
                //new Model.TextModel(acceptedMech.Text, 0, 0)
            };

            var arrayOfTextBlocks = new TextBlock[arrayOfModels.Length];

            if (printDLG.ShowDialog() == true)
            {
                try
                {
                    var index = 0;

                    foreach (var item in arrayOfModels)
                    {
                        var textBlock = new TextBlock();
                        textBlock.Inlines.Add(item.Content);
                        textBlock.Margin = new Thickness(item.Xposition, item.YPosition, 0, 0);

                        var pageSize = new Size(printDLG.PrintableAreaWidth, printDLG.PrintableAreaHeight);
                        textBlock.Measure(pageSize);
                        textBlock.Arrange(new Rect(item.Xposition, item.YPosition, pageSize.Width, pageSize.Height));
                        arrayOfTextBlocks[index] = textBlock;

                        index++;
                    }

                    var tempGrid = new Grid();

                    foreach (var item in arrayOfTextBlocks)
                    {
                        tempGrid.Children.Add(item);
                    }

                    printDLG.PrintVisual(tempGrid, "Visual element printing (VS)");
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"ОШИБКА: {exception.Message}. Свяжитесь с разработчиком!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
