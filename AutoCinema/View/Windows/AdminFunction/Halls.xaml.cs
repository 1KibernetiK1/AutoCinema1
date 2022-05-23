using AutoCinema.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AutoCinema.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для Halls.xaml
    /// </summary>
    public partial class Halls : Window
    {


        public static DataGrid AllHallssizeView;
        public static DataGrid AllHallsView;

        public Halls()
        {
            InitializeComponent();
            HallsViewModel vm = new HallsViewModel();
            DataContext = vm;
            AllHallsView = ViewAllHalls;
            Grid2.DataContext = new HallsSizeViewModel();
            cbc1.ItemsSource = vm.Размеры;
            ActionsForHallSize.DataContext = new HallsSizeViewModel();
            AllHallssizeView = ViewAllHallssizes;
            ExcelHallSize.DataContext = new ExcelViewModel();
            HallsExcel.DataContext = new ExcelViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void delHallsize_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
