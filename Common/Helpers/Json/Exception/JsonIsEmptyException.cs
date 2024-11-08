using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper.Json
{
    public class JsonIsEmptyException : Exception
    {
        public JsonIsEmptyException() : base("json is empty!")
        {

        }
    }
}