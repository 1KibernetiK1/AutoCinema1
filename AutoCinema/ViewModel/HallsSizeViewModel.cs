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
    public class HallsSizeViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        CinemaDataContainer cinemaData = CinemaDataContainer.GetContext();

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private List<РазмерыЗалов> allSizes = Hallsize.GetAllHallSizes();

        public List<РазмерыЗалов> AllSizes
        {
            get { return allSizes; }
            set
            {
                allSizes = value;
                NotifyPropertyChanged("AllSizes");
            }
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
        public static string SizeName { get; set; }
        public static int SizeCount { get; set; }
        #endregion


        public static РазмерыЗалов SelectedHallsize { get; set; }


        private RelayCommand addNewHall;
        public RelayCommand AddNewHallSize
        {
            get
            {
                return addNewHall ?? new RelayCommand(obj =>
                {
                    string resultStr = "";

                    StringBuilder errors = new StringBuilder();

                    if (string.IsNullOrWhiteSpace(SizeName))
                        errors.AppendLine("Укажите название зала");
                    if (SizeCount < 0 || SizeCount > 500)
                        errors.AppendLine("Укажите размер зала");


                    if (errors.Length > 0)
                    {
                        MessageBox.Show(errors.ToString());
                        return;
                    }

                    try
                    {
                        resultStr = Hallsize.AddHallSize(SizeName, SizeCount);
                        MessageBox.Show("Информация сохранена!");
                        SetNullValuesProperties();
                        UpdateAllDataView();
                        OpenHallsizeMethod();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }


                }
          );
            }
        }



        //private void OpenEditFilmMethod(РазмерыЗалов hallsize)
        //{
        //    EditFilm editFilm = new EditFilm(hallsize);
        //    editFilm.Show();
        //}





        private RelayCommand deleteHallSize;
        public RelayCommand DeleteHallSize
        {
            get
            {
                return deleteHallSize ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    // если фильмы
                    if (SelectedHallsize != null)
                    {
                        resultStr = Hallsize.DeleteHallSize(SelectedHallsize);
                        SetNullValuesProperties();
                        UpdateAllDataView();
                        OpenHallsizeMethod();
                    }

                    //обновление
                }
          );
            }
            set { deleteHallSize = value; }
        }

        private RelayCommand editHall;
        public RelayCommand EditHall
        {
            get
            {
                return editHall ?? new RelayCommand(obj =>
                {
                    Window window = new Window();
                    string resultStr = "Не выбран сотрудник";
                    if (SelectedHallsize != null)
                    {
                        resultStr = Hallsize.editHallSize(SelectedHallsize, SizeName, SizeCount);
                        SetNullValuesProperties();
                        UpdateAllDataView();

                        MessageBox.Show(resultStr);
                        window.Close();
                    }
                    else MessageBox.Show(resultStr);
                });
            }
        }

        private void SetNullValuesProperties()
        {
            SizeName = null;
            SizeCount = 0;
        }



        private void UpdateAllDataView()
        {
            UpdateAllHallSizesView();
        }

        private void UpdateAllHallSizesView()
        {
            AllSizes = Hallsize.GetAllHallSizes();

            Halls.AllHallssizeView.ItemsSource = null;
            Halls.AllHallssizeView.Items.Clear();
            Halls.AllHallssizeView.ItemsSource = AllSizes;
            Halls.AllHallssizeView.Items.Refresh();
        }


        private void OpenHallsizeMethod()
        {
            Halls halls = new Halls();
            halls.Show();
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




        public void Dispose()
        {
            cinemaData.Dispose();
        }
    }
}
