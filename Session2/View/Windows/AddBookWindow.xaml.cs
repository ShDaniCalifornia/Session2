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
using System.Windows.Shapes;

namespace Session2.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 1) Добавление записи в БД
                // Добавление записи в базу данных
                Books newBook = new Books()
                {
                    Title = TitleTb.Text,
                    Authors = AuthorsTb.Text,
                    Publisher = PublisherTb.Text,
                    PublicationYear = Convert.ToInt32(PublicationYearTb.Text),
                    AvailableCopies = Convert.ToInt32(CopiesTb.Text),
                    Cipher = CipherTb.Text,
                    LastBorrowedDate = (DateTime)LastBorrowedDatePic.SelectedDate,
                };

                // 2) Добавляем объект в таблицу
                App.context.Books.Add(newBook);

                // 3) Сохраняем изменения
                App.context.SaveChanges();

                // 4) Уведомить пользователя
                MessageBox.Show("Запись усппешно добавлена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                DialogResult = true;
            }
            catch
            {
                MessageBox.Show("Данные введены некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
