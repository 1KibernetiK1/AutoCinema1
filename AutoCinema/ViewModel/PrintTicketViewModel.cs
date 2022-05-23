using AutoCinema.Core;
using AutoCinema.View.Windows;

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
