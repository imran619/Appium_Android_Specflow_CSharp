using System;
using System.Collections.Generic;
using ExcelSheet = Microsoft.Office.Interop.Excel;

namespace AppiumSpecFlow.Utility
{
    class Excel :WebDriverConfig
    {
        public List<List<string>> readDataSheet(string filePath, string sheetName)
        // This method returns all the data in a data sheet in a workbook 
        {
            //var customerData = new List<List<string>>();
            string value = string.Empty;
            ExcelSheet.Workbook xlWorkbook = null;
            ExcelSheet.Application xlApplication = new ExcelSheet.Application();
            xlWorkbook = xlApplication.Workbooks.Open(@filePath);

            ExcelSheet._Worksheet xlWorksheet = (ExcelSheet._Worksheet)xlWorkbook.Sheets[sheetName];
            ExcelSheet.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int columnCount = xlRange.Columns.Count;

            List<List<string>> dataSet = new List<List<string>>();

            for (int i = 1; i <= rowCount; i++)
            {
                List<string> subList = new List<string>();

                for (int j = 1; j <= columnCount; j++)
                {
                    subList.Add(xlRange.Cells[i, j].Value2.ToString());
                }
                dataSet.Add(subList);

            }

            foreach (var item in dataSet)
            {
                var sasas = item[0];
                var sasasa = item[1];
                var sasasa2 = item[2];
            }

            xlWorkbook.Close();
            xlApplication.Quit();

            return dataSet;
        }


        public String readExcel(string filePath, string workSheetName, int column, int row)
        {



            ExcelSheet.Application xlApplication = new ExcelSheet.Application();

            ExcelSheet.Workbook xlWorkbook = xlApplication.Workbooks.Open(@filePath);
            ExcelSheet._Worksheet xlWorksheet = (ExcelSheet._Worksheet)xlWorkbook.Sheets[workSheetName];
            ExcelSheet.Range xlRange = xlWorksheet.UsedRange;
            Console.Write(xlRange.Cells[row, column].Value2.ToString());
            String value = xlRange.Cells[row, column].Value2.ToString();
            xlWorkbook.Close();
            xlApplication.Quit();
            return value;

        }

        public List<string> readBrowserData (string filePath)

        {
            var envData = new List<string>();
            string value = string.Empty;
            ExcelSheet.Workbook xlWorkbook = null;
            ExcelSheet.Application xlApplication = new ExcelSheet.Application();
            xlWorkbook = xlApplication.Workbooks.Open(@filePath);
            ExcelSheet._Worksheet xlWorksheet = (ExcelSheet._Worksheet)xlWorkbook.Sheets["Init"];
            ExcelSheet.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
     
              
                    envData.Add(xlRange.Cells[2, 1].Value2.ToString());
                    envData.Add(xlRange.Cells[2, 2].Value2.ToString());
                    envData.Add(xlRange.Cells[2, 3].Value2.ToString());
                    envData.Add(xlRange.Cells[2, 4].Value2.ToString());
                    envData.Add(xlRange.Cells[2, 5].Value2.ToString());
                    envData.Add(xlRange.Cells[2, 6].Value2.ToString());
              

            return envData;
        }
    


    public List<string> readCustomerData(string filePath)

    {
        var customerData = new List<string>();
        string value = string.Empty;
        ExcelSheet.Workbook xlWorkbook = null;
        ExcelSheet.Application xlApplication = new ExcelSheet.Application();
        xlWorkbook = xlApplication.Workbooks.Open(@filePath);
        string env = getEnv();
        ExcelSheet._Worksheet xlWorksheet = (ExcelSheet._Worksheet)xlWorkbook.Sheets[env];
        ExcelSheet.Range xlRange = xlWorksheet.UsedRange;
        int rowCount = xlRange.Rows.Count;


        customerData.Add(xlRange.Cells[2, 4].Value2.ToString());
        customerData.Add(xlRange.Cells[2, 5].Value2.ToString());
        customerData.Add(xlRange.Cells[2, 6].Value2.ToString());
        customerData.Add(xlRange.Cells[2, 7].Value2.ToString());
        customerData.Add(xlRange.Cells[2, 8].Value2.ToString());
        customerData.Add(xlRange.Cells[2, 9].Value2.ToString());
        customerData.Add(xlRange.Cells[2, 10].Value2.ToString());
        customerData.Add(xlRange.Cells[2, 11].Value2.ToString());
        customerData.Add(xlRange.Cells[2, 12].Value2.ToString());
      
       return customerData;
    }

  }
}
