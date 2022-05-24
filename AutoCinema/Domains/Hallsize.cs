using AutoCinema.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AutoCinema.Domains
{
    public static class Hallsize
    {
        public static List<РазмерыЗалов> GetAllHallSizes()
        {

            var result = CinemaDataContainer.GetContext().РазмерыЗалов.ToList();
            return result;

        }

        public static string AddHallSize(string name, int count)
        {
            string result = "Уже существует";

            //проверяем есть ли фильм
            bool checkIsExist = CinemaDataContainer.GetContext().РазмерыЗалов.Any(
            el => el.Наименование == name
            && el.КоличествоРядов == count);
            if (!checkIsExist)
            {
                РазмерыЗалов newHallSizes = new РазмерыЗалов
                {
                    Наименование = name,
                    КоличествоРядов = count
                };

                CinemaDataContainer.GetContext().РазмерыЗалов.Add(newHallSizes);
                CinemaDataContainer.GetContext().SaveChanges();
                result = "Сделано!";
            }
            return result;

        }

        public static string DeleteHallSize(РазмерыЗалов hallsize)
        {
            string result = "Такого размера не существует";


            CinemaDataContainer.GetContext().РазмерыЗалов.Remove(hallsize);
            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! Размер зала " + hallsize.Наименование + "удален";

            MessageBox.Show(result);

            return result;
        }

        public static string editHallSize(РазмерыЗалов hallsizes, string newName, int newcount)
        {
            string result = "Такого размера не существует";
            MessageBox.Show(result, newName);
            РазмерыЗалов Sizes = CinemaDataContainer.GetContext().РазмерыЗалов.FirstOrDefault(f => f.ID == hallsizes.ID);
            Sizes.Наименование = newName;
            Sizes.КоличествоРядов = newcount;

            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! размер зала " + Sizes.Наименование + "изменен";

            MessageBox.Show(result);

            return result;
        }
    }
}
