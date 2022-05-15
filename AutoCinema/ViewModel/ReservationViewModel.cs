using AutoCinema.Core;
using AutoCinema.DataBase;
using AutoCinema.Domains;
using AutoCinema.View.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoCinema.ViewModel
{
    public class ReservationViewModel: INotifyPropertyChanged, IDisposable
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

        private void OpenReservMethod()
        {
            Reservation reservation = new Reservation();
            reservation.Show();
        }

        //private void OpenEditFilmMethod(Залы hallsize)
        //{
        //    EditFilm editFilm = new EditFilm(hallsize);
        //    editFilm.Show();
        //}





        private RelayCommand deleteHall;
        public RelayCommand DeleteHall
        {
            get
            {
                return deleteHall ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    // если фильмы
                    if (SelectedReserv != null)
                    {
                        resultStr =Reserv.DeleteHallSize(SelectedReserv);
                    }



                }
          );
            }
            set { deleteHall = value; }
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

        //private void SetNullValuesProperties()
        //{
        //    NewFIO = null;
        //    NewPhone = null;
        //}

        //private void UpdateAllDataView()
        //{
        //    UpdateAllHallsView();
        //}



        //private void UpdateAllHallsView()
        //{
        //    AllReserv= Reserv.GetAllReserv();

        //    Halls.AllHallsView.ItemsSource = null;
        //    Halls.AllHallsView.Items.Clear();
        //    Halls.AllHallsView.ItemsSource = AllReserv;
        //    Halls.AllHallsView.Items.Refresh();
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


        public void Dispose()
        {
            cinemaData.Dispose();
        }
    }
}
