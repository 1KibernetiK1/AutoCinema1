using AutoCinema.Core;
using AutoCinema.DataBase;
using AutoCinema.Domains;
using AutoCinema.View.Windows;
using AutoCinema.View.Windows.AdminFunction.Editing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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
        public List<Сеансы> NewSess1 { get; set; }
        public List<Залы> Newhall1 { get; set; }

        public static int NewHall { get; set; }
        public static int NewSession { get; set; }
        public static int SelectedRow { get; set; }
        public static int SelectedPlace { get; set; }
        public static int SeansID { get; set; }

        public BuyingTicketsViewModel()
        {
            cinemaData = new CinemaDataContainer();
            Ticket = new List<Билеты>(cinemaData.Билеты);
            Reservations = new List<Бронь>(cinemaData.Бронь);
            NewSess1 = new List<Сеансы>(cinemaData.Сеансы);
            Newhall1 = new List<Залы>(cinemaData.Залы);
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

        private void OpenEditTicketMethod(Билеты _tickets)
        {
            EditTicket editTicket = new EditTicket(_tickets);
            editTicket.Show();
        }


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

        private RelayCommand editTicket;
        public RelayCommand EditTicket
        {
            get
            {
                return editTicket ?? new RelayCommand(obj =>
                {
                    string resultStr = "Не выбран сотрудник";
                    if (SelectedTicket != null)
                    {
                        resultStr = Tickets.editTicket(SelectedTicket, NewSession, NewHall, SelectedRow, SelectedPlace);

                        UpdateAllDataView();
                        SetNullValuesProperties();
                    }
                    else MessageBox.Show(resultStr);
                });
            }
        }

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



        private RelayCommand openeditTicket;
        public RelayCommand OpenEditTicket
        {
            get
            {
                return openeditTicket ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    // если фильмы
                    if (SelectedTicket != null)
                    {
                        OpenEditTicketMethod(SelectedTicket);
                    }

                }
                    );

            }
            set { openeditTicket = value; }
        }

    }
}
