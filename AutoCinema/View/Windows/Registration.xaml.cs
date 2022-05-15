using AutoCinema.DataBase;
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

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Password == null)
            {
                Button_reg.IsEnabled = false;
            }
            else
            {
                Button_reg.IsEnabled = true;
            }
        }

        private void Button_reg_Click(object sender, RoutedEventArgs e)
        {
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
                    Пароль = PasswordTextBox.Password.ToString(),
                    УровеньДоступа = AcceptComboBox.Text
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
