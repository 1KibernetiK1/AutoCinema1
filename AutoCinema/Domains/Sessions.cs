using AutoCinema.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoCinema.Domains
{
    public class Sessions
    {
        public static List<Сеансы> GetAllSessions()
        {

            var result = CinemaDataContainer.GetContext().Сеансы.ToList();
            return result;

        }

       

        public static string AddSession(int IDFilm, int IdHall, string date, string time, string NewISFirst)
        {
            string result = "Не найдено";
            //проверяем есть ли фильм



            Сеансы newSession = new Сеансы
            {
                IDФильма = IDFilm,
                IDЗала = IdHall,
                Дата = date,
                Время = time,
                Премьера = NewISFirst
            };

            CinemaDataContainer.GetContext().Сеансы.Add(newSession);
            CinemaDataContainer.GetContext().SaveChanges();
            result = "Найдено";


            return result;

        }

        public static string DeleteSessions(Сеансы sessions)
        {
            string result = "Такого сеанса не существует";

          

            CinemaDataContainer.GetContext().Сеансы.Remove(sessions);
            CinemaDataContainer.GetContext().SaveChanges();
           

          

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
