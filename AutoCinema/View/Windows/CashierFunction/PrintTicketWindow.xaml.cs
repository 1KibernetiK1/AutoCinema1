using AutoCinema.DataBase;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AutoCinema.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для PrintTicketWindow.xaml
    /// </summary>
    public partial class PrintTicketWindow : Window
    {

        public PrintTicketWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            string f, r, pl, pr, d, t, h;
            Билеты last = CinemaDataContainer.GetContext().Билеты.ToList().Last();
            f = CinemaDataContainer.GetContext().Фильмы.FirstOrDefault(c => c.ID == CinemaDataContainer.GetContext().Сеансы.FirstOrDefault(s => s.ID == last.IDСеанса).IDФильма).Название;
            r = last.Ряд.Value.ToString();
            pl = last.Место.Value.ToString();
            d = CinemaDataContainer.GetContext().Сеансы.FirstOrDefault(s => s.ID == last.IDСеанса).Дата;
            t = CinemaDataContainer.GetContext().Сеансы.FirstOrDefault(s => s.ID == last.IDСеанса).Время;
            h = CinemaDataContainer.GetContext().Залы.FirstOrDefault(c => c.ID == CinemaDataContainer.GetContext().Сеансы.FirstOrDefault(s => s.ID == last.IDСеанса).IDЗала).НомерЗала.Value.ToString();
            Сеансы lastSeans = CinemaDataContainer.GetContext().Сеансы.FirstOrDefault(s => s.ID == last.IDСеанса);
            pr = CinemaDataContainer.GetContext().СтоимостьБилетов.FirstOrDefault(c => c.IDСеанса == lastSeans.ID).Стоимость.Value.ToString() + " руб.";

            Film.Content = f.ToString();
            Row.Content = r.ToString();
            Place.Content = pl.ToString();
            Price.Content = pr.ToString();
            Date.Content = d.ToString();
            Time.Content = t.ToString();
            Hall.Content = h.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            if (dlg.ShowDialog() == true)
            {
                dlg.PrintVisual(TicketGrid, "Билет");

            }
        }


    }
}
