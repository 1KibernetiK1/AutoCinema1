using AutoCinema.DataBase;
using AutoCinema.ViewModel;
using System.Web.UI;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;


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
