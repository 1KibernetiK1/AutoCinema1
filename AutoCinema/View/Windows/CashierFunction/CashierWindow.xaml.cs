using AutoCinema.ViewModel;
using System;
using System.Windows;

namespace AutoCinema.View.Windows.CashierFunction
{
    /// <summary>
    /// Логика взаимодействия для CashierWindow.xaml
    /// </summary>
    public partial class CashierWindow : Window
    {
        public CashierWindow()
        {
            InitializeComponent();

            button_Copy.DataContext = new BuyingTicketsViewModel();
            button_Copy2.DataContext = new SessionsViewModel();
            button_Copy1.DataContext = new ReservationViewModel();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
