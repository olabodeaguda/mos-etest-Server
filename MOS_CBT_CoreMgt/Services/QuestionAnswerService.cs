using MOS_CBT_CoreMgt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOS_CBT_CoreMgt.Models;
using Microsoft.EntityFrameworkCore;
using MOS_CBT_CoreMgt.DAO;
using MOS_CBT_CoreMgt.Utilities;

namespace MOS_CBT_CoreMgt.Services
{
    public class QuestionAnswerService : AbstractService, IQuestionAnswer
    {
        public QuestionAnswerService(CbtCoreContext _db) : base(_db)
        {
        }

        public async Task<Response> ComputeResult(SubmitAnswerModel subAnswer)
        {
            try
            {
                List<AnswerModel> s = await Task.Run(() =>
                {
                    return this._context.AnswerModels.FromSql(QuestionAnswerDao.ByQuestionsIds(subAnswer.answers.Select(x => x.id).ToArray())).ToList();
                });

                if (s.Count <= 0)
                {
                    throw new Exception("Question does not exist");
                }

                return await Task.Run(() =>
                {
                    int count = 0;
                    foreach (var tm in subAnswer.answers)
                    {
                        AnswerModel answer = s.FirstOrDefault(x => x.id == tm.id);
                        //if (answer == null)
                        //{
                        //    count++;
                        //    continue;
                        //}
                        if (tm.answer == answer.answer)
                        {
                            count++;
                        }
                        else if (tm.optionType == answer.optionType)
                        {
                            count++;
                        }
                    }

                    return new Response() { resultInt = count, code = HTTPStatusCode.SUCCESS, msg = "Computation was successfull" };

                });

            }
            catch (Exception x)
            {
                return new Response() { code = Utilities.HTTPStatusCode.BAD_REQUEST, msg = x.Message };
            }
        }
    }
}
