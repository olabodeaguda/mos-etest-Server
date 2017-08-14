using MOS_CBT_CoreMgt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_CBT_CoreMgt.Services.Interfaces
{
    public interface IQuestionAnswer
    {
        Task<Response> ComputeResult(SubmitAnswerModel subAnswer);
    }
}
