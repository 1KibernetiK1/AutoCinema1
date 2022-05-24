﻿using AutoCinema.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AutoCinema.Domains
{
    public class Prices
    {


        public static List<СтоимостьБилетов> GetAllPrices()
        {

            var result = CinemaDataContainer.GetContext().СтоимостьБилетов.ToList();
            return result;

        }

        public static string AddPrice(int session, int price)
        {
            string result = "Не найдено";
            //проверяем есть ли цена



            СтоимостьБилетов newPrices = new СтоимостьБилетов
            {
                IDСеанса = session,
                Стоимость = price
            };

            CinemaDataContainer.GetContext().СтоимостьБилетов.Add(newPrices);
            CinemaDataContainer.GetContext().SaveChanges();
            result = "Найдено";


            return result;

        }

        public static string DeletePrice(СтоимостьБилетов prices)
        {
            string result = "Такого сеанса не существует";


            CinemaDataContainer.GetContext().СтоимостьБилетов.Remove(prices);
            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! сеанс " + prices.Стоимость + "удален";

            MessageBox.Show(result);

            return result;
        }

        public static string editPrice(СтоимостьБилетов pricetick, int session, int price)
        {
            string result = "Такого размера не существует";
            MessageBox.Show(result);
            СтоимостьБилетов prices = CinemaDataContainer.GetContext().СтоимостьБилетов.FirstOrDefault(f => f.ID == pricetick.ID);
            prices.IDСеанса = session;
            prices.Стоимость = price;


            CinemaDataContainer.GetContext().SaveChanges();
            result = "Сделано! Стоимость изменена " + pricetick.Стоимость + "изменен";

            MessageBox.Show(result);

            return result;
        }
    }
}

