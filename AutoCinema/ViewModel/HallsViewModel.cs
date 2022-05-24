using AutoCinema.Core;
using AutoCinema.DataBase;
using AutoCinema.Domains;
using AutoCinema.View.Windows;
using AutoCinema.View.Windows.AdminFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace AutoCinema.ViewModel
{
    public class HallsViewModel : INotifyPropertyChanged, IDisposable
    {

        public event PropertyChangedEventHandler PropertyChanged;



        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public List<Залы> halls { get; set; }
        public List<РазмерыЗалов> Размеры { get; set; }

        public HallsViewModel()
        {
          

            halls = new List<Залы>(CinemaDataContainer.GetContext().Залы);
            Размеры = new List<РазмерыЗалов>(CinemaDataContainer.GetContext().РазмерыЗалов);
        }




        private List<Залы> allHalls = HallsD.GetAllHall();

        public List<Залы> AllHalls
        {
            get { return allHalls; }
            set
            {
                allHalls = value;
                NotifyPropertyChanged("AllHalls");
            }
        }

        #region PROPERTY FOR HALLS
        public static int NewNumber { get; set; }

        public static string NewSize { get; set; }
        #endregion


        public static Залы SelectedHall { get; set; }

        public static РазмерыЗалов Selectedsize { get; set; }


        private RelayCommand addNewHall;
        public RelayCommand AddNewHall
        {
            get
            {
                return addNewHall ?? new RelayCommand(obj =>
                {
                    string resultStr = "";

                    StringBuilder errors = new StringBuilder();

                    if (NewNumber < 0 || NewNumber > 1000)
                        errors.AppendLine("Укажите номер зала");
                    if (NewSize == null)
                        errors.AppendLine("Укажите размер зала");



                    if (errors.Length > 0)
                    {
                        MessageBox.Show(errors.ToString());
                        return;
                    }

                    try
                    {
                        resultStr = HallsD.AddHallSize(NewNumber, NewSize);
                        MessageBox.Show("Информация сохранена!");
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

        private void OpenHallMethod()
        {
            Halls hall = new Halls();
            hall.Show();
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
                    if (SelectedHall != null)
                    {
                        resultStr = HallsD.DeleteHall(SelectedHall);
                        SetNullValuesProperties();
                        UpdateAllDataView();
                    }



                }
          );
            }
            set { deleteHall = value; }
        }

        private RelayCommand editHall;
        public RelayCommand EditHall
        {
            get
            {
                return editHall ?? new RelayCommand(obj =>
                {
                    string resultStr = "Не выбран сотрудник";
                    if (SelectedHall != null)
                    {
                        resultStr = HallsD.editHall(SelectedHall, NewNumber, NewSize);

                        UpdateAllDataView();
                        SetNullValuesProperties();
                        MessageBox.Show(resultStr);
                    }
                    else MessageBox.Show(resultStr);
                });
            }
        }

        private void SetNullValuesProperties()
        {
            NewNumber = 0;
            NewSize = null;
        }

        private void UpdateAllDataView()
        {
            UpdateAllHallsView();
        }



        private void UpdateAllHallsView()
        {
            AllHalls = HallsD.GetAllHall();

            Halls.AllHallsView.ItemsSource = null;
            Halls.AllHallsView.Items.Clear();
            Halls.AllHallsView.ItemsSource = AllHalls;
            Halls.AllHallsView.Items.Refresh();
        }


        private RelayCommand openHall;
        public RelayCommand OpenHall
        {
            get
            {
                return openHall ?? new RelayCommand(obj =>
                {

                    OpenHallMethod();
                }
                    );

            }
            set { openHall = value; }
        }

        private void OpenGenaralDataMethod()
        {
            GeneralDataWindow generalData = new GeneralDataWindow();
            generalData.Show();
        }

        private RelayCommand openGen;
        public RelayCommand OpenGen
        {
            get
            {
                return openGen ?? new RelayCommand(obj =>
                {

                    OpenGenaralDataMethod();
                }
                    );

            }
            set { openGen = value; }
        }



        private void OpenEditHallsMethod(Залы _halls)
        {
            EditHalls editFilm = new EditHalls(_halls);
            editFilm.Show();
        }

        private RelayCommand openeditHalls;
        public RelayCommand OpenEditHalls
        {
            get
            {
                return openeditHalls ?? new RelayCommand(obj =>
                {
                    // если фильмы
                    if (SelectedHall != null)
                    {
                        OpenEditHallsMethod(SelectedHall);
                    }

                }
                    );

            }
            set { openeditHalls = value; }
        }


        public void Dispose()
        {
            CinemaDataContainer.GetContext().Dispose();
        }
    }
}
