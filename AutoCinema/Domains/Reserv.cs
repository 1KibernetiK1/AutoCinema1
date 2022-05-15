using AutoCinema.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static string DeleteHallSize(Бронь reserv)
        {
            string result = "не существует";

            MessageBox.Show(result);

            CinemaDataContainer.GetContext().Бронь.Remove(reserv);
            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! Размер зала " + reserv.ФИО + "удален";

            MessageBox.Show(result);

            return result;
        }

        //public static string editHallSize(РазмерыЗалов hallsizes, string newName, int newcount)
        //{
        //    string result = "Такого размера не существует";
        //    MessageBox.Show(result, newName);
        //    РазмерыЗалов Sizes = CinemaDataContainer.GetContext().РазмерыЗалов.FirstOrDefault(f => f.ID == hallsizes.ID);
        //    Sizes.Наименование = newName;
        //    Sizes.КоличествоРядов = newcount;

        //    CinemaDataContainer.GetContext().SaveChanges();
        //    result = "Сделано! размер зала " + Sizes.Наименование + "изменен";

        //    MessageBox.Show(result);

        //    return result;
        //}
    }
}
