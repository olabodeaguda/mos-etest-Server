using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_CBT_CoreMgt.Utilities
{
    public class HTTPStatusCode
    {
        public const string SUCCESS = "00";
        public const string FAILED = "01";
        public const string NOT_FOUND = "02";
        public const string BAD_CREDENTIALS = "03";
        public static string BAD_REQUEST = "04";
    }
}
