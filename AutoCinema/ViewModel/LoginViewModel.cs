using AutoCinema.Core;
using AutoCinema.DataBase;
using System;
using System.ComponentModel;
using System.Linq;
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

        private void ClickMethod()
        {
            Пользователи p = cinemaData.Пользователи.FirstOrDefault(u => u.Логин == Login);
            if (p != null)
            {
                if (p.Пароль == Password)
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

                    else
                    {
                        MessageBox.Show("Такого пользователя не существует");
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
