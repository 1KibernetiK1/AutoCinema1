using AutoCinema.DataBase;
using AutoCinema.ViewModel;
using System.Windows;

namespace AutoCinema.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditFilm.xaml
    /// </summary>
    public partial class EditFilm : Window
    {
        public EditFilm(Фильмы filmsToEdit)
        {
            InitializeComponent();

            DataContext = new FilmViewModel();
            FilmViewModel.SelectedFilm = filmsToEdit;
            FilmViewModel.FilmName = filmsToEdit.Название;
            FilmViewModel.FilmGenre = filmsToEdit.Жанр;
            FilmViewModel.FilmDuration = filmsToEdit.Длительность;
            FilmViewModel.FilmYear = (int)filmsToEdit.Год;
            FilmViewModel.FilmCountry = filmsToEdit.Страна;
            FilmViewModel.FilmAuthors = filmsToEdit.Авторы;
            FilmViewModel.FilmDescriptions = filmsToEdit.Описание;
        }

        private void Button_reg_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
