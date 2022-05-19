using AutoCinema.Core;
using AutoCinema.DataBase;
using AutoCinema.Domains;
using AutoCinema.View.Windows;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private List<Фильмы> allFilms = Films.GetAllFilms();

        public List<Фильмы> AllFilms
        {
            get { return allFilms; }
            set
            {
                allFilms = value;
                NotifyPropertyChanged("AllFilms");
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
    }
}
