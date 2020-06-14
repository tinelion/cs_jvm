using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsJVM.wakeup.runtime
{
    public class Frame
    {
        private Frame lower;
        private LocalVarsTable localVars;
        private OperandStack operandStack;

        public Frame(ushort maxLocals, ushort maxStack)
        {
            this.localVars = new LocalVarsTable(maxLocals);
            this.operandStack = new OperandStack(maxStack);
        }

        public Frame Lower { get => lower; set => lower = value; }
        public LocalVarsTable LocalVars { get => localVars; set => localVars = value; }
        public OperandStack OperandStack { get => operandStack; set => operandStack = value; }
    }
}
