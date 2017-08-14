using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_CBT_CoreMgt.Models
{
    public class Result
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string username { get; set; }
        public string dateCreated { get; set; }
        public int score { get; set; }
    }
}
