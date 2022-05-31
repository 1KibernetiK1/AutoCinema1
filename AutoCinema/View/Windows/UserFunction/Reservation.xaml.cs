using AutoCinema.ViewModel;
using System;
using System.Windows;

namespace AutoCinema.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для Reservation.xaml
    /// </summary>
    public partial class Reservation : Window
    {
        public Reservation()
        {
            InitializeComponent();

            DataContext = new ReservationViewModel();
        }

       
        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
