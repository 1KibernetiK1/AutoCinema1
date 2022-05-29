using AutoCinema.Core;
using AutoCinema.View.Windows;
using Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Windows.Controls;

namespace AutoCinema.ViewModel
{
    public class ExcelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        private RelayCommand filmExcel;
        public RelayCommand FilmExcel
        {
            get
            {
                return filmExcel ?? new RelayCommand(obj =>
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = true;
                    Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                    Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                    for (int j = 0; j < WinFilms.AllFilmsView.Columns.Count; j++) //Для названия
                    {
                        Range myRange = (Range)sheet1.Cells[1, j + 1];
                        sheet1.Cells[1, j + 1].Font.Bold = true; //Чтобы заголовок был жирным шрифтом
                        sheet1.Columns[j + 1].ColumnWidth = 15; //Регулировка ширины столбца
                        myRange.Value2 = WinFilms.AllFilmsView.Columns[j].Header;
                    }
                    for (int i = 0; i < WinFilms.AllFilmsView.Columns.Count; i++) //Для содержимого
                    {
                        for (int j = 0; j < WinFilms.AllFilmsView.Items.Count; j++)
                        {
                            TextBlock b = WinFilms.AllFilmsView.Columns[i].GetCellContent(WinFilms.AllFilmsView.Items[j]) as TextBlock;
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                            myRange.Value2 = b.Text;
                        }
                    }

                }
          );
            }
        }

      
        

        private RelayCommand ticketExcel;
        public RelayCommand TicketExcel
        {
            get
            {
                return ticketExcel ?? new RelayCommand(obj =>
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = true;
                    Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                    Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                    for (int j = 0; j < BuyingTicketWindow.AllTickView.Columns.Count; j++) //Для названия
                    {
                        Range myRange = (Range)sheet1.Cells[1, j + 1];
                        sheet1.Cells[1, j + 1].Font.Bold = true; //Чтобы заголовок был жирным шрифтом
                        sheet1.Columns[j + 1].ColumnWidth = 15; //Регулировка ширины столбца
                        myRange.Value2 = BuyingTicketWindow.AllTickView.Columns[j].Header;
                    }
                    for (int i = 0; i < BuyingTicketWindow.AllTickView.Columns.Count; i++) //Для содержимого
                    {
                        for (int j = 0; j < BuyingTicketWindow.AllTickView.Items.Count; j++)
                        {
                            TextBlock b = BuyingTicketWindow.AllTickView.Columns[i].GetCellContent(BuyingTicketWindow.AllTickView.Items[j]) as TextBlock;
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                            myRange.Value2 = b.Text;
                        }
                    }

                }
          );
            }


        }

        private RelayCommand userExcel;
        public RelayCommand UserExcel
        {
            get
            {
                return userExcel ?? new RelayCommand(obj =>
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = true;
                    Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                    Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                    for (int j = 0; j < UserControlWindow.AllusersView.Columns.Count; j++) //Для названия
                    {
                        Range myRange = (Range)sheet1.Cells[1, j + 1];
                        sheet1.Cells[1, j + 1].Font.Bold = true; //Чтобы заголовок был жирным шрифтом
                        sheet1.Columns[j + 1].ColumnWidth = 15; //Регулировка ширины столбца
                        myRange.Value2 = UserControlWindow.AllusersView.Columns[j].Header;
                    }
                    for (int i = 0; i < UserControlWindow.AllusersView.Columns.Count; i++) //Для содержимого
                    {
                        for (int j = 0; j < UserControlWindow.AllusersView.Items.Count; j++)
                        {
                            TextBlock b = UserControlWindow.AllusersView.Columns[i].GetCellContent(UserControlWindow.AllusersView.Items[j]) as TextBlock;
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                            myRange.Value2 = b.Text;
                        }
                    }

                }
          );
            }


        }

        private RelayCommand priceExcel;
        public RelayCommand PriceExcel
        {
            get
            {
                return priceExcel ?? new RelayCommand(obj =>
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = true;
                    Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                    Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                    for (int j = 0; j < PriceTicketsWindow.AllPriceView.Columns.Count; j++) //Для названия
                    {
                        Range myRange = (Range)sheet1.Cells[1, j + 1];
                        sheet1.Cells[1, j + 1].Font.Bold = true; //Чтобы заголовок был жирным шрифтом
                        sheet1.Columns[j + 1].ColumnWidth = 15; //Регулировка ширины столбца
                        myRange.Value2 = PriceTicketsWindow.AllPriceView.Columns[j].Header;
                    }
                    for (int i = 0; i < PriceTicketsWindow.AllPriceView.Columns.Count; i++) //Для содержимого
                    {
                        for (int j = 0; j < PriceTicketsWindow.AllPriceView.Items.Count; j++)
                        {
                            TextBlock b = PriceTicketsWindow.AllPriceView.Columns[i].GetCellContent(PriceTicketsWindow.AllPriceView.Items[j]) as TextBlock;
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                            myRange.Value2 = b.Text;
                        }
                    }

                }
          );
            }


        }

        private HallsViewModel hallsView = new HallsViewModel();


        private RelayCommand hallsExcel;
        public RelayCommand HallsExcel
        {
          

            get
            {
                return hallsExcel ?? new RelayCommand(obj =>
                {
                   

                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = true;
                    Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                    Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                    for (int j = 0; j < Halls.AllHallsView.Columns.Count; j++) //Для названия
                    {
                        Range myRange = (Range)sheet1.Cells[1, j + 1];
                        sheet1.Cells[1, j + 1].Font.Bold = true; //Чтобы заголовок был жирным шрифтом
                        sheet1.Columns[j + 1].ColumnWidth = 15; //Регулировка ширины столбца
                        myRange.Value2 = Halls.AllHallsView.Columns[j].Header;
                    }
                    for (int i = 0; i < Halls.AllHallsView.Columns.Count; i++) //Для содержимого
                    {
                        for (int j = 0; j < Halls.AllHallsView.Items.Count; j++)
                        {
                            TextBlock b = Halls.AllHallsView.Columns[i].GetCellContent(Halls.AllHallsView.Items[j]) as TextBlock;
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                            myRange.Value2 = b.Text;
                        }
                    }

                }
          );
            }


        }

        private RelayCommand hallsSizeExcel;
        public RelayCommand HallsSizeExcel
        {
            get
            {
                return hallsSizeExcel ?? new RelayCommand(obj =>
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = true;
                    Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                    Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                    for (int j = 0; j < Halls.AllHallssizeView.Columns.Count; j++) //Для названия
                    {
                        Range myRange = (Range)sheet1.Cells[1, j + 1];
                        sheet1.Cells[1, j + 1].Font.Bold = true; //Чтобы заголовок был жирным шрифтом
                        sheet1.Columns[j + 1].ColumnWidth = 15; //Регулировка ширины столбца
                        myRange.Value2 = Halls.AllHallssizeView.Columns[j].Header;
                    }
                    for (int i = 0; i < Halls.AllHallssizeView.Columns.Count; i++) //Для содержимого
                    {
                        for (int j = 0; j < Halls.AllHallssizeView.Items.Count; j++)
                        {
                            TextBlock b = Halls.AllHallssizeView.Columns[i].GetCellContent(Halls.AllHallssizeView.Items[j]) as TextBlock;
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                            myRange.Value2 = b.Text;
                        }
                    }

                }
          );
            }


        }
    }
}
