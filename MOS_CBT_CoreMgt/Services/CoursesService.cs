using MOS_CBT_CoreMgt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOS_CBT_CoreMgt.Models;

namespace MOS_CBT_CoreMgt.Services
{
    public class CoursesService : ICourse
    {
        private readonly CbtCoreContext _context;
        public CoursesService(CbtCoreContext context)
        {
            this._context = context;
        }

        public List<Course> GetAll()
        {
            var t = this._context.Course.ToList();
            return t;
        }
    }
}
