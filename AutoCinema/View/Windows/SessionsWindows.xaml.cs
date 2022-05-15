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
    /// Логика взаимодействия для SessionsWindows.xaml
    /// </summary>
    public partial class SessionsWindows : Window
    {
        SessionsViewModel viewModel = new SessionsViewModel();
      
       
        public static DataGrid AllSessionView;

        public SessionsWindows()
        {
            InitializeComponent();
            DataContext = viewModel;
            cbc1.ItemsSource = viewModel.Films;
            cbc2.ItemsSource = viewModel.Halls;    
            dataGrid = AllSessionView;
          
        }

        private void SelectButton_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
