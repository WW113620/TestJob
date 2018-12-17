using Application.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ReadCSVFile
{
    class Program
    {

        private static string printType = System.Configuration.ConfigurationManager.AppSettings["printType"];
        static void Main(string[] args)
        {
            try
            {
                //0->TOU   1->LP
                int type = printType.ToInt(0);
                PrintMedian(type);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        #region Print
        private static void PrintMedian(int type = 0)
        {
            DataTable dt = new DataTable();
            if (type == 1)
                dt = Calculate.LPMedianDataTable();
            else
                dt = Calculate.TOUMedianDataTable();

            int len = dt.Rows.Count;
            if (dt != null && len > 0)
            {
                double medValue = 0;
                dt.DefaultView.Sort = "value asc"; // order asc 
                dt = dt.DefaultView.ToTable();
                
                if (len % 2 == 0)
                {
                    int median = len / 2;
                    //will calculate the median value
                    medValue = (dt.Rows[median]["value"].ToDouble(0) + dt.Rows[median + 1]["value"].ToDouble(0)) / 2;
                    Console.WriteLine("\n the median value ：{0} \n\n", medValue);
                }
                else
                {
                    int median = len / 2 + 1;
                    //dt.Rows[median][2] is the median value
                    medValue = dt.Rows[median][2].ToDouble(0);
                    Console.WriteLine("\n the median value ：{0} \n\n", dt.Rows[median][2]);
                }

                Console.Write("file name\t\t\t\t datetime\t\t\t value \t\t median value \t\n");
                // print data ,should confirm how to print data format 
                double minValue = medValue * (1 - 0.2);
                double maxValue = medValue * (1 + 0.2);
                for (int i = 0; i < len; i++)
                {
                    double midValue = dt.Rows[i][2].ToDouble(0);
                    if (midValue > minValue && midValue < maxValue)
                        Console.Write("{0}\t\t {1}\t\t {2}\t\t {3}\t\n", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], medValue);
                }
                dt.Clear(); //datatable empty
            }
        }
        #endregion



    }
}
