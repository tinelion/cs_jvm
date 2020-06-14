using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsJVM.wakeup.runtime
{
    public class LocalVarsTable
    {
        private Slot[] localVars;


        public LocalVarsTable() { }

        public LocalVarsTable(ushort maxLocalVars)
        {
            this.localVars = new Slot[maxLocalVars];
        }


        public Slot Get(uint index)
        {
            return localVars[index];
        }

        public void PutInt(uint index, int value)
        {
            Slot slot = new Slot();
            slot.Var = value;
            localVars[index] = slot;
        }

        public Slot[] LocalVars { get => localVars; set => localVars = value; }
    }
}
