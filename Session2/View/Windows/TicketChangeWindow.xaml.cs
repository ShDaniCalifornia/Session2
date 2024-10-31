using Session2.Model;
using System.Linq;
using System.Windows;

namespace Session2.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для TicketChangeWindow.xaml
    /// </summary>
    public partial class TicketChangeWindow : Window
    {
        private int _readerId;

        public TicketChangeWindow(int readerId, string oldTicketNumber)
        {
            InitializeComponent();
            _readerId = readerId;
            OldTicketNumberTb.Text = oldTicketNumber;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string newTicketNumber = NewTicketNumberTb.Text;

            using (var context = new Session2Entities())
            {
                // Найти читателя по ID
                var reader = context.Readers.SingleOrDefault(r => r.IDReader == _readerId);

                if (reader != null)
                {
                    // Обновить номер читательского билета
                    reader.TicketNumber = newTicketNumber;
                    context.SaveChanges();
                    MessageBox.Show("Номер читательского билета успешно обновлен.");
                    Close();
                }
                else
                {
                    MessageBox.Show("Читатель не найден.");
                }
            }
        }

        private void CancelBtn_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
