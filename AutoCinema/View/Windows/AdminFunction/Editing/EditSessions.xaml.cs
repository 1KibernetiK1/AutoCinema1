using AutoCinema.DataBase;
using AutoCinema.ViewModel;
using System.Windows;

namespace AutoCinema.View.Windows.AdminFunction
{
    /// <summary>
    /// Логика взаимодействия для EditSessions.xaml
    /// </summary>
    public partial class EditSessions : Window
    {
        public EditSessions(Сеансы sessions)
        {
            InitializeComponent();

            DataContext = new SessionsViewModel();

            SessionsViewModel.SelectedSessions = sessions;
            SessionsViewModel.NewFilm = (int)sessions.IDФильма;
            SessionsViewModel.NewHall = (int)sessions.IDЗала;
            SessionsViewModel.NewDate = sessions.Дата;
            SessionsViewModel.NewTime = sessions.Время;
            SessionsViewModel.NewIsFirst = sessions.Премьера;
        }

        private void Button_reg_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
