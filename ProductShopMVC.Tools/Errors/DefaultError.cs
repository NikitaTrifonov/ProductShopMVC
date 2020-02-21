using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopMVC.Tools.Errors
{
    public class DefaultError
    {
        public string ErrorMessage { get; set; }
        public DefaultError(string error)
        {
            ErrorMessage = error;
        }

        public DefaultError(){}
    }
}
