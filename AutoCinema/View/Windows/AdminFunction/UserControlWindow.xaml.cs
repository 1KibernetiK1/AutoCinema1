using AutoCinema.ViewModel;
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
    }
}
