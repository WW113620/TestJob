using Application.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCSVFile
{
    public class Calculate
    {
        private static string csvPath = System.Configuration.ConfigurationManager.AppSettings["csvfile"];

        #region Calculate

        //the "Data Value" column for the "LP" file type
        public static DataTable LPMedianDataTable()
        {
            DataTable dt = CSVFileHelper.CreateDataTable();
            DirectoryInfo dir = new DirectoryInfo(csvPath);
            var files = dir.GetFiles("LP_*.csv");
            foreach (var item in files)
                CSVFileHelper.ReadCSVFile(item.FullName, "Date/Time", "Data Value", ref dt);

            return dt;
        }

        //the "Energy" column for the "TOU" file type
        public static DataTable TOUMedianDataTable()
        {
            DataTable dt = CSVFileHelper.CreateDataTable();
            DirectoryInfo dir = new DirectoryInfo(csvPath);
            var files = dir.GetFiles("TOU_*.csv");
            foreach (var item in files)
                CSVFileHelper.ReadCSVFile(item.FullName, "Date/Time", "Energy", ref dt);

            return dt;
        }
        #endregion
    }
}
