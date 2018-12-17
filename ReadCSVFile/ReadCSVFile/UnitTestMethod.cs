using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCSVFile
{
    public class UnitTestMethod
    {
        public static bool TestLPMedianDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable= Calculate.LPMedianDataTable();
            if (dataTable != null && dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static int TestTOUMedianDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable = Calculate.LPMedianDataTable();
            if (dataTable != null && dataTable.Rows.Count > 0)
                return dataTable.Rows.Count;
            else
                return -1;
        }

    }
}
