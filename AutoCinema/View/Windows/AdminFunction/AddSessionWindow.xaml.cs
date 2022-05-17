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
    /// Логика взаимодействия для AddSessionWindow.xaml
    /// </summary>
    public partial class AddSessionWindow : Window
    {
        private SessionsViewModel viewModel = new SessionsViewModel();

        public AddSessionWindow()
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }
    }
}