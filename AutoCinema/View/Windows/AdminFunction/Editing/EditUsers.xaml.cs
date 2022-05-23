using AutoCinema.DataBase;
using AutoCinema.ViewModel;
using System.Windows;

namespace AutoCinema.View.Windows.AdminFunction
{
    /// <summary>
    /// Логика взаимодействия для EditUsers.xaml
    /// </summary>
    public partial class EditUsers : Window
    {
        public EditUsers(Пользователи UserEd)
        {
            InitializeComponent();

            DataContext = new LoginViewModel();

            LoginViewModel.SelectedUsers = UserEd;
            LoginViewModel.Login = UserEd.Логин;
            LoginViewModel.Password = UserEd.Пароль;
            LoginViewModel.AccessLevel = UserEd.УровеньДоступа;

        }

        private void Button_reg_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
