using MOS_CBT_CoreMgt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_CBT_CoreMgt.Services.Interfaces
{
    public interface IProfile
    {
        Task<List<Profile>> All();
        Task<Profile> ByUsername(string username);
        Task<bool> Add(Profile profile);
        Task<bool> ChangeStatus(Profile profile);
        Task<bool> Update(Profile profile);
        Task<bool> changePwd(Profile profile);
    }
}
