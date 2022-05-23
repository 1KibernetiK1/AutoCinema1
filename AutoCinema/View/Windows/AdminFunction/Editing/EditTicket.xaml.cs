using AutoCinema.DataBase;
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

namespace AutoCinema.View.Windows.AdminFunction.Editing
{
    /// <summary>
    /// Логика взаимодействия для EditTicket.xaml
    /// </summary>
    public partial class EditTicket : Window
    {
        public EditTicket(Билеты tickets)
        {
            InitializeComponent();

            DataContext = new BuyingTicketsViewModel();

            BuyingTicketsViewModel.SelectedTicket = tickets;
            BuyingTicketsViewModel.NewSession = (int)tickets.IDСеанса;
            BuyingTicketsViewModel.NewHall = (int)tickets.IDЗала;
            BuyingTicketsViewModel.SelectedRow = (int)tickets.Ряд;
            BuyingTicketsViewModel.SelectedPlace = (int)tickets.Место;
        }

        private void Button_reg_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
