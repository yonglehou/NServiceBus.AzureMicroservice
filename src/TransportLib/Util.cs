using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBrad.TransportLib
{
    internal class Util
    {
        public static readonly Task<bool> TaskFalse = Task.FromResult<bool>(false);
        public static readonly Task<bool> TaskTrue = Task.FromResult<bool>(true);
        public static Task TaskCompleted { get { return Util.TaskTrue; } }
    }
}
