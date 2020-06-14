using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsJVM.wakeup
{
    interface Entry
    {
        byte[] ReadClass(string className);

        void SetClassPath(string classPath);
    }
}
