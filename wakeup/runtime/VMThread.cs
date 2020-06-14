using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsJVM.wakeup.runtime
{
    public class VMThread
    {
        private uint pc;
        private VMStack stack = new VMStack();

        public Frame CreateFrame(ushort maxLocals, ushort maxStack)
        {
            return new Frame(maxLocals, maxStack);
        }


        public void Push(Frame frame)
        {
            stack.Push(frame);
        }


        public uint Pc { get => pc; set => pc = value; }
        public VMStack Stack { get => stack; set => stack = value; }
    }
}
