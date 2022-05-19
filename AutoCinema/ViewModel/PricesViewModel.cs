using AutoCinema.Core;
using AutoCinema.DataBase;
using AutoCinema.Domains;
using AutoCinema.View.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace AutoCinema.ViewModel
{
    public class PricesViewModel : INotifyPropertyChanged, IDisposable
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

        public List<СтоимостьБилетов> price { get; set; }

        public List<Сеансы> Seansi { get; set; }

        public PricesViewModel()
        {
            cinemaData = CinemaDataContainer.GetContext();
            price = new List<СтоимостьБилетов>(cinemaData.СтоимостьБилетов);
            Seansi = new List<Сеансы>(cinemaData.Сеансы);

        }

        #region PROPERTY FOR HALLS
        public int NewPrice { get; set; }
        public int session { get; set; }
        public static Сеансы SelectedSeans { get; set; }

        public static СтоимостьБилетов Selectedprice { get; set; }
        #endregion




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





        private RelayCommand addNewPrice;
        public RelayCommand AddNewPrice
        {
            get
            {
                return addNewPrice ?? new RelayCommand(obj =>
                {
                    string resultStr = "";

                    StringBuilder errors = new StringBuilder();

                    if (session == 0)
                        errors.AppendLine("Укажите Сеанс");

                    if (NewPrice == 0)
                        errors.AppendLine("Укажите Цену");



                    if (errors.Length > 0)
                    {
                        MessageBox.Show(errors.ToString());
                        return;
                    }

                    try
                    {
                        resultStr = Prices.AddPrice(session, NewPrice);
                        MessageBox.Show("Информация сохранена!");
                        SetNullValuesProperties();
                        UpdateAllPriceView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }


                }
          );
            }
        }








        private RelayCommand deletePrice;
        public RelayCommand DeletePrice
        {
            get
            {
                return deletePrice ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    // если фильмы
                    if (Selectedprice != null)
                    {
                        resultStr = Prices.DeletePrice(Selectedprice);
                        SetNullValuesProperties();
                        UpdateAllPriceView();
                    }



                }
          );
            }
            set { deletePrice = value; }
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

        private void SetNullValuesProperties()
        {
            session = 0;
            NewPrice = 0;
        }

       



        private void UpdateAllPriceView()
        {
            AllPrices = Prices.GetAllPrices();

            PriceTicketsWindow.AllPriceView.ItemsSource = null;
            PriceTicketsWindow.AllPriceView.Items.Clear();
            PriceTicketsWindow.AllPriceView.ItemsSource = AllPrices;
            PriceTicketsWindow.AllPriceView.Items.Refresh();
        }

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

        private void OpenPriceMethod()
        {
            PriceTicketsWindow priceTickets = new PriceTicketsWindow();
            priceTickets.Show();
        }

        private RelayCommand openPrice;
        public RelayCommand OpenPrice
        {
            get
            {
                return openPrice ?? new RelayCommand(obj =>
                {

                    OpenPriceMethod();
                }
                    );

            }
            set { openPrice = value; }
        }


        public void Dispose()
        {
            cinemaData.Dispose();
        }
    }
}
