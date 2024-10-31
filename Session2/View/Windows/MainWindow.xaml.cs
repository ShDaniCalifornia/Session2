using Session2.AppData;
using System;
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
using System.Windows.Shapes;

namespace Session2.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FrameHelper.FrameBody = FrameBody;
            FrameBody.Navigate(new View.Pages.InfoPage());
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.FrameBody.Navigate(new View.Pages.InfoPage());
        }

        private void ReadersBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.FrameBody.Navigate(new View.Pages.ReadersPage());
        }

        private void BooksBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.FrameBody.Navigate(new View.Pages.BookPage());
        }

        private void ReadingRoomsBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.FrameBody.Navigate(new View.Pages.ReadingRoomsPage());
        }
    }
}
