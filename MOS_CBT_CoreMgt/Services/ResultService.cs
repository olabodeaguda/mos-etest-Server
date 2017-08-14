using MOS_CBT_CoreMgt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOS_CBT_CoreMgt.Models;
using Microsoft.EntityFrameworkCore;
using MOS_CBT_CoreMgt.DAO;

namespace MOS_CBT_CoreMgt.Services
{
    public class ResultService : AbstractService, IResult
    {
        public ResultService(CbtCoreContext context) : base(context)
        {

        }

        public async Task<bool> add(Result result)
        {
            try
            {
                result.dateCreated = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

                int tk = await this._context.Database.ExecuteSqlCommandAsync(ResultDao.InsertQuery(result));

                if (tk > 0)
                {
                    return true;
                }
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }

            return false;
        }

        public async Task<List<Result>> all()
        {
            return await this._context.Results.ToListAsync();
        }
    }
}
