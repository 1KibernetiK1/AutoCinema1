//using AutoCinema.Core;
//using AutoCinema.DataBase;
//using AutoCinema.View.Windows;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;

//namespace AutoCinema.ViewModel
//{
//    public class SearchViewModel : INotifyPropertyChanged
//    {
//        private RelayCommand filmSearch;
//        public RelayCommand FilmSearch
//        {
//            get
//            {
//                return filmSearch ?? new RelayCommand(obj =>
//                {
//                    var searchFilm = WinFilms.SearchFilm;
//                    if (searchFilm.Text != "")
//                    {
//                        var filteredList = CinemaDataContainer.GetContext().Фильмы.Where(x => x.Название.ToLower().Contains(searchFilm.Text.ToLower()));
//                        WinFilms.AllFilmsView.ItemsSource = null;
//                        WinFilms.AllFilmsView.ItemsSource = filteredList;
//                    }
                  

//                }
//          );
//            }
//        }

//        public event PropertyChangedEventHandler PropertyChanged;

//        private void NotifyPropertyChanged(string propertyName)
//        {
//            if (PropertyChanged != null)
//            {
//                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
//            }
//        }
//    }
//}
