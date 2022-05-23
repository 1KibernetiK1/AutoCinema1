using AutoCinema.ViewModel;
using System.Windows;
using System.Windows.Controls;

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
            excelTicket.DataContext = new ExcelViewModel();
        }


    }
}
