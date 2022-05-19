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
    /// Логика взаимодействия для BuyingTicketWindow.xaml
    /// </summary>
    public partial class BuyingTicketWindow : Window
    {
        public static DataGrid AllTickView;

        public BuyingTicketWindow()
        {
            InitializeComponent();

            DataContext = new BuyingTicketsViewModel();
            AllTickView = ViewAllTicket;
            Print.DataContext = new PrintTicketViewModel();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
