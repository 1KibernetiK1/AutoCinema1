using AutoCinema.DataBase;
using AutoCinema.Security;
using System.Collections.Generic;
using System.Linq;

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

        public static string AddReg(string name, string password, string access)
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
                    УровеньДоступа = "Пользователь"
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



        public static string editUser(Пользователи oldUsers, string name, string password, string access)
        {
            string result = "Такого фильма не существует";
            Пользователи Users = CinemaDataContainer.GetContext().Пользователи.FirstOrDefault(f => f.ID == oldUsers.ID);
            Users.Логин = name;
            Users.Пароль = password;
            Users.УровеньДоступа = access;
            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! Пользователь " + Users.Логин + " изменен";

            return result;
        }
    }
}
