using AutoCinema.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AutoCinema.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для PriceTicketsWindow.xaml
    /// </summary>
    public partial class PriceTicketsWindow : Window
    {
        public static DataGrid AllPriceView;

        public PriceTicketsWindow()
        {
            InitializeComponent();


            DataContext = new PricesViewModel();
            AllPriceView = ViewAllPriceSize;
            PriceExcel.DataContext = new ExcelViewModel();
        }
    }
}
