using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public static class ConvertHelper
    {
        public static int ToInt(this object data, int RtnData)
        {
            int rtnData = 0;
            try
            {
                rtnData = Convert.ToInt32(data);
            }
            catch
            {
                rtnData = RtnData;
            }
            return rtnData;
        }

        public static long ToLong(this object data, long RtnData)
        {
            long rtnData = 0;
            try
            {
                if (data != null)
                    rtnData = Convert.ToInt64(data);
            }
            catch
            {
                rtnData = RtnData;
            }
            return rtnData;
        }

        public static double ToDouble(this object data, double RtnData)
        {
            double rtnData = 0;
            try
            {
                if (data != null)
                    rtnData = Convert.ToDouble(data);
            }
            catch
            {
                rtnData = RtnData;
            }
            return rtnData;
        }

        public static string ToString(this object data, string RtnData)
        {
            string rtnData = "";
            try
            {
                if (data != null && data.ToString() != "")
                    rtnData = Convert.ToString(data);
            }
            catch
            {
                rtnData = RtnData;
            }
            return rtnData;
        }


        public static DateTime ToDateTime(this object data, DateTime RtnData)
        {
            DateTime rtnData = RtnData;
            try
            {
                if (data != null && data.ToString() != "" && Convert.ToDateTime(data) != DateTime.MinValue)
                    rtnData = Convert.ToDateTime(data);
            }
            catch
            {
            }
            return rtnData;
        }

    }
}
