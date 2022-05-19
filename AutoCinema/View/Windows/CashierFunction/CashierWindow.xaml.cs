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

namespace AutoCinema.View.Windows.CashierFunction
{
    /// <summary>
    /// Логика взаимодействия для CashierWindow.xaml
    /// </summary>
    public partial class CashierWindow : Window
    {
        public CashierWindow()
        {
            InitializeComponent();

            button_Copy.DataContext = new BuyingTicketsViewModel();
            button_Copy2.DataContext = new SessionsViewModel();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
