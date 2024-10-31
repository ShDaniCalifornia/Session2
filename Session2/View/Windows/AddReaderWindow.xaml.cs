using Session2.Model;
using System;
using System.Windows;

namespace Session2.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddReaderWindow.xaml
    /// </summary>
    public partial class AddReaderWindow : Window
    {
        public AddReaderWindow()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 1) Добавление записи в БД
                // Добавление записи в базу данных
                Readers newReader = new Readers()
                {
                    TicketNumber = TicketTb.Text,
                    Surname = LastnameTb.Text,
                    PassportNumber = PassportTb.Text,
                    BirthDay = (DateTime)ReaderDatePic.SelectedDate,
                    Address = AddressTb.Text,
                    PhoneNumber = PhoneTb.Text,
                    EducationLevel = EducationTb.Text,
                    AcademicDegree = Convert.ToBoolean(DegreeTb),
                    IDReadingRoom = Convert.ToInt32(ReadingRoomTb),
                };

                // 2) Добавляем объект в таблицу
                App.context.Readers.Add(newReader);

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
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
