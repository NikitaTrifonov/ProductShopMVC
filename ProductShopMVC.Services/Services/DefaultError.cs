using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopMVC.Services.Services
{
    public class DefaultError
    {
        public string errorMessage { get; set; }
        public DefaultError(string error)
        {
            errorMessage = error;
        }

        public DefaultError(){}
    }
}
