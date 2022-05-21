using AutoCinema.Core;
using AutoCinema.DataBase;
using AutoCinema.Domains;
using AutoCinema.View.Windows;
using AutoCinema.View.Windows.CashierFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace AutoCinema.ViewModel
{
    public class SessionsViewModel : INotifyPropertyChanged
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
        public string NewIsFirst { get; set; }
        public string NewDate { get; set; }

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

                    StringBuilder errors = new StringBuilder();

                    if (NewFilm == 0)
                        errors.AppendLine("Выберите фильм");
                    if (NewHall == 0)
                        errors.AppendLine("Выберите зал");
                    if (string.IsNullOrWhiteSpace(NewTime))
                        errors.AppendLine("Укажите Время");


                    if (errors.Length > 0)
                    {
                        MessageBox.Show(errors.ToString());
                        return;
                    }


                    try
                    {
                        resultStr = Sessions.AddSession(NewFilm, NewHall, NewDate, NewTime, NewIsFirst);
                        OpenSessionMethod();
                        MessageBox.Show("Информация сохранена");
                        

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
        }

     


        private void OpenSessionMethod()
        {
            SessionsWindows sessions = new SessionsWindows();
            sessions.Show();
        }

        private void CloseSessionMethod()
        {
            SessionsWindows sessions = new SessionsWindows();
            sessions.Hide();
        }

        private void OpenAddSessionMethod()
        {
            AddSessionWindow AddSessions = new AddSessionWindow();
            AddSessions.Show();
        }

        private void OpenInfoSessionMethod()
        {
            InfoAboutSessionWindow Infosessions = new InfoAboutSessionWindow();
            Infosessions.Show();
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
                        OpenSessionMethod();
                        MessageBox.Show("Удаление выполнено успешно!");
                       
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

        private RelayCommand openAddSession;
        public RelayCommand OpenAddSession
        {
            get
            {
                return openAddSession ?? new RelayCommand(obj =>
                {

                    OpenAddSessionMethod();

                }
                    );

            }
            set { openAddSession = value; }
        }

        private RelayCommand openInfoSession;
        public RelayCommand OpenInfoSession
        {
            get
            {
                return openInfoSession ?? new RelayCommand(obj =>
                {

                    OpenInfoSessionMethod();
                }
                    );

            }
            set { openInfoSession = value; }
        }


       

      


    }
}
