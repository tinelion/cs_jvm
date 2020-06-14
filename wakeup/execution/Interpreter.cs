using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsJVM.wakeup.classfile;
using CsJVM.wakeup.config;
using CsJVM.wakeup.instruction;
using CsJVM.wakeup.runtime;

namespace CsJVM.wakeup.execution
{
    /// <summary>
    /// 解释器，用于解释执行
    /// </summary>
    public class Interpreter
    {

        /// <summary>
        /// 解释执行1个方法
        /// </summary>
        /// <param name="methodInfo"></param>
        public void interpret(MemberInfo methodInfo)
        {
            Code code = GetCode(methodInfo);
            ushort maxStack = code.MaxStack;
            ushort maxLocals = code.MaxLocals;
            byte[] byteCode = code.CodeData;
            VMThread thread = new VMThread();
            thread.Pc = 0;
            Frame frame = thread.CreateFrame(maxLocals, maxStack);
            thread.Push(frame);

            while (true)
            {
                byte operateCode = ByteCodeReader.ReadOperateCode(thread, byteCode);
                Instruction instruction = Instruction.GetInstruction(operateCode);
                if(instruction == null)
                {
                    if (Switchs.DebugInterpret)
                    {
                        Console.Out.WriteLine("缺少指令：" + BitConverter.ToString(new byte[] { operateCode }));
                    }
                    throw new Exception("No shuch instruction error");
                }
                instruction.Execute(thread, byteCode, frame);
            }
        }


        private Code GetCode(MemberInfo methodInfo)
        {
            Code code = methodInfo.CodeAttribute();
            if (code == null)
            {
                throw new Exception("No code exception");
            }
            return code;
        }
    }
}
