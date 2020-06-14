using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsJVM.wakeup.common;

namespace CsJVM.wakeup.runtime
{
    public class OperandStack
    {
        private uint top = 0;
        private StackData<Slot> stack = new StackData<Slot>();
        private ushort maxStack;


        public OperandStack() { }

        public OperandStack(ushort maxStack)
        {
            this.maxStack = maxStack;
            this.stack = new StackData<Slot>();
        }

        public void PushObjectRef(Object objectRef)
        {
            Slot slot = new Slot();
            slot.ObjectRef = objectRef;
            Push(slot);
        }

        public Object PopObjectRef()
        {
            return Pop().ObjectRef;
        }

        public void PushInt(int value)
        {
            Slot slot = new Slot();
            slot.Var = value;
            Push(slot);
        }


        public int PopInt()
        {
            return Pop().Var;
        }




        private void Push(Slot slot)
        {
            if(stack.Size >= maxStack)
            {
                throw new Exception("OperandStack overflow");
            }
            stack.Push(slot);
        }

        private Slot Pop()
        {
            if(stack.Size <= 0)
            {
                throw new Exception("OperandStack empty error");
            }
            return stack.Pop();
        }
    }
}
