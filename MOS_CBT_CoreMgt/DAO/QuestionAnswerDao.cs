using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_CBT_CoreMgt.DAO
{
    public class QuestionAnswerDao
    {
        public static string ByQuestionsIds(string[] questionIds)
        {
            string s = "";
            for (int i = 0; i < questionIds.Length; i++)
            {
                if (i >= (questionIds.Length - 1))
                {
                    s = s + "'" + questionIds[i] + "'";
                }
                else
                {
                    s = s + "'" + questionIds[i] + "',";
                }
            }

            string query = "select question.id,questionOption.optionType,question.answer from question";
            query = query + " inner join questionOption on questionOption.question_Id = question.id";
            query = query + " where question.answer = (case questionOption.optionType when 'A' then 1 when 'B' THEN 2 when 'C' THEN 3 WHEN 'D' THEN '4' WHEN 'E' THEN 5 end)";
            query = query + $" and question.id in({s})";

            return query;
        }
    }
}
