using Session2.Model;
using Session2.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Session2.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        List<Readers> readers = App.context.Readers.ToList();
        List<Books> books = App.context.Books.ToList();
        List<BookLoans> bookLoans = App.context.BookLoans.ToList();

        public InfoPage()
        {
            InitializeComponent();
            InfoLv.ItemsSource = App.context.Readers.ToList();
            InfoLv.ItemsSource = App.context.Readers.ToList();
            InfoLv.ItemsSource = App.context.Readers.ToList();

            InfoLv.SelectedIndex = 0;

            CountOfReadersTbl.DataContext = App.context.Readers.ToList();
            UpdateReadersCount();

        }
        public int CountReadersUnder20()
        {
            DateTime thresholdDate = DateTime.Now.AddYears(-20);
            return App.context.Readers.Count(reader => reader.BirthDay.HasValue && reader.BirthDay.Value > thresholdDate);

        }
        private void UpdateReadersCount()
        {
            int count = CountReadersUnder20();
            ReadersCountTbl.Text = $"{count}";
        }
        private void InfoLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTb.Text;

            InfoLv.ItemsSource = App.context.BookLoans
                .Where(ba => (ba.Readers.Surname.Contains(searchText) && ba.Books.Title.Contains(searchText)) ||
                (ba.Books.Cipher.Contains(searchText) && ba.Books.Title.Contains(searchText))
                || (ba.Books.Title.Contains(searchText) && ba.Books.Cipher.Contains(searchText))).ToList();

        }

        private void ReportBtn_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow();
            reportWindow.ShowDialog();
        }
    }
}
