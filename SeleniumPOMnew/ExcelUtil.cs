using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader.Core;
using Microsoft.Xrm.Sdk;
using ExcelDataReader;
using System.Collections;

namespace SeleniumPOMnew
{
    /// <summary>
    /// New Generic class of type DataCollection. 
    /// </summary>
    public class Datacollection
    {
        public int RowNumber { get; set; }
        public string ColName { get; set; }
        public string ColValue { get; set; }
    }

    internal class ExcelUtil
    {
        // List of type DataCollection. 
        public static List<Datacollection> dataCol = new List<Datacollection>();


        /// <summary>
        /// Another method using LINQ methods to read data from Excel file and store as List of DataCollection items. 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        public static void ExceltoInternal(string fileName, string sheetName)
        {
            using (var _stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var _dataReader = ExcelReaderFactory.CreateReader(_stream))
                {
                    var _excelData = _dataReader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    //Get all the Tables
                    DataTableCollection _tables = _excelData.Tables;

                    //Store it in DataTable
                    DataTable _table = _tables[sheetName];

                    // Iterate through rows of the table. 
                    for (int row = 1; row <= _table.Rows.Count; row++)
                    {
                        // Iterate through columens of the iterating row. 
                        for (int col = 0; col < _table.Columns.Count; col++)
                        {
                            // creating a collection for the current iterating row 
                            Datacollection dtTable = new Datacollection()
                            {
                                RowNumber = row,
                                ColName = _table.Columns[col].ColumnName,
                                ColValue = _table.Rows[row - 1][col].ToString()
                            };

                            // Adding created collection item into List of DataCollection type 
                            dataCol.Add(dtTable);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Read data from the list of Datacollection items 
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="colName"></param>
        /// <returns></returns>
        public static string ReadData(int rowNumber, string colName)
        {
            try
            {
                // returning the value of the entered row number and column name. 
                var data = dataCol.Where(x => x.ColName == colName && x.RowNumber == rowNumber).SingleOrDefault().ColValue;
                return data.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}
