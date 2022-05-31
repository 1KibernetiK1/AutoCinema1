using AutoCinema.Core;
using AutoCinema.DataBase;
using AutoCinema.Domains;
using AutoCinema.View.Windows;
using AutoCinema.View.Windows.CashierFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace AutoCinema.ViewModel
{
    public class ReservationViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public List<Бронь> reserv { get; set; }




        private List<Бронь> allReserv = Reserv.GetAllReserv();

        public List<Бронь> AllReserv
        {
            get { return allReserv; }
            set
            {
                allReserv = value;
                NotifyPropertyChanged("AllReserv");
            }
        }

        #region PROPERTY FOR HALLS
        public string NewFIO { get; set; }

        public string NewPhone { get; set; }
        #endregion


        public static Бронь SelectedReserv { get; set; }


        private RelayCommand addNewReserv;
        public RelayCommand AddNewReserv
        {
            get
            {
                return addNewReserv ?? new RelayCommand(obj =>
                {
                    string resultStr = "";

                    StringBuilder errors = new StringBuilder();

                    if (string.IsNullOrWhiteSpace(NewFIO))
                        errors.AppendLine("Укажите ФИО");
                    if (string.IsNullOrWhiteSpace(NewPhone))
                        errors.AppendLine("Укажите телефон");



                    if (errors.Length > 0)
                    {
                        MessageBox.Show(errors.ToString());
                        return;
                    }

                    try
                    {
                        resultStr = Reserv.AddReserv(NewFIO, NewPhone);
                        MessageBox.Show("Информация сохранена!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }


                }
          );
            }
        }

      

      





        private RelayCommand deleteReserv;
        public RelayCommand DeleteReserv
        {
            get
            {
                return deleteReserv ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    // если фильмы
                    if (SelectedReserv != null)
                    {
                        resultStr = Reserv.DeleteReserv(SelectedReserv);
                    }



                }
          );
            }
            set { deleteReserv = value; }
        }

        private void OpenReservMethod()
        {
            Reservation reservation = new Reservation();
            reservation.Show();
        }

        private RelayCommand openReserv;
        public RelayCommand OpenReserv
        {
            get
            {
                return openReserv ?? new RelayCommand(obj =>
                {

                    OpenReservMethod();
                }
                    );

            }
            set { openReserv = value; }
        }

        private void OpenReservInfoMethod()
        {
            ReservationWindow reservation = new ReservationWindow();
            reservation.Show();
        }

        private RelayCommand openReservInfo;
        public RelayCommand OpenReservInfo
        {
            get
            {
                return openReservInfo ?? new RelayCommand(obj =>
                {

                    OpenReservInfoMethod();
                }
                    );

            }
            set { openReservInfo = value; }
        }


        public void Dispose()
        {
            CinemaDataContainer.GetContext().Dispose();
        }
    }
}
