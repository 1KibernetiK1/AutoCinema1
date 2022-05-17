﻿using AutoCinema.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutoCinema.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для PriceTicketsWindow.xaml
    /// </summary>
    public partial class PriceTicketsWindow : Window
    {
        public static DataGrid AllPriceView;

        public PriceTicketsWindow()
        {
            InitializeComponent();


            DataContext = new PricesViewModel();
            AllPriceView = ViewAllPriceSize;
        }
    }
}
