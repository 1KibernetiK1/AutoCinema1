using AutoCinema.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AutoCinema
{
    /// <summary>
    /// Логика взаимодействия для Info_cinema.xaml
    /// </summary>
    public partial class Info_cinema : Window
    {


        public Info_cinema()
        {
            InitializeComponent();

            button_Copy.DataContext = new FilmViewModel();
            button_Copy1.DataContext = new HallsViewModel();
            button_Copy2.DataContext = new SessionsViewModel();
            button_Copy3.DataContext = new PricesViewModel();
            button_Copy4.DataContext = new LoginViewModel();
            button_Copy5.DataContext = new HallsViewModel();
        }

      

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
