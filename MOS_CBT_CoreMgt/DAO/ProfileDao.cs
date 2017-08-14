using MOS_CBT_CoreMgt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_CBT_CoreMgt.DAO
{
    public class ProfileDao
    {
        public static string InsertQuery(Profile profile)
        {
            string values = $"'{profile.username}','{profile.firstname}','{profile.lastname}','{profile.surname}','{profile.dateCreated}','{profile.status}','{profile.pwd}'";

            return $"insert into Profile(username,firstname,lastname,surname,dateCreated,status,pwd) values({values})";
        }

        public static string UpdateStatus(int id,string status)
        {
            return $"update Profile set status = '{status}' where id = {id}";
        }

        public static string ChangePwd(int id, string pwd)
        {
            return $"update Profile set pwd = '{pwd}' where id = {id}";
        }

        public static string UpdateQuery(Profile profile)
        {
            return $"update Profile set firstname='{profile.firstname}',lastname='{profile.lastname}',surname='{profile.surname}'  where id={profile.id}";
        }
    }
}
