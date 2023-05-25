using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_4335.Class
{
    public interface IExcelDataService
    {
        void LoadWorkbook(string fileName);
        (bool success, int count) ImportEntitiesFromWorkbook(string fileName);
        Workbook ExportEntities();
    }
}