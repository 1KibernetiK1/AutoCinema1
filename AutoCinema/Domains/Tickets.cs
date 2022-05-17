using AutoCinema.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            MessageBox.Show(result);

            CinemaDataContainer.GetContext().Билеты.Remove(Tickets);
            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! билет " + Tickets.ID + "удален";

            MessageBox.Show(result);

            return result;
        }

        //public static string editHall(Залы hall, int newName, РазмерыЗалов newCount)
        //{
        //    string result = "Такого размера не существует";
        //    MessageBox.Show(result);
        //    Залы halls = CinemaDataContainer.GetContext().Залы.FirstOrDefault(f => f.ID == hall.ID);
        //    halls.НомерЗала = newName;
        //    halls.РазмерыЗалов = newCount;


        //    CinemaDataContainer.GetContext().SaveChanges();
        //    result = "Сделано! размер зала " + halls.НомерЗала + "изменен";

        //    MessageBox.Show(result);

        //    return result;
        //}
    }
}
