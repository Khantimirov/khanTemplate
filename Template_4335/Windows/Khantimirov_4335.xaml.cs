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
using System.Runtime.Remoting.Contexts;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using Window = System.Windows.Window;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;
using Template_4335.Class;

namespace Template_4335.Windows
{
    /// <summary>
    /// Логика взаимодействия для Khantimirov_4335.xaml
    /// </summary>
    /// 
    public partial class Khantimirov_4335 : Window
    {
        private readonly Class.SkiServiceService _skiServiceService;
        public Khantimirov_4335(ApplicationContext context)
        {
            InitializeComponent();
            ExcelApplication excel = new ExcelApplication();

            _skiServiceService = new SkiServiceService(context, excel);
        }

        private void Import_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                DefaultExt = "*.xls;*.xlsx",
                Filter = "файл Excel (Spisok.xlsx)|*.xlsx",
                Title = "Выберите файл для импорта"
            };
            bool? showDialogResult = openFileDialog.ShowDialog();
            if (!showDialogResult.HasValue)
                return;
            if (!showDialogResult.Value)
                return;
            string fileName = openFileDialog.FileName;
            (bool importResult, int count) = _skiServiceService.ImportEntitiesFromWorkbook(fileName);
            if (!importResult)
            {
                MessageBox.Show("Неудалось импортировать", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show($"Импорт зваершён, загружено {count} строк", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Export_btn_Click(object sender, RoutedEventArgs e)
        {
        Workbook workbook = _skiServiceService.ExportEntities();
        string fileName = Directory.GetCurrentDirectory() + $"{Guid.NewGuid()}.xls";
        try
        {
            workbook.SaveAs(fileName, ".xls");
        }
        catch 
        { 
        
        }
    }

        private void ImportJS_btn_Click(object sender, RoutedEventArgs e)
        {
        OpenFileDialog openFileDialog = new OpenFileDialog()
        {
            DefaultExt = "*.json",
            Filter = "файл Json (Spisok.json)|*.json",
            Title = "Выберите файл для импорта"
        };
        bool? showDialogResult = openFileDialog.ShowDialog();
        if (!showDialogResult.HasValue)
            return;
        if (!showDialogResult.Value)
            return;
        string fileName = openFileDialog.FileName;
        FileInfo fileInfo = new FileInfo(fileName);

        byte[] data;
        using (FileStream stream = fileInfo.OpenRead())
        {
            MemoryStream memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            data = memoryStream.ToArray();
        }
        string json = Encoding.UTF8.GetString(data);
        (bool importResult, int count) = _skiServiceService.ImportJsonData(json);
        if (!importResult)
        {
            MessageBox.Show("Неудалось импортировать", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        MessageBox.Show($"Импорт завершён, загружено {count} сущностей", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ExportJS_btn_Click(object sender, RoutedEventArgs e)
        {
            Document document = _skiServiceService.ExportToWord();
            string fileName = Directory.GetCurrentDirectory() + $"{Guid.NewGuid()}.docx";
            try
            {
                document.SaveAs(fileName, ".docx");
            }
            catch 
            { 
    
            }
        }
    }
}
