using AutoCinema.DataBase;
using AutoCinema.ViewModel;
using System.Web.UI;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using Window = Microsoft.Office.Interop.Excel.Window;

namespace AutoCinema.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для WinFilms.xaml
    /// </summary>
    public partial class WinFilms : Window
    {
        public static DataGrid AllFilmsView;

        public WinFilms()
        {
            InitializeComponent();

            DataContext = new FilmViewModel();
            AllFilmsView = ViewAllFilms;
        }


        #region БЕСПОЛЕЗНЫЕ ЭЛЕМЕНТЫ
        dynamic Window.Activate()
        {
            throw new System.NotImplementedException();
        }

        public dynamic ActivateNext()
        {
            throw new System.NotImplementedException();
        }

        public dynamic ActivatePrevious()
        {
            throw new System.NotImplementedException();
        }

        public bool Close(object SaveChanges, object Filename, object RouteWorkbook)
        {
            throw new System.NotImplementedException();
        }

        public dynamic LargeScroll(object Down, object Up, object ToRight, object ToLeft)
        {
            throw new System.NotImplementedException();
        }

        public Window NewWindow()
        {
            throw new System.NotImplementedException();
        }

        public dynamic _PrintOut(object From, object To, object Copies, object Preview, object ActivePrinter, object PrintToFile, object Collate, object PrToFileName)
        {
            throw new System.NotImplementedException();
        }

        public dynamic PrintPreview(object EnableChanges)
        {
            throw new System.NotImplementedException();
        }

        public dynamic ScrollWorkbookTabs(object Sheets, object Position)
        {
            throw new System.NotImplementedException();
        }

        public dynamic SmallScroll(object Down, object Up, object ToRight, object ToLeft)
        {
            throw new System.NotImplementedException();
        }

        public int PointsToScreenPixelsX(int Points)
        {
            throw new System.NotImplementedException();
        }

        public int PointsToScreenPixelsY(int Points)
        {
            throw new System.NotImplementedException();
        }

        public dynamic RangeFromPoint(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public void ScrollIntoView(int Left, int Top, int Width, int Height, object Start)
        {
            throw new System.NotImplementedException();
        }

        public dynamic PrintOut(object From, object To, object Copies, object Preview, object ActivePrinter, object PrintToFile, object Collate, object PrToFileName)
        {
            throw new System.NotImplementedException();
        }

        public Excel.Application Application => throw new System.NotImplementedException();

        public XlCreator Creator => throw new System.NotImplementedException();

        dynamic Window.Parent => throw new System.NotImplementedException();

        public Range ActiveCell => throw new System.NotImplementedException();

        public Chart ActiveChart => throw new System.NotImplementedException();

        public Pane ActivePane => throw new System.NotImplementedException();

        public dynamic ActiveSheet => throw new System.NotImplementedException();

        public dynamic Caption { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool DisplayFormulas { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool DisplayGridlines { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool DisplayHeadings { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool DisplayHorizontalScrollBar { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool DisplayOutline { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool _DisplayRightToLeft { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool DisplayVerticalScrollBar { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool DisplayWorkbookTabs { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool DisplayZeros { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool EnableResize { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool FreezePanes { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int GridlineColor { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public XlColorIndex GridlineColorIndex { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int Index => throw new System.NotImplementedException();

        public string OnWindow { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Panes Panes => throw new System.NotImplementedException();

        public Range RangeSelection => throw new System.NotImplementedException();

        public int ScrollColumn { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int ScrollRow { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Sheets SelectedSheets => throw new System.NotImplementedException();

        public dynamic Selection => throw new System.NotImplementedException();

        public bool Split { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int SplitColumn { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public double SplitHorizontal { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int SplitRow { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public double SplitVertical { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public double TabRatio { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public XlWindowType Type => throw new System.NotImplementedException();

        public double UsableHeight => throw new System.NotImplementedException();

        public double UsableWidth => throw new System.NotImplementedException();

        public bool Visible { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Range VisibleRange => throw new System.NotImplementedException();

        public int WindowNumber => throw new System.NotImplementedException();

        XlWindowState Window.WindowState { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public dynamic Zoom { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public XlWindowView View { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool DisplayRightToLeft { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public SheetViews SheetViews => throw new System.NotImplementedException();

        public dynamic ActiveSheetView => throw new System.NotImplementedException();

        public bool DisplayRuler { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool AutoFilterDateGrouping { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool DisplayWhitespace { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int Hwnd => throw new System.NotImplementedException();
        #endregion

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < ViewAllFilms.Columns.Count; j++) //Для названия
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true; //Чтобы заголовок был жирным шрифтом
                sheet1.Columns[j + 1].ColumnWidth = 15; //Регулировка ширины столбца
                myRange.Value2 = ViewAllFilms.Columns[j].Header;
            }
            for (int i = 0; i < ViewAllFilms.Columns.Count; i++) //Для содержимого
            { 
                for (int j = 0; j < ViewAllFilms.Items.Count; j++)
                {
                    TextBlock b = ViewAllFilms.Columns[i].GetCellContent(ViewAllFilms.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
        }
    }
}
