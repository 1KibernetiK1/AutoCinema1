using AutoCinema.DataBase;
using AutoCinema.Security;
using AutoCinema.ViewModel;
using System;
using System.Linq;
using System.Windows;

namespace AutoCinema.View
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();

            DataContext = new LoginViewModel();
        }



        private void Button_reg_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
