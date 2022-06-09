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


       

        public WinFilms()
        {
            InitializeComponent();
        
 
            DataContext = new FilmViewModel();
            AllFilmsView = ViewAllFilms;
            Export.DataContext = new ExcelViewModel();
            SearchFilms();
        }

        private void SearchFilms()
        {
            var currentFilms = CinemaDataContainer.GetContext().Фильмы.ToList();

            currentFilms = currentFilms.Where(p => p.Название.ToLower().Contains(TBSearch.Text.ToLower())).ToList();

            ViewAllFilms.ItemsSource = currentFilms.OrderBy(p => p.ID).ToList();
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchFilms();
        }
    }
    
}
