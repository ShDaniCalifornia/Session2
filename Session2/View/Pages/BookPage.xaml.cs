using Session2.Model;
using Session2.View.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Session2.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BookPage.xaml
    /// </summary>
    public partial class BookPage : Page
    {
        List<Books> books = App.context.Books.ToList();
        public BookPage()
        {
            InitializeComponent();
            BooksLv.ItemsSource = App.context.Books.ToList();
            // Выбираем элемент из списка по его индексу
            BooksLv.SelectedIndex = 0;
        }

        private void BooksLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow = new AddBookWindow();
            addBookWindow.Show();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchTb.Text))
            {
                BooksLv.ItemsSource = App.context.Books
                    .Where(ba => ba.Authors.Contains(SearchTb.Text) || ba.Title.Contains(SearchTb.Text))
                    .ToList();
            }
            else
            {
                // Обработка случая, когда строка поиска пустая, например:
                BooksLv.ItemsSource = App.context.Books.ToList();
            }
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = (Books)BooksLv.SelectedItem;

            if (selectedBook != null)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить эту книгу?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    // Удаление связанных записей из BookLoans
                    var relatedBookLoans = App.context.BookLoans.Where(bl => bl.IDBook == selectedBook.IDBook).ToList();
                    foreach (var bookLoan in relatedBookLoans)
                    {
                        App.context.BookLoans.Remove(bookLoan);
                    }

                    // Удаление связанных записей из BookTransfers
                    var relatedBookTransfers = App.context.BookTransfers.Where(bt => bt.IDBook == selectedBook.IDBook).ToList();
                    foreach (var bookTransfer in relatedBookTransfers)
                    {
                        App.context.BookTransfers.Remove(bookTransfer);
                    }

                    // Удаление книги
                    App.context.Books.Remove(selectedBook);
                    App.context.SaveChanges();

                    // Обновление списка отображаемых книг
                    BooksLv.ItemsSource = App.context.Books.ToList();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите книгу для удаления.");
            }
        }
    }

}

