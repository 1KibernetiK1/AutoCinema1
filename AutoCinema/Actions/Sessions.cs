using AutoCinema.DataBase;
using System.Collections.Generic;
using System.Linq;
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

        public static string editSession(Сеансы sessions, int NewIDFilm, int NewIdHall, string Newdate, string Newtime, string NewNewISFirst)
        {
            string result = "Такого размера не существует";
            Сеансы Session = CinemaDataContainer.GetContext().Сеансы.FirstOrDefault(f => f.ID == sessions.ID);
            Session.IDФильма = NewIDFilm;
            Session.IDЗала = NewIdHall;
            Session.Дата = Newdate;
            Session.Время = Newtime;
            Session.Премьера = NewNewISFirst;


            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! Сеанс " + Session.ID + " изменен";

            MessageBox.Show(result);

            return result;
        }
    }
}
