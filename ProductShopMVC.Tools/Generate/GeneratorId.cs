using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopMVC.Tools.Generate
{
    public static class GeneratorId
    {
        public static string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
