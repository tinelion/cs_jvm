using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsJVM.wakeup.common;

namespace CsJVM.wakeup.runtime
{
    public class VMStack
    {
        private uint maxSize = 1024;
        private StackData<Frame> stack = new StackData<Frame>();


        public void Push(Frame frame)
        {
            if (stack.Size >= maxSize)
            {
                throw new Exception("VMStack overflow");
            }
            stack.Push(frame);
        }

        public Frame Pop()
        {
            if(stack.Size <= 0)
            {
                throw new Exception("Stack empty error");
            }
            return stack.Pop();
        }

        public uint MaxSize { get => maxSize; set => maxSize = value; }
    }
}
