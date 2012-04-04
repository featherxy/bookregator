using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BookResearcher
{
    public class CsvRow : List<String>
    {
        #region Fields
        public string LineText { get; set; }
        #endregion

        public CsvRow() {}

        public CsvRow(IEnumerable<String> elements) : base(elements) {}
    }

    public class CsvTable : List<CsvRow>
    {
        public CsvTable() {}

        public CsvTable(IEnumerable<CsvRow> enumerable) : base(enumerable){}

        public CsvTable(CsvRow csvRow)
        {
            Add(csvRow);
        }
    }

    public class CsvFileWriter : StreamWriter
    {
        public CsvFileWriter(Stream stream) : base(stream){}

        public CsvFileWriter(string path) : base(path){}

        /// <summary>
        /// Writes a CsvRow to a .csv file in the correct format
        /// </summary>
        /// <param name="row">CsvRow to be written</param>
        /// <returns>Success of operation</returns>
        public bool Write(CsvRow row)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string value in row)
            {
                // Add separator if this isn't the first value
                if (builder.Length > 0)
                    builder.Append(',');

                
                //Early termination, shoud only happen if incorrect request or
                //Amazon serveroverload
                if (value == null)
                {
                    builder.Append("");
                    continue;
                }
                    
                if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
                {
                    // Special handling for values that contain comma or quote
                    // Enclose in quotes and double up any double quotes
                    builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
                }
                else builder.Append(value);
            }
            row.LineText = builder.ToString();
            WriteLine(row.LineText);
            return true;
        }

        /// <summary>
        /// Writes a CsvTable to a .csv file in the correct format
        /// </summary>
        /// <param name="row">CsvTable to be written</param>
        public void Write(CsvTable table)
        {
            foreach (CsvRow csvRow in table)
                Write(csvRow);
        }
    }
}
