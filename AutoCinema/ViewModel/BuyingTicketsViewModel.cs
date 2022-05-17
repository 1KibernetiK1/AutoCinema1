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
    public class BuyingTicketsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        CinemaDataContainer cinemaData;

        private List<Билеты> allTickets = Tickets.GetAllTickets();

        public List<Билеты> AllTickets
        {
            get { return allTickets; }
            set
            {
                allTickets = value;
                NotifyPropertyChanged("AllTickets");
            }
        }

        public List<Билеты> Ticket { get; set; }
        public List<Бронь> Reservations { get; set; }
        public List<Сеансы> NewSess { get; set; }
        public List<Залы> Newhall { get; set; }

        public int NewHall { get; set; }
        public int NewSession { get; set; }
        public int SelectedRow { get; set; }
        public int SelectedPlace { get; set; }
        public int SeansID { get; set; }

        public BuyingTicketsViewModel()
        {
            cinemaData = new CinemaDataContainer();
            Ticket = new List<Билеты>(cinemaData.Билеты);
            Reservations = new List<Бронь>(cinemaData.Бронь);
        }


        private RelayCommand addNewTicket;
        public RelayCommand AddNewTicket
        {
            get
            {
                return addNewTicket ?? new RelayCommand(obj =>
                {
                    string resultStr = "";

                    StringBuilder errors = new StringBuilder();

                    if (NewSession == 0)
                        errors.AppendLine("Выберите сеанс");
                    if (NewHall == 0)
                        errors.AppendLine("Выберите Зал");
                    if (SelectedRow == 0)
                        errors.AppendLine("Введите ряд");
                    if (SelectedPlace == 0)
                        errors.AppendLine("Введите место в ряду");
                   
                   
                 


                    if (errors.Length > 0)
                    {
                        MessageBox.Show(errors.ToString());
                        return;
                    }

                    try
                    {
                        resultStr = Tickets.AddTicket(NewSession, NewHall, SelectedRow, SelectedPlace);
                        MessageBox.Show("Информация сохранена!");
                        //UpdateAllDataView();
                        SetNullValuesProperties();
                        UpdateAllDataView();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }


                }
          );
            }
        }

        private void OpenTicketMethod()
        {
            BuyingTicketWindow winTick = new BuyingTicketWindow();
            winTick.Show();
        }

        //private void OpenEditFilmMethod(Фильмы films)
        //{
        //    EditFilm editFilm = new EditFilm(films);
        //    editFilm.Show();
        //}


        public static Билеты SelectedTicket { get; set; }


        private RelayCommand deleteTicket;
        public RelayCommand DeleteTicket
        {
            get
            {
                return deleteTicket ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    // если фильмы
                    if (SelectedTicket != null)
                    {
                        resultStr = Tickets.DeleteTickets(SelectedTicket);
                        SetNullValuesProperties();
                        UpdateAllDataView();
                    }

                }
          );
            }
            set { deleteTicket = value; }
        }

        //private RelayCommand editFilm;
        //public RelayCommand EditFilm
        //{
        //    get
        //    {
        //        return editFilm ?? new RelayCommand(obj =>
        //        {
        //            Window window = new Window();
        //            string resultStr = "Не выбран сотрудник";
        //            if (SelectedFilm != null)
        //            {
        //                resultStr = Films.editFilm(SelectedFilm, FilmName, FilmGenre, FilmDuration, FilmYear, FilmCountry, FilmAuthors, FilmDescriptions);

        //                UpdateAllDataView();
        //                SetNullValuesProperties();
        //                MessageBox.Show(resultStr);
        //                window.Close();
        //            }
        //            else MessageBox.Show(resultStr);
        //        });
        //    }
        //}

        private void SetNullValuesProperties()
        {
            NewSession = 0;
            NewHall = 0;
            SelectedPlace = 0;
            SelectedRow = 0;
        }

        private void UpdateAllDataView()
        {
            UpdateAllTicketsView();
        }

        private void UpdateAllTicketsView()
        {
            AllTickets = Tickets.GetAllTickets();

            BuyingTicketWindow.AllTickView.ItemsSource = null;
            BuyingTicketWindow.AllTickView.Items.Clear();
            BuyingTicketWindow.AllTickView.ItemsSource = AllTickets;
            BuyingTicketWindow.AllTickView.Items.Refresh();
        }

        //private RelayCommand openeditFilm;
        //public RelayCommand OpenEditFilm
        //{
        //    get
        //    {
        //        return openeditFilm ?? new RelayCommand(obj =>
        //        {
        //            string resultStr = "Ничего не выбрано";
        //            // если фильмы
        //            if (SelectedFilm != null)
        //            {
        //                OpenEditFilmMethod(SelectedFilm);
        //            }

        //        }
        //            );

        //    }
        //    set { openeditFilm = value; }
        //}

        private RelayCommand openTicket;
        public RelayCommand OpenTicket
        {
            get
            {
                return openTicket ?? new RelayCommand(obj =>
                {

                    OpenTicketMethod();
                }
                    );

            }
            set { openTicket = value; }
        }

    }
}
