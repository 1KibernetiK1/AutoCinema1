using AutoCinema.DataBase;
using AutoCinema.ViewModel;
using System.Windows;

namespace AutoCinema.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditHallSize.xaml
    /// </summary>
    public partial class EditHallSize : Window
    {
        public EditHallSize(РазмерыЗалов hallsSize)
        {
            InitializeComponent();

            DataContext = new HallsSizeViewModel();

            HallsSizeViewModel.SelectedHallsize = hallsSize;
            HallsSizeViewModel.SizeName = hallsSize.Наименование;
            HallsSizeViewModel.SizeCount = (int)hallsSize.КоличествоРядов;
        }

        private void Button_reg_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
