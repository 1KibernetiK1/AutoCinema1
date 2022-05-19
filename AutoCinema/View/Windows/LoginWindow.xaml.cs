using AutoCinema.View;
using AutoCinema.View.Windows;
using AutoCinema.View.Windows.CashierFunction;
using AutoCinema.ViewModel;
using System.Windows;

namespace AutoCinema
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Registration registration = new Registration();

        public MainWindow()
        {
            InitializeComponent();

            LoginViewModel vm = new LoginViewModel();
            DataContext = vm;
            vm.PropertyChanged += Vm_PropertyChanged;
        }


        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Success_admin":
                    this.Hide();
                    Info_cinema info = new Info_cinema();
                    info.Show();
                    break;
                case "Success_cashier":
                    this.Hide();
                    CashierWindow cashiertWindow = new CashierWindow();
                    cashiertWindow.Show();
                    break;
                case "Success_user":
                    this.Hide();
                    Reservation reservation = new Reservation();
                    reservation.Show();
                    break;
                case "InvalidPassword":
                    MessageBox.Show("Неверный пароль!");
                    break;
                case "NotExistUser":
                    MessageBox.Show("Пользователь не найден!");
                    break;
            }
        }

        private void Button_Click_reg(object sender, RoutedEventArgs e)
        {
            registration.Show();

            this.Show();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
