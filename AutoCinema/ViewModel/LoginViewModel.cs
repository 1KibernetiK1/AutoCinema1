using AutoCinema.Core;
using AutoCinema.DataBase;
using AutoCinema.Domains;
using AutoCinema.Security;
using AutoCinema.View.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Windows;
using System.Windows.Input;

namespace AutoCinema.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged, IDisposable
    {
        CinemaDataContainer cinemaData = CinemaDataContainer.GetContext();
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ClickCommand { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string AccessLevel { get; set; }

        public LoginViewModel()
        {
            cinemaData = new CinemaDataContainer();
            ClickCommand = new RelayCommand(arg => ClickMethod());

        }

        public static Пользователи SelectedUsers { get; set; }

        private List<Пользователи> allUsers = Users.GetAllUsers();

        public List<Пользователи> AllUsers
        {
            get { return allUsers; }
            set
            {
                allUsers = value;
                RaisePropertyChanged("AllUsers");
            }
        }

        private void ClickMethod()
        {
            Пользователи p = cinemaData.Пользователи.FirstOrDefault(u => u.Логин == Login);
            if (p != null)
            {
                if (p.Пароль == EncryptionPassword.GetHash(Password))
                {
                    if (p.УровеньДоступа == "Администратор")
                    {
                        AccessLevel = p.УровеньДоступа;
                        RaisePropertyChanged("Success_admin");
                    }
                   

                    if (p.УровеньДоступа == "Кассир")
                    {
                        AccessLevel = p.УровеньДоступа;
                        RaisePropertyChanged("Success_cashier");
                    }
                 


                    if (p.УровеньДоступа == "Пользователь")
                    {
                        AccessLevel = p.УровеньДоступа;
                        RaisePropertyChanged("Success_user");
                    }
                  




                }
                else
                {
                    RaisePropertyChanged("InvalidPassword");
                }
            }
            else
            {
                RaisePropertyChanged("NotExistUser");
            }
        }

        private RelayCommand addNewUsers;
        public RelayCommand AddNewUsers
        {
            get
            {
                return addNewUsers ?? new RelayCommand(obj =>
                {
                    string resultStr = "";

                    StringBuilder errors = new StringBuilder();

                    if (string.IsNullOrWhiteSpace(Login))
                        errors.AppendLine("Укажите Логин");
                    if (string.IsNullOrWhiteSpace(Password))
                        errors.AppendLine("Укажите пароль");
                    if (string.IsNullOrWhiteSpace(AccessLevel))
                        errors.AppendLine("Укажите уровень доступа");



                    if (errors.Length > 0)
                    {
                        MessageBox.Show(errors.ToString());
                        return;
                    }

                    try
                    {
                        resultStr = Users.AddUser(Login, Password, AccessLevel);
                        MessageBox.Show("Информация сохранена!");
                        SetNullValuesProperties();
                        UpdateAllUserView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }


                }
          );
            }
        }








        private RelayCommand deleteUser;
        public RelayCommand DeleteUser
        {
            get
            {
                return deleteUser ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    // если фильмы
                    if (SelectedUsers != null)
                    {
                        resultStr = Users.DeleteUser(SelectedUsers);
                        SetNullValuesProperties();
                        UpdateAllUserView();
                    }



                }
          );
            }
            set { deleteUser = value; }
        }

        private void SetNullValuesProperties()
        {
            Login = null;
            Password = null;
            AccessLevel = null;
        }





        private void UpdateAllUserView()
        {
            AllUsers = Users.GetAllUsers();

            UserControlWindow.AllusersView.ItemsSource = null;
            UserControlWindow.AllusersView.Items.Clear();
            UserControlWindow.AllusersView.ItemsSource = AllUsers;
            UserControlWindow.AllusersView.Items.Refresh();
        }

        private void OpenUsersMethod()
        {
            UserControlWindow userControl = new UserControlWindow();
            userControl.Show();
        }

        private RelayCommand openUser;
        public RelayCommand OpenUser
        {
            get
            {
                return openUser ?? new RelayCommand(obj =>
                {

                    OpenUsersMethod();
                }
                    );

            }
            set { openUser = value; }
        }


      

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
            {
                return;
            }
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public void Dispose()
        {
            // мы должны освободить ресурсы контекста при удалении ViewModel
            cinemaData.Dispose();
        }
    }
}
