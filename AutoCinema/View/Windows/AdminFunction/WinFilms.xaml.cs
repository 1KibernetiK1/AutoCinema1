using AutoCinema.DataBase;
using AutoCinema.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace AutoCinema.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для WinFilms.xaml
    /// </summary>
    public partial class WinFilms : Window
    {
        public static DataGrid AllFilmsView;

        public static TextBox Searchtb;

        public static List<Фильмы> Films;



       

        public WinFilms()
        {
            InitializeComponent();
 
            DataContext = new FilmViewModel();
            AllFilmsView = ViewAllFilms;
            Export.DataContext = new ExcelViewModel();  

        }

      
    }
    
}
