using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopMVC.Tools.Response
{
    public class Result<T>
    {
        public String Error { get; set; }
        public Boolean IsSuccess { get { return String.IsNullOrWhiteSpace(Error); } }
        public T Data { get; set; }
        
        public Result(T data, String error = "")
        {
            Data = data;
            Error = error;
        }
        public Result()
        {

        }
    }
}
