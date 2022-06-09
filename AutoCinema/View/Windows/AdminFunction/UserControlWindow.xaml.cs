using AutoCinema.DataBase;
using AutoCinema.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AutoCinema.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserControlWindow.xaml
    /// </summary>
    public partial class UserControlWindow : Window
    {
        public static DataGrid AllusersView;



        public UserControlWindow()
        {
            InitializeComponent();

            DataContext = new LoginViewModel();
            AllusersView = ViewAllUsers;
            Export.DataContext = new ExcelViewModel();
           
        }

        private void SearchUserLogin()
        {
            var currentUsers = CinemaDataContainer.GetContext().Пользователи.ToList();

            currentUsers = currentUsers.Where(p => p.Логин.ToLower().Contains(NameBox_Copy.Text.ToLower())).ToList();

            ViewAllUsers.ItemsSource = currentUsers.OrderBy(p => p.ID).ToList();
        }

        private void SearchUserAccess()
        {
            var currentUsers = CinemaDataContainer.GetContext().Пользователи.ToList();

            currentUsers = currentUsers.Where(p => p.УровеньДоступа.ToLower().Contains(NameBox_Copy1.Text.ToLower())).ToList();

            ViewAllUsers.ItemsSource = currentUsers.OrderBy(p => p.ID).ToList();
        }


        private void NameBox_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchUserLogin();
        }

        private void NameBox_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchUserAccess();
        }
    }
}
