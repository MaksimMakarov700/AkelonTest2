using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkelonTest2
{
    class ExcelParser
    {
        public List<T> ReadTable<T>(IXLWorksheet worksheet) where T : ITable, new()
        {
            List<T> list = new List<T>();
            List<string> row = new List<string>();
            string s = string.Empty;
            int j;
            for (int i = 2; i <= worksheet.Rows().Count(); i++)
            {
                row.Clear();
                j = 1;
                do
                {
                    s = worksheet.Cell(i, j).Value.ToString();
                    if (!String.IsNullOrWhiteSpace(s))
                        row.Add(s);
                    else break;
                    j++;
                }
                while (true);
                if (row.Count == 0) break;

                T t = new T();
                t.ParseRow(row);
                list.Add(t);
            }
            return list;
        }

    }
}
