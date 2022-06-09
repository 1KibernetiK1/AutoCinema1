using AutoCinema.Core;
using AutoCinema.DataBase;
using AutoCinema.Domains;
using AutoCinema.View.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace AutoCinema.ViewModel
{
    public class FilmViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private List<Фильмы> allFilms = Films.GetAllFilms();

        public List<Фильмы> AllFilms
        {
            get { return allFilms; }
            set
            {
                allFilms = value;
                NotifyPropertyChanged("AllFilms");
            }
        }




        #region PROPERTY FOR FILMS
        public static string FilmName { get; set; }
        public static string FilmGenre { get; set; }
        public static string FilmDuration { get; set; }
        public static int FilmYear { get; set; }
        public static string FilmCountry { get; set; }
        public static string FilmAuthors { get; set; }
        public static string FilmDescriptions { get; set; }
        #endregion

        public static Фильмы SelectedFilm { get; set; }


        private RelayCommand addNewFilm;
        public RelayCommand AddNewFilm
        {
            get
            {
                return addNewFilm ?? new RelayCommand(obj =>
                {
                    string resultStr = "";

                    StringBuilder errors = new StringBuilder();

                    if (string.IsNullOrWhiteSpace(FilmName))
                        errors.AppendLine("Укажите название фильма");
                    if (string.IsNullOrWhiteSpace(FilmGenre))
                        errors.AppendLine("Укажите жанр");
                    if (string.IsNullOrWhiteSpace(FilmDuration))
                        errors.AppendLine("Укажите длительность");
                    if (FilmYear < 1900 || FilmYear > 2022)
                        errors.AppendLine("Год - число от 1900 до 2022");
                    if (string.IsNullOrWhiteSpace(FilmCountry))
                        errors.AppendLine("Укажите страну");
                    if (string.IsNullOrWhiteSpace(FilmAuthors))
                        errors.AppendLine("Укажите укажите автора");
                    if (string.IsNullOrWhiteSpace(FilmDescriptions))
                        errors.AppendLine("Укажите описание");

                    if (errors.Length > 0)
                    {
                        MessageBox.Show(errors.ToString());
                        return;
                    }

                    try
                    {
                        resultStr = Films.AddFilm(FilmName, FilmGenre, FilmDuration, FilmYear, FilmCountry, FilmAuthors, FilmDescriptions);
                        MessageBox.Show("Информация сохранена!");
                        UpdateAllDataView();
                        SetNullValuesProperties();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }


                }
          );
            }
        }

       


        private void OpenFilmMethod()
        {
            WinFilms winFilm = new WinFilms();
            winFilm.Show();
        }

        private void OpenEditFilmMethod(Фильмы films)
        {
            EditFilm editFilm = new EditFilm(films);
            editFilm.Show();
        }





        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    // если фильмы
                    if (SelectedFilm != null)
                    {
                        resultStr = Films.DeleteFilm(SelectedFilm);
                        UpdateAllDataView();
                    }

                    //обновление
                    SetNullValuesProperties();
                }
          );
            }
            set { deleteItem = value; }
        }

        //private RelayCommand searchFilm;
        //public RelayCommand SearchFilm
        //{
        //    get
        //    {
        //        return searchFilm ?? new RelayCommand(obj =>
        //        {
        //            string resultStr = "Ничего не выбрано";
        //            // если фильмы
        //            var currentFilms = CinemaDataContainer.GetContext().Фильмы.ToList();

        //            currentFilms = currentFilms.Where(p => p.Название.ToLower().Contains(WinFilms.TextBoxSearch.Text.ToLower())).ToList();

        //            WinFilms.AllFilmsView.ItemsSource = currentFilms.OrderBy(p => p.ID).ToList();

        //            //обновление
        //            SetNullValuesProperties();
        //        }
        //  );
        //    }
        //    set { searchFilm = value; }
        //}

        private RelayCommand editFilm;
        public RelayCommand EditFilm
        {
            get
            {
                return editFilm ?? new RelayCommand(obj =>
                {
                    Window window = new Window();
                    string resultStr = "Не выбран сотрудник";
                    if (SelectedFilm != null)
                    {
                        resultStr = Films.editFilm(SelectedFilm, FilmName, FilmGenre, FilmDuration, FilmYear, FilmCountry, FilmAuthors, FilmDescriptions);

                        UpdateAllDataView();
                        SetNullValuesProperties();
                        MessageBox.Show(resultStr);
                        window.Close();
                    }
                    else MessageBox.Show(resultStr);
                });
            }
        }

        private void SetNullValuesProperties()
        {
            FilmName = null;
            FilmGenre = null;
            FilmDuration = null;
            FilmYear = 0;
            FilmCountry = null;
            FilmAuthors = null;
            FilmDescriptions = null;
        }

        private void UpdateAllDataView()
        {
            UpdateAllFilmsView();
        }

        private void UpdateAllFilmsView()
        {
            AllFilms = Films.GetAllFilms();

            WinFilms.AllFilmsView.ItemsSource = null;
            WinFilms.AllFilmsView.Items.Clear();
            WinFilms.AllFilmsView.ItemsSource = AllFilms;
            WinFilms.AllFilmsView.Items.Refresh();
        }

        //private void UpdateSearchFilmView()
        //{
          

        //    if (WinFilms.Searchtb.Text != "")
        //    {
        //        AllFilms = Films.GetAllFilms();
        //        var SearchFilms = AllFilms..Where(x => x.Название.ToLowerInvariant().Contains(SearchFilmTb.Text.ToLowerInvariant()));

        //        ViewAllFilms.ItemsSource = null;
        //        ViewAllFilms.ItemsSource = SearchFilms;
        //    }
        //    else
        //    {
        //        ViewAllFilms.ItemsSource = CinemaDataContainer.GetContext().Фильмы.ToList();
        //    }

        //    WinFilms.Searchtb.ItemsSource = null;
        //    WinFilms.Searchtb.Items.Clear();
        //    WinFilms.Searchtb.ItemsSource = AllFilms;
        //    WinFilms.Searchtb.Items.Refresh();
        //}



        private RelayCommand openeditFilm;
        public RelayCommand OpenEditFilm
        {
            get
            {
                return openeditFilm ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    // если фильмы
                    if (SelectedFilm != null)
                    {
                        OpenEditFilmMethod(SelectedFilm);
                    }

                }
                    );

            }
            set { openeditFilm = value; }
        }

        private RelayCommand openFilms;
        public RelayCommand OpenFilms
        {
            get
            {
                return openFilms ?? new RelayCommand(obj =>
                {

                    OpenFilmMethod();
                }
                    );

            }
            set { openFilms = value; }
        }

        public void Dispose()
        {
            CinemaDataContainer.GetContext().Dispose();
        }


    }
}
