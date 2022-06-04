using AutoCinema.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AutoCinema.Domains
{
    public class Tickets
    {
        public static List<Билеты> GetAllTickets()
        {

            var result = CinemaDataContainer.GetContext().Билеты.ToList();
            return result;

        }



        public static string AddTicket(int IDSession, int IdHall, int Row, int place)
        {
            string result = "Не найдено";
            //проверяем есть ли фильм



            Билеты newTickets = new Билеты
            {
                IDСеанса = IDSession,
                IDЗала = IdHall,
                Ряд = Row,
                Место = place,
                Бронь = false
            };

            CinemaDataContainer.GetContext().Билеты.Add(newTickets);
            CinemaDataContainer.GetContext().SaveChanges();
            result = "Найдено";


            return result;

        }

        public static string DeleteTickets(Билеты Tickets)
        {
            string result = "Такого билета не существует";



            CinemaDataContainer.GetContext().Билеты.Remove(Tickets);
            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! билет " + Tickets.ID + "удален";

            MessageBox.Show(result);

            return result;
        }

        public static string editTicket(Билеты Newtickets, int NewIDSession, int NewIdHall, int NewRow, int Newplace)
        {
            string result = "Такого размера не существует";
            Билеты tickets = CinemaDataContainer.GetContext().Билеты.FirstOrDefault(f => f.ID == Newtickets.ID);
            tickets.IDСеанса = NewIDSession;
            tickets.IDЗала = NewIdHall;
            tickets.Ряд = NewRow;
            tickets.Место = Newplace;
            tickets.Бронь = false;


            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! размер зала " + tickets.ID + " изменен";

            MessageBox.Show(result);

            return result;
        }
    }
}
