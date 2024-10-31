using Session2.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Session2.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReadingRoomsPage.xaml
    /// </summary>
    public partial class ReadingRoomsPage : Page
    {
        List<ReadingRooms> pages = App.context.ReadingRooms.ToList();
        public ReadingRoomsPage()
        {
            InitializeComponent();
            ReadingRoomsLv.ItemsSource = App.context.ReadingRooms.ToList();

            ReadingRoomsLv.SelectedIndex = 0;
        }

        private void ReadingRoomsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
