using AutoCinema.ViewModel;
using System.Windows;
using System.Windows.Controls;


namespace AutoCinema.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для WinFilms.xaml
    /// </summary>
    public partial class WinFilms : Window
    {
        public static DataGrid AllFilmsView;



        public WinFilms()
        {
            InitializeComponent();

            DataContext = new FilmViewModel();
            AllFilmsView = ViewAllFilms;
            Export.DataContext = new ExcelViewModel();
        }


    }
}
