using AutoCinema.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AutoCinema.Domains
{
    public static class HallsD
    {
        public static List<Залы> GetAllHall()
        {

            var result = CinemaDataContainer.GetContext().Залы.ToList();
            return result;

        }

        public static string AddHallSize(int name, string count)
        {
            string result = "Не найдено";
            //проверяем есть ли фильм



            Залы newHallSizes = new Залы
            {
                НомерЗала = name,
                РазмерыЗалов = CinemaDataContainer.GetContext().РазмерыЗалов.FirstOrDefault(a => a.Наименование == count),
                IDРазмера = CinemaDataContainer.GetContext().РазмерыЗалов.FirstOrDefault(a => a.Наименование == count).ID
            };

            CinemaDataContainer.GetContext().Залы.Add(newHallSizes);
            CinemaDataContainer.GetContext().SaveChanges();
            result = "Найдено";


            return result;

        }

        public static string DeleteHall(Залы hall)
        {
            string result = "Такого размера не существует";


            CinemaDataContainer.GetContext().Залы.Remove(hall);
            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! Размер зала " + hall.НомерЗала + "удален";

            MessageBox.Show(result);

            return result;
        }

        public static string editHall(Залы hall, int newName, string count)
        {
            string result = "Такого размера не существует";
            MessageBox.Show(result);
            Залы halls = CinemaDataContainer.GetContext().Залы.FirstOrDefault(f => f.ID == hall.ID);
            halls.НомерЗала = newName;
            halls.РазмерыЗалов = CinemaDataContainer.GetContext().РазмерыЗалов.FirstOrDefault(a => a.Наименование == count);
            halls.IDРазмера = CinemaDataContainer.GetContext().РазмерыЗалов.FirstOrDefault(a => a.Наименование == count).ID;


            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! размер зала " + halls.НомерЗала + "изменен";

            MessageBox.Show(result);

            return result;
        }
    }
}
