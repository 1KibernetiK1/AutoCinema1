using AutoCinema.DataBase;
using AutoCinema.Security;
using System;
using System.Linq;
using System.Windows;

namespace AutoCinema.View
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();


        }



        private void Button_reg_Click(object sender, RoutedEventArgs e)
        {
            var tt = PasswordTextBox.Text;

            if (CinemaDataContainer.GetContext().Пользователи.Count(x => x.Логин == LoginTextBox.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином существует ", " Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                Пользователи userObj = new Пользователи()
                {
                    Логин = LoginTextBox.Text,
                    Пароль = EncryptionPassword.GetHash(tt),
                    УровеньДоступа = "Пользователь"
                };
                CinemaDataContainer.GetContext().Пользователи.Add(userObj);
                CinemaDataContainer.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно добавлены", " Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при добавлении данных!", " Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Close();
        }
    }
}
