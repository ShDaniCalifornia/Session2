using Session2.Model;
using System.Windows;

namespace Session2
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Session2Entities context = new Session2Entities();
    }
}
