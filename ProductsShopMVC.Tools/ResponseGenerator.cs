using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShopMVC.Tools
{
    public class ResponseGenerator<T>

    {
        public String Error { get; set; }
        public Boolean IsSuccess { get { return String.IsNullOrWhiteSpace(Error); } }
        public T Data { get; set; }

        public ResponseGenerator(T data, String error = "") { }
    }
}


