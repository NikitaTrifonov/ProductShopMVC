using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopMVC.Tools.Response
{
    public class ResultHandler<T>
    {
        public String Error { get; set; }
        public Boolean IsSuccess { get { return String.IsNullOrWhiteSpace(Error); } }
        public T Data { get; set; }

        public ResultHandler(T data, String error = "")
        {
            Data = data;
            Error = error;
        }
        public ResultHandler()
        {
        }
        public ResultHandler(String error = "")
        {
            Error = error;
        }

    }
}
