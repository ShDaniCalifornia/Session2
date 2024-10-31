using System;
using System.Linq;
using System.Text;
using System.Windows;

namespace Session2.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
            UpdateReport();
        }
        private void UpdateReport()
        {
            // Общее количество книг и читателей
            var totalBooks = App.context.Books.Count();
            var totalReaders = App.context.Readers.Count();

            // Отображение количества книг и читателей
            TotalBooksTextBlock.Text = $"Общее количество книг: {totalBooks}";
            TotalReadersTextBlock.Text = $"Общее количество читателей: {totalReaders}";

            // Количество читателей, записавшихся в библиотеку за текущий месяц
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var registeredReaders = App.context.Readers.Count(r => r.RegistrationDate >= startOfMonth);
            RegisteredReadersTextBlock.Text = $"Читатели, записавшиеся за месяц: {registeredReaders}";

            // Книги, взятые за текущий месяц
            var borrowedBooks = App.context.BookLoans
            .Where(l => l.LoanDate >= startOfMonth)
            .GroupBy(l => l.IDBook)
            .Select(g => new
            {
                BookTitle = App.context.Books
                    .Where(b => b.IDBook == g.Key)
                    .Select(b => b.Title)
                    .FirstOrDefault(),
                Count = g.Count()
            }
            ).ToList();

            StringBuilder borrowedBooksInfo = new StringBuilder("Книги, взятые за месяц:\n");
            foreach (var book in borrowedBooks)
            {
                borrowedBooksInfo.AppendLine($"{book.BookTitle}: {book.Count} раз(а)");
            }
            BorrowedBooksTextBlock.Text = borrowedBooksInfo.ToString();

            // Читатели, которые не брали книги
            var readersWithoutLoans = App.context.Readers
                .Where(r => !App.context.BookLoans.Any(l => l.IDReader == r.IDReader)
                            && r.RegistrationDate < DateTime.Now)
                .Select(r => r.Surname)
                .ToList();

            ReadersWithoutLoansTextBlock.Text = "Читатели, не бравшие книги:\n" + string.Join(", ", readersWithoutLoans);
        }

        private void UpdateReportButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateReport();
        }
    }
}
