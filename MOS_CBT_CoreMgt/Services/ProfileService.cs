using MOS_CBT_CoreMgt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOS_CBT_CoreMgt.Models;
using Microsoft.EntityFrameworkCore;
using MOS_CBT_CoreMgt.DAO;
using Microsoft.Data.Sqlite;
using MOS_CBT_CoreMgt.Utilities;

namespace MOS_CBT_CoreMgt.Services
{
    public class ProfileService : AbstractService, IProfile
    {
        public ProfileService(CbtCoreContext _db) : base(_db)
        {
        }

        public async Task<bool> Add(Profile profile)
        {
            try
            {
                profile.dateCreated = DateTime.Now.ToString("dd-MM-yyyy");
                profile.status = ProfileStatus.ACTIVE.ToString();
                int tk = await this._context.Database.ExecuteSqlCommandAsync(ProfileDao.InsertQuery(profile));

                if (tk > 0)
                {
                    return true;
                }
            }
            catch (SqliteException x)
            {
                if (x.SqliteErrorCode == 19)
                {
                    throw new Exception("User Name already exist");
                }
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }

            return false;
        }

        public async Task<List<Profile>> All()
        {
            return await this._context.Profile.ToListAsync();
        }

        public async Task<Profile> ByUsername(string username)
        {
            return await this._context.Profile.FirstOrDefaultAsync(x => x.username == username);
        }

        public async Task<bool> changePwd(Profile profile)
        {
            try
            {
                int tk = await this._context.Database.ExecuteSqlCommandAsync(ProfileDao.ChangePwd(profile.id, profile.pwd));

                if (tk > 0)
                {
                    return true;
                }
            }
            catch (SqliteException x)
            {
                if (x.SqliteErrorCode == 19)
                {
                    throw new Exception("User Name already exist");
                }
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }

            return false;
        }

        public async Task<bool> ChangeStatus(Profile profile)
        {
            try
            {
                int tk = await this._context.Database.ExecuteSqlCommandAsync(ProfileDao.UpdateStatus(profile.id, profile.status));

                if (tk > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }

        public async Task<bool> Update(Profile profile)
        {
            try
            {
                int tk = await this._context.Database.ExecuteSqlCommandAsync(ProfileDao.UpdateQuery(profile));

                if (tk > 0)
                {
                    return true;
                }
            }
            catch (SqliteException x)
            {
                if (x.SqliteErrorCode == 19)
                {
                    throw new Exception("User Name already exist");
                }
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }

            return false;
        }
    }
}
