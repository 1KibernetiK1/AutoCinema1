using AutoCinema.Core;
using AutoCinema.DataBase;
using AutoCinema.Domains;
using AutoCinema.View.Windows;
using AutoCinema.View.Windows.AdminFunction;
using AutoCinema.View.Windows.CashierFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace AutoCinema.ViewModel
{
    public class SessionsViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;


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
        public static string NewTime { get; set; }
        public static int NewHall { get; set; }
        public static int NewFilm { get; set; }
        public static string NewIsFirst { get; set; }
        public static string NewDate { get; set; }
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
            sessions = new List<Сеансы>(CinemaDataContainer.GetContext().Сеансы);
            Films = new List<Фильмы>(CinemaDataContainer.GetContext().Фильмы);
            Halls = new List<Залы>(CinemaDataContainer.GetContext().Залы);
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

        private RelayCommand editSession;
        public RelayCommand EditSession
        {
            get
            {
                return editSession ?? new RelayCommand(obj =>
                {

                    string resultStr = "Не выбран сотрудник";

                    if (SelectedSessions != null)
                    {
                        resultStr = Sessions.editSession(SelectedSessions, NewFilm, NewHall, NewDate, NewTime, NewIsFirst);
                        OpenSessionMethod();

                    }

                    else MessageBox.Show(resultStr);
                });
            }
        }




        private void OpenEditSessionMethod(Сеансы _sessions)
        {
            EditSessions editSessions = new EditSessions(_sessions);
            editSessions.Show();
        }

    

        private RelayCommand openeditSession;
        public RelayCommand OpenEditSession
        {
            get
            {
                return openeditSession ?? new RelayCommand(obj =>
                {

                    if (SelectedSessions != null)
                    {
                        OpenEditSessionMethod(SelectedSessions);
                    }

                }
                    );

            }
            set { openeditSession = value; }
        }


        public void Dispose()
        {
            CinemaDataContainer.GetContext().Dispose();
        }

    }
}
