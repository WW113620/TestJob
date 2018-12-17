using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class CSVFileHelper
    {
        #region Read Method
        public static void ReadCSVFile(string filePath, string datatime, string keyValue, ref DataTable dt)
        {
            if (!File.Exists(filePath))
                Console.WriteLine(" no exist:{0}", filePath);
            else
            {
                string filename = Path.GetFileNameWithoutExtension(filePath);
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                string strLine = "";
                string[] aryLine = null;
                bool IsFirst = true;
                int timeIndex = 0;
                int valueIndex = 0;
                while ((strLine = sr.ReadLine()) != null)
                {
                    if (IsFirst == true)//remove title
                    {
                        IsFirst = false;
                        var tableHead = strLine.Split(',');
                        for (int i = 0; i < tableHead.Length; i++)
                        {
                            if (datatime.Equals(tableHead[i]))//Date/Time
                                timeIndex = i;
                            if (keyValue.Equals(tableHead[i]))
                                valueIndex = i;
                        }
                    }
                    else
                    {
                        aryLine = strLine.Split(',');
                        DataRow dr = dt.NewRow();
                        dr[0] = filename;
                        dr[1] = aryLine[timeIndex].ToDateTime(DateTime.Now);  //convert date time
                        dr[2] = aryLine[valueIndex].ToDouble(0);
                        dr[3] = 0;
                        dt.Rows.Add(dr);
                    }
                }

                sr.Close();
                fs.Close();
            }
        }
        #endregion

        #region New DataTable
        public static DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn file = new DataColumn("filename", typeof(string));
            DataColumn time = new DataColumn("time", typeof(DateTime));
            DataColumn value = new DataColumn("value", typeof(double));
            DataColumn median = new DataColumn("median", typeof(double));
            dt.Columns.Add(file);
            dt.Columns.Add(time);
            dt.Columns.Add(value);
            dt.Columns.Add(median);
            return dt;
        }
        #endregion

    }
}
