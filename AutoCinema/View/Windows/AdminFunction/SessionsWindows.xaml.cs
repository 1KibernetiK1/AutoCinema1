using AutoCinema.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AutoCinema.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для SessionsWindows.xaml
    /// </summary>
    public partial class SessionsWindows : Window
    {
        private SessionsViewModel sessions = new SessionsViewModel();

        public static DataGrid AllsessView;

        public SessionsWindows()
        {
            InitializeComponent();
            DataContext = new SessionsViewModel();
            cbc1.ItemsSource = sessions.Films;
            cbc2.ItemsSource = sessions.Halls;
            dataGrid = AllsessView;
        }

        private void SelectButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
