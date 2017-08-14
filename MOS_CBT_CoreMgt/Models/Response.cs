using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_CBT_CoreMgt.Models
{
    public class Response
    {
        public string code { get; set; }
        public string msg { get; set; }
        public int resultInt { get; set; }
        public object data { get; set; }
    }
}
