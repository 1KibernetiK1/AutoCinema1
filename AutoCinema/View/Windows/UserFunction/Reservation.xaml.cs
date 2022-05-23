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
            ReservationViewModel vm = new ReservationViewModel();
            vm.PropertyChanged += Vm_PropertyChanged;
            DataContext = vm;
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Collection")
            {
                this.Close();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
