using AutoCinema.Core;
using AutoCinema.DataBase;
using AutoCinema.Domains;
using AutoCinema.View.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AutoCinema.ViewModel
{
    public class SessionsViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        CinemaDataContainer cinemaData;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public List<Сеансы> sessions { get; set; }

        public List<Фильмы> Films { get; set; }
        public List<Залы> Halls { get; set; }


        #region PROPERTY FOR HALLS
        public string NewTime { get; set; }
        public int NewHall { get; set; }
        public int NewFilm { get; set; }
        public bool NewIsFirst { get; set; }
        public DateTime NewDate { get; set; }

        public static int A { get; set; }
        public static int B { get; set; }

        public static decimal price { get; set; }
        #endregion


        private List<Сеансы> allSessions = Sessions.GetAllSessions();

        public List<Сеансы> AllSessions
        {
            get { return allSessions; }
            set
            {
                allSessions = value;
                NotifyPropertyChanged("AllSessions");
            }
        }


        private List<СтоимостьБилетов> allPrices = Prices.GetAllPrices();

        public List<СтоимостьБилетов> AllPrices
        {
            get { return allPrices; }
            set
            {
                allPrices = value;
                NotifyPropertyChanged("AllPrices");
            }
        }




        public static Сеансы SelectedSessions { get; set; }


      


        private RelayCommand addNewSession;
        public RelayCommand AddNewSessions
        {
            get
            {
                return addNewSession ?? new RelayCommand(obj =>
                {
                    string resultStr = "";


                    try
                    {
                        resultStr = Sessions.AddSession(NewFilm, NewHall, NewDate, NewTime, NewIsFirst);
                        MessageBox.Show("Информация сохранена! Для обновления данных необходимо перезайти в сеансов.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }


                }
          );
            }
        }

        public SessionsViewModel()
        {
            cinemaData = CinemaDataContainer.GetContext();
            sessions = new List<Сеансы>(cinemaData.Сеансы);
            Films = new List<Фильмы>(cinemaData.Фильмы);
            Halls = new List<Залы>(cinemaData.Залы);     
            NewDate = DateTime.Now;
        }

        public void SelectMethod()
        {
            Залы z = CinemaDataContainer.GetContext().Залы.FirstOrDefault(a => a.ID == SelectedSessions.IDЗала);
            A = SelectedSessions.ID;
            B = CinemaDataContainer.GetContext().РазмерыЗалов.FirstOrDefault(b => b.ID == z.IDРазмера).КоличествоРядов.Value;

        }


        private void OpenSessionMethod()
        {
            SessionsWindows sessions = new SessionsWindows();
            sessions.Show();
        }






        private RelayCommand deleteSession;
        public RelayCommand DeleteSession
        {
            get
            {
                return deleteSession ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    // если фильмы
                    if (SelectedSessions != null)
                    {
                        resultStr = Sessions.DeleteSessions(SelectedSessions);
                    }

                    
                }
          );
            }
            set { deleteSession = value; }
        }

        //private RelayCommand editHall;
        //public RelayCommand EditHall
        //{
        //    get
        //    {
        //        return editHall ?? new RelayCommand(obj =>
        //        {
        //            Window window = new Window();
        //            string resultStr = "Не выбран сотрудник";
        //            if (SelectedHall != null)
        //            {
        //                resultStr = HallsD.editHall(SelectedHall, NewName, NewNumber);

        //                UpdateAllDataView();
        //                SetNullValuesProperties();
        //                MessageBox.Show(resultStr);
        //                window.Close();
        //            }
        //            else MessageBox.Show(resultStr);
        //        });
        //    }
        //}

        

      

     




      

        //private RelayCommand openeditHall;
        //public RelayCommand OpenEditHall
        //{
        //    get
        //    {
        //        return openeditHall ?? new RelayCommand(obj =>
        //        {
        //            string resultStr = "Ничего не выбрано";
        //            // если фильмы
        //            if (SelectedHall != null)
        //            {
        //                OpenEditFilmMethod(SelectedFilm);
        //            }

        //        }
        //            );

        //    }
        //    set { openeditHall = value; }
        //}

        private RelayCommand openSession;
        public RelayCommand OpenSession
        {
            get
            {
                return openSession ?? new RelayCommand(obj =>
                {

                    OpenSessionMethod();
                }
                    );

            }
            set { openSession = value; }
        }


        public void Dispose()
        {
            cinemaData.Dispose();
        }
    }
}
