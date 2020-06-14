using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsJVM.wakeup.runtime
{
    public class Slot
    {
        private int var;
        private Object objectRef;

        public int Var { get => var; set => var = value; }
        public object ObjectRef { get => objectRef; set => objectRef = value; }
    }
}
