using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopMVC.Tools.Conversion.ConverseDate
{
    public static class ConverseDateFromView
    {
        private static void parseComeDataString(string dateString, out int year, out int month, out int day)
        {
            string[] splitDataString = dateString.Split(new char[] { '-' });
            year = Int32.Parse(splitDataString[0]);
            month = Int32.Parse(splitDataString[1]);
            day = Int32.Parse(splitDataString[2]);
        }

        public static DateTime DateStringToDateTime(string dateStringFromView)
        {
            parseComeDataString(dateStringFromView, out int year, out int month, out int day);
            return new DateTime(year, month, day);
        }
    }
}
