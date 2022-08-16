using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallingWebAPIViaHttpClient
{
    public class DataResult
    {
        public List<Bank> data { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }
}