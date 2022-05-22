using AutoCinema.ViewModel;
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
