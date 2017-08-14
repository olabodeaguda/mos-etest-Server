using MOS_CBT_CoreMgt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_CBT_CoreMgt.DAO
{
    public class ResultDao
    {
        public static string InsertQuery(Result rs)
        {
            string values = $"'{rs.username}','{rs.userId}','{rs.dateCreated}','{rs.score}'";

            return $"insert into results(username,userId,dateCreated,score) values({values})";
        }
    }
}
