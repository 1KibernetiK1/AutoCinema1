using AutoCinema.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AutoCinema.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для HallSizeWindow.xaml
    /// </summary>
    public partial class HallSizeWindow : Window
    {
        public static DataGrid AllHallssizeView;

        public HallSizeWindow()
        {
            InitializeComponent();

            DataContext = new HallsSizeViewModel();
            AllHallssizeView = ViewAllHallsSize;
        }
    }
}
