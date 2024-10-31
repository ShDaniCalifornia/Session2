using Session2.Model;
using Session2.View.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Session2.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReadersPage.xaml
    /// </summary>
    public partial class ReadersPage : Page
    {
        List<Readers> readers = App.context.Readers.ToList();
        public ReadersPage()
        {
            InitializeComponent();
            ReadersLv.ItemsSource = App.context.Readers.ToList();

            // Выбираем элемент из списка по его индексу
            ReadersLv.SelectedIndex = 0;
        }

        private void ReadersLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            AddReaderWindow addReaderWindow = new AddReaderWindow();
            addReaderWindow.Show();
        }

        private void ChangeTicketNumberBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ReadersLv.SelectedItem is Readers selectedReader)
            {
                string oldTicketNumber = selectedReader.TicketNumber;
                int readerId = selectedReader.IDReader;

                // Открытие окна редактирования
                TicketChangeWindow ticketChangeWindow = new TicketChangeWindow(readerId, oldTicketNumber);
                ticketChangeWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите читателя из списка.");
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTb.Text.Trim().ToLower();
            ReadersLv.ItemsSource = App.context.Readers
                .Where(ba => ba.Surname.ToLower().Contains(searchText) || ba.TicketNumber.ToLower().Contains(searchText))
                .ToList();
        }

        private void DeleteReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedReader = (Readers)ReadersLv.SelectedItem;

            if (selectedReader != null)
            {
                var result = MessageBox.Show("Вы уверены, что хотите выписать читателя?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    // // Удаление связанных записей из BookLoans
                    var relatedBookLoans = App.context.BookLoans.Where(bl => bl.IDReader == selectedReader.IDReader).ToList();
                    foreach (var bookLoan in relatedBookLoans)
                    {
                        App.context.BookLoans.Remove(bookLoan);
                    }

                    // Удаление связанных записей из ReaderRegistrations
                    var relatedReg = App.context.ReaderRegistrations.Where(bt => bt.IDReader == selectedReader.IDReader).ToList();
                    foreach (var readerRegistrations in relatedReg)
                    {
                        App.context.ReaderRegistrations.Remove(readerRegistrations);
                    }

                    // Теперь можно удалить книгу
                    App.context.Readers.Remove(selectedReader);
                    App.context.SaveChanges();

                    // Обновляем список отображаемых книг
                    ReadersLv.ItemsSource = App.context.Readers.ToList();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите книгу для удаления.");
            }
        }
    }
}
