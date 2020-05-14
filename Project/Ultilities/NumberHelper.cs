using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Ultilities
{
    public class NumberHelper
    {
        public static int getInt(String strNumber)
        {
            int num = -1;
            try
            {
                num = int.Parse(strNumber);
            }
            catch
            {
                num = -1;
            }
            return num;
        }
    }
}