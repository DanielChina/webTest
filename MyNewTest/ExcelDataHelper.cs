using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
namespace MyNewTest
{
    class ExcelDataHelper
    {
        private static System.Data.DataTable ExcelToDataTable(string fileName)
        {
            //open file and returns as Stream
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            //Createopenxmlreader via ExcelReaderFactory
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream); //.xlsx                                                                          //Set the First Row as Column Name
         //   excelReader.IsFirstRowAsColumnNames = true;
            //Return as DataSet
            DataSet result = excelReader.AsDataSet();
            //Get all the Tables
            DataTableCollection table = result.Tables;
            //Store it in DataTable
            System.Data.DataTable resultTable = table["Sheet1"];
            stream.Close();
            //return
            return resultTable;
        }
        static List<Datacollection> dataCol = new List<Datacollection>();
        public static void PopulateInCollection(string fileName)
        {
            System.Data.DataTable table = ExcelToDataTable(fileName);
            
            //Iterate through the rows and columns of the Table
            for (int row = 1; row < table.Rows.Count; row++)
            {
                for (int col = 0; col <table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Rows[0][col].ToString(),
                        colValue = table.Rows[row][col].ToString()
                    };
                    //Add all the details for each row
                    dataCol.Add(dtTable);
                }
            }
        }
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static void WriteData(string filename, int rowNum, int columnNum, string value)
        {
            Application excel = new _Excel.Application();
            Workbook wb;
            Worksheet ws;
            wb = excel.Workbooks.Open(filename);

            try
            {
                ws= wb.Worksheets[1];
                ws.Cells[columnNum][rowNum].Value2 = value;
            }
            catch (Exception e)
            {
                wb.Close();
                return;
            }
            
            wb.Save();
            wb.Close();
            
        }
    }
    public class Datacollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }
   
}
