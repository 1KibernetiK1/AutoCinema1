using AutoCinema.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            CinemaDataContainer ctx = new CinemaDataContainer();

            string f, r, pl, pr, d, t, h;
            Билеты last = ctx.Билеты.ToList().Last();
            f = ctx.Фильмы.FirstOrDefault(c => c.ID == ctx.Сеансы.FirstOrDefault(s => s.ID == last.IDСеанса).IDФильма).Название;
            r = last.Ряд.Value.ToString();
            pl = last.Место.Value.ToString();
            d = ctx.Сеансы.FirstOrDefault(s => s.ID == last.IDСеанса).Дата;
            t = ctx.Сеансы.FirstOrDefault(s => s.ID == last.IDСеанса).Время;
            h = ctx.Залы.FirstOrDefault(c => c.ID == ctx.Сеансы.FirstOrDefault(s => s.ID == last.IDСеанса).IDЗала).НомерЗала.Value.ToString();
            Сеансы lastSeans = ctx.Сеансы.FirstOrDefault(s => s.ID == last.IDСеанса);
            pr = ctx.СтоимостьБилетов.FirstOrDefault(c => c.IDСеанса == lastSeans.ID).Стоимость.Value.ToString() + ".руб";

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
