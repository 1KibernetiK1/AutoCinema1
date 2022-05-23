using AutoCinema.ViewModel;
using System.Windows;

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
