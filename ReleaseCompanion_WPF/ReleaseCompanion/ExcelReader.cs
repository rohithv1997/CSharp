using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;

namespace ReleaseCompanion
{
    public class ExcelReader
    {
        public static List<Parameters> FetchDetailsFromExcel(string excelPath)
        {
            var _parameters = new List<Parameters>();
<<<<<<< HEAD
            //var fullPathToExcel = AppDomain.CurrentDomain.BaseDirectory + excelPath;
            string fullPathToExcel = excelPath;
=======
            // var fullPathToExcel = AppDomain.CurrentDomain.BaseDirectory + excelPath;
            var fullPathToExcel = excelPath;
>>>>>>> 2f2bddf61deddb2d741ba1b897a104e138c6967f
            DataTable dt = GetDataTable(fullPathToExcel, "Paths");

            foreach (DataRow dr in dt.Rows)
            {
                var param = new Parameters();
                int serialNumber = 0;
                if (int.TryParse(dr[0].ToString(), out serialNumber))
                {
                    param.SerialNumber = Convert.ToInt32(dr[0]);
                    param.NickName = Convert.ToString(dr[1]);
                    param.EnvironmentType = FetchEnvironmentType(Convert.ToString(dr[2]));
                    param.AppServerPath = Convert.ToString(dr[3]);
                    param.WindowsServiceServerPath = Convert.ToString(dr[4]);
                    param.AppURL = Convert.ToString(dr[5]);
                    param.AppBackupPath = Convert.ToString(dr[6]);
                    param.WindowsServiceBackupPath = Convert.ToString(dr[7]);
                    var start = Convert.ToString(dr[8]);
                    param.BatchFileStart = start != "" ? start : "Invalid";
                    var stop = Convert.ToString(dr[9]);
                    param.BatchFileStop = stop != "" ? stop : "Invalid";
                    param.DBServerName = Convert.ToString(dr[10]);
                    param.DBName = Convert.ToString(dr[11]);
                    param.DBBackupLocation = Convert.ToString(dr[12]);
                    param.FrameworkReleasePath = Convert.ToString(dr[13]);

                    _parameters.Add(param);
                }
                else
                {
                    break;
                }
            }
            return _parameters;
        }

        private static DataTable GetDataTable(string path, string workbookName)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path, ReadOnly: true);
            Excel._Worksheet workSheet = xlWorkbook.Sheets[workbookName];

            int index = 0;
            object rowIndex = 2;

            DataTable dt = new DataTable();
            dt.Columns.Add("S.No");
            dt.Columns.Add("Nick Name");
            dt.Columns.Add("Environment Type");
            dt.Columns.Add("App Server Path");
            dt.Columns.Add("WindowsService Server Path");
            dt.Columns.Add("App URL");
            dt.Columns.Add("App Backup Path");
            dt.Columns.Add("WindowsService Backup Path");
            dt.Columns.Add("BatchFile Start");
            dt.Columns.Add("BatchFile Stop");
            dt.Columns.Add("Database Server");
            dt.Columns.Add("Database Name");
            dt.Columns.Add("Database Backup Location");
            dt.Columns.Add("Framework Release location");

            DataRow row;

            while (((Excel.Range)workSheet.Cells[rowIndex, 1]).Value2 != null)
            {
                rowIndex = 2 + index;
                row = dt.NewRow();
                row[0] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 1]).Value2);
                row[1] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 2]).Value2);
                row[2] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 3]).Value2);
                row[3] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 4]).Value2);
                row[4] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 5]).Value2);
                row[5] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 6]).Value2);
                row[6] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 7]).Value2);
                row[7] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 8]).Value2);
                row[8] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 9]).Value2);
                row[9] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 10]).Value2);
                row[10] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 11]).Value2);
                row[11] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 12]).Value2);
                row[12] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 13]).Value2);
                row[13] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 14]).Value2);
                index++;
                dt.Rows.Add(row);
            }
            xlWorkbook.Close();
            xlApp.Quit();
            return dt;
        }

        private static EnvironmentType FetchEnvironmentType(string param)
        {
            if (param == "Broker Portal")
                return EnvironmentType.BrokerPortal;
            return EnvironmentType.LessorPortal;
        }
    }
}
