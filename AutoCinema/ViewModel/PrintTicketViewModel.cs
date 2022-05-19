using AutoCinema.Core;
using AutoCinema.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCinema.ViewModel
{
    public class PrintTicketViewModel
    {
        private void OpenPrintTicketMethod()
        {
            PrintTicketWindow PrintTickets = new PrintTicketWindow();
            PrintTickets.Show();
        }

        private RelayCommand openPrintTicket;
        public RelayCommand OpenPrintTicket
        {
            get
            {
                return openPrintTicket ?? new RelayCommand(obj =>
                {

                    OpenPrintTicketMethod();
                }
                    );

            }
            set { openPrintTicket = value; }
        }
    }
}
