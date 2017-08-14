using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MOS_CBT_CoreMgt.Services
{
    public abstract class AbstractService
    {
        public readonly CbtCoreContext _context;
        public AbstractService(CbtCoreContext context)
        {
            this._context = context;
        }
        
        public CancellationTokenSource CancelToken
        {
            get
            {
                return new CancellationTokenSource();
            }
        }
    }
}
