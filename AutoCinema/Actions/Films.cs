using AutoCinema.DataBase;
using System.Collections.Generic;
using System.Linq;

namespace AutoCinema.Domains
{
    public static class Films
    {


        public static List<Фильмы> GetAllFilms()
        {

            var result = CinemaDataContainer.GetContext().Фильмы.ToList();
            return result;

        }

        public static string AddFilm(string name, string genre, string duration, int year, string country, string authors, string descriptions)
        {
            string result = "Уже существует";

            //проверяем есть ли фильм
            bool checkIsExist = CinemaDataContainer.GetContext().Фильмы.Any(
            el => el.Название == name
            && el.Жанр == genre
            && el.Длительность == duration
            && el.Год == year
            && el.Страна == country
            && el.Авторы == authors
            && el.Описание == descriptions);
            if (!checkIsExist)
            {
                Фильмы newFilms = new Фильмы
                {
                    Название = name,
                    Жанр = genre,
                    Длительность = duration,
                    Год = year,
                    Страна = country,
                    Авторы = authors,
                    Описание = descriptions
                };

                CinemaDataContainer.GetContext().Фильмы.Add(newFilms);
                CinemaDataContainer.GetContext().SaveChanges();

            }
            return result;

        }

      



        public static string DeleteFilm(Фильмы film)
        {
            string result = "Такого фильма не существует";

            CinemaDataContainer.GetContext().Фильмы.Remove(film);
            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! Фильм " + film.Название + " удален";

            return result;
        }

        public static string editFilm(Фильмы oldFilm, string newName, string newGenre, string newDuration, int newYear, string newCountry, string newAuthors, string newDescriptions)
        {
            string result = "Такого фильма не существует";
            Фильмы Film = CinemaDataContainer.GetContext().Фильмы.FirstOrDefault(f => f.ID == oldFilm.ID);
            Film.Название = newName;
            Film.Жанр = newGenre;
            Film.Длительность = newDuration;
            Film.Год = newYear;
            Film.Страна = newCountry;
            Film.Авторы = newAuthors;
            Film.Описание = newDescriptions;
            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! Фильм " + Film.Название + " изменен";

            return result;
        }


    }
}
