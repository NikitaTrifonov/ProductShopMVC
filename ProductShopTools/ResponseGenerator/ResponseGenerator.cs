using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopTools.ResponseGenerator
{
    class ResponseGenerator<T>
    {
        public String Error { get; set; }
        public Boolean IsSuccess { get { return String.IsNullOrWhiteSpace(Error); } }
        public T Data { get; set; }

        public ResponseGenerator(T data, String error = "") { }
    }
}
