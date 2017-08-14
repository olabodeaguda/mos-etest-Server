using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_CBT_CoreMgt.Models
{
    public class Profile
    {
        public int id { get; set; }
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string dateCreated { get; set; }
        public string surname { get; set; }
        public string pwd { get; set; }
        public string status { get; set; }
        public int requiredAttempt { get; set; }
    }
}
