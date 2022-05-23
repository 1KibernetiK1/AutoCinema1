using AutoCinema.DataBase;
using AutoCinema.ViewModel;
using System.Windows;

namespace AutoCinema.View.Windows.AdminFunction
{
    /// <summary>
    /// Логика взаимодействия для EditPrice.xaml
    /// </summary>
    public partial class EditPrice : Window
    {
        public EditPrice(СтоимостьБилетов priceTick)
        {
            InitializeComponent();

            DataContext = new PricesViewModel();

            PricesViewModel.Selectedprice = priceTick;
            PricesViewModel.session = (int)priceTick.IDСеанса;
            PricesViewModel.NewPrice = (int)priceTick.Стоимость;

        }

        private void Button_reg_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
