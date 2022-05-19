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

namespace AutoCinema.View.Windows.CashierFunction
{
    /// <summary>
    /// Логика взаимодействия для InfoAboutSessionWindow.xaml
    /// </summary>
    public partial class InfoAboutSessionWindow : Window
    {
        private SessionsViewModel viewModel = new SessionsViewModel();

        public InfoAboutSessionWindow()
        {
            InitializeComponent();

            DataContext = viewModel;
            cbc1.ItemsSource = viewModel.Films;
            cbc2.ItemsSource = viewModel.Halls;
        }
    }
}
