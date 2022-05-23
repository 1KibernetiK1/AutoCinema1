using AutoCinema.DataBase;
using AutoCinema.ViewModel;
using System.Windows;

namespace AutoCinema.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditHalls.xaml
    /// </summary>
    public partial class EditHalls : Window
    {
        public EditHalls(Залы halls)
        {
            InitializeComponent();

            DataContext = new HallsViewModel();

            HallsViewModel.SelectedHall = halls;
            HallsViewModel.NewNumber = (int)halls.НомерЗала;
        }

        private void Button_reg_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
