using AutoCinema.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCinema.Domains
{
    public class Users
    {
        public static List<Пользователи> GetAllUsers()
        {

            var result = CinemaDataContainer.GetContext().Пользователи.ToList();
            return result;

        }

        public static string AddUser(string name, string password, string access)
        {
            string result = "Уже существует";

            //проверяем есть ли фильм
            bool checkIsExist = CinemaDataContainer.GetContext().Пользователи.Any(
            el => el.Логин == name
            && el.Пароль == password
            && el.УровеньДоступа == access);
            if (!checkIsExist)
            {
                Пользователи newUsers = new Пользователи
                {
                    Логин = name,
                    Пароль = password,
                    УровеньДоступа = access
                };

                CinemaDataContainer.GetContext().Пользователи.Add(newUsers);
                CinemaDataContainer.GetContext().SaveChanges();
                result = "Сделано!";
            }
            return result;

        }

        public static string DeleteUser(Пользователи user)
        {
            string result = "Такого фильма не существует";

            CinemaDataContainer.GetContext().Пользователи.Remove(user);
            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! Пользователь " + user.Логин + " удален";

            return result;
        }

        //public static string editFilm(Фильмы oldFilm, string newName, string newGenre, string newDuration, int newYear, string newCountry, string newAuthors, string newDescriptions)
        //{
        //    string result = "Такого фильма не существует";
        //    Фильмы Film = CinemaDataContainer.GetContext().Фильмы.FirstOrDefault(f => f.ID == oldFilm.ID);
        //    Film.Название = newName;
        //    Film.Жанр = newGenre;
        //    Film.Длительность = newDuration;
        //    Film.Год = newYear;
        //    Film.Страна = newCountry;
        //    Film.Авторы = newAuthors;
        //    Film.Описание = newDescriptions;
        //    CinemaDataContainer.GetContext().SaveChanges();
        //    result = "Сделано! Фильм " + Film.Название + "изменен";

        //    return result;
        //}
    }
}
