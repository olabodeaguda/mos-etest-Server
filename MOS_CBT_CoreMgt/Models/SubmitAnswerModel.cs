using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_CBT_CoreMgt.Models
{
    public class SubmitAnswerModel
    {
        public string username { get; set; }
        public string dateCreated { get; set; }
        public string submisionDate { get; set; }
        public AnswerModel[] answers { get; set; }
        public int userId { get; set; }

    }
}
