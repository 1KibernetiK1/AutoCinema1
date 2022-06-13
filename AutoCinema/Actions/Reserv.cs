using AutoCinema.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AutoCinema.Domains
{
    public static class Reserv
    {
        public static List<Бронь> GetAllReserv()
        {

            var result = CinemaDataContainer.GetContext().Бронь.ToList();
            return result;

        }

        public static string AddReserv(string name, string phone)
        {
            string result = "Уже существует";

            //проверяем есть ли фильм
            bool checkIsExist = CinemaDataContainer.GetContext().Бронь.Any(
            el => el.ФИО == name
            && el.Телефон == phone);
            if (!checkIsExist)
            {
                Бронь newReserv = new Бронь
                {
                    ФИО = name,
                    Телефон = phone
                };

                CinemaDataContainer.GetContext().Бронь.Add(newReserv);
                CinemaDataContainer.GetContext().SaveChanges();
                result = "Сделано!";
            }
            return result;

        }

        public static string DeleteReserv(Бронь reserv)
        {
            string result = "не существует";


            CinemaDataContainer.GetContext().Бронь.Remove(reserv);
            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! Бронирование " + reserv.ФИО + " удалено";

            MessageBox.Show(result);

            return result;
        }

        public static string editReserv(Бронь reservasion, string newName, string newcount)
        {
            string result = "Такого размера не существует";
            MessageBox.Show(result, newName);
            Бронь reserv = CinemaDataContainer.GetContext().Бронь.FirstOrDefault(f => f.ID == reservasion.ID);
            reserv.ФИО = newName;
            reserv.Телефон = newcount;

            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! Бронирование " + reserv.IDБилета + " изменено";

            MessageBox.Show(result);

            return result;
        }
    }
}
