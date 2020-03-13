using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ProductShopMVC.Tools.Check
{
    public static class CheckData
    {

        private static string phoneNumberPattern = @"\+[7]{1}?\(?\d{3}\)?\d{3}-\d{2}-\d{2}";
        private static string emailPattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";


        public static bool checkPhoneNumber(string inPhoneNumber)
        {
            if (Regex.IsMatch(inPhoneNumber, phoneNumberPattern))
            {
                return true;
            }
            return false;
        }
        public static bool checkEmail(string inEmail)
        {
            if (Regex.IsMatch(inEmail, emailPattern))
            {
                return true;
            }
            return false;
        }
    }
}
