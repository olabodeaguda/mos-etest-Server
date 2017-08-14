using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_CBT_CoreMgt.Models
{
    public class Course
    {
        public int id { get; set; }
        public int programId { get; set; }
        public string courseName { get; set; }
        public string courseCode { get; set; }
    }
}
