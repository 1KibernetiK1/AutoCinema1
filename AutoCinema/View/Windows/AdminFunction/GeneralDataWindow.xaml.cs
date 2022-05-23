using AutoCinema.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AutoCinema.View.Windows.AdminFunction
{
    /// <summary>
    /// Логика взаимодействия для GeneralDataWindow.xaml
    /// </summary>
    public partial class GeneralDataWindow : Window
    {

        private SessionsViewModel sessions = new SessionsViewModel();

        private HallsViewModel vm = new HallsViewModel();

        public GeneralDataWindow()
        {
            InitializeComponent();

            ViewAllFilms.DataContext = new FilmViewModel();
            ViewAllUsers.DataContext = new LoginViewModel();
            ViewAllPriceSize.DataContext = new PricesViewModel();
            dataGrid.DataContext = new SessionsViewModel();
            ViewAllHalls.DataContext = new HallsViewModel();
            ViewAllHallssizes.DataContext = new HallsSizeViewModel();

            cbc1.ItemsSource = sessions.Films;
            cbc2.ItemsSource = sessions.Halls;

            cbc4.ItemsSource = vm.Размеры;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            if (dlg.ShowDialog() == true)
            {
                dlg.PrintVisual(AllGrid, "Данные");

            }
        }
    }
}
