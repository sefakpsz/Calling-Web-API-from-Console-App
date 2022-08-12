using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DataResult
    {
        public List<Bank> data { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
    }
}