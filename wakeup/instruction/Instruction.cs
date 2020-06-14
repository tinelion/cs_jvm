using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CsJVM.wakeup.config;
using CsJVM.wakeup.execution;
using CsJVM.wakeup.runtime;

namespace CsJVM.wakeup.instruction
{

    public abstract class Instruction
    {
        protected static Instruction[] instructions = new Instruction[255];


        /// <summary>
        /// 构造方法，用于把指令注册到Instruction[]数组
        /// </summary>
        /// <param name="index"></param>
        protected Instruction(byte index)
        {
            instructions[index] = this;
        }

        /// <summary>
        /// 指令集初始化，使用反射创建所有指令，存入Instruction[]数组
        /// </summary>
        public static void InitialInstructions()
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type[] typeArr = assembly.GetTypes();

            foreach (Type type in typeArr)
            {

                if (type.BaseType != null && type.BaseType.Name == "Instruction")
                {
                    //指令的构造方法会把自己放入Instruction[]
                    System.Activator.CreateInstance(type);
                }
            }
        }

        /// <summary>
        /// 获取具体指令
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Instruction GetInstruction(byte code)
        {
            return instructions[code];
        }

        /// <summary>
        /// 执行指令
        /// </summary>
        /// <param name="thread"></param>
        /// <param name="frame"></param>
        public abstract void Execute(VMThread thread, byte[] byteCode, Frame frame);

        /// <summary>
        /// 读取操作数
        /// </summary>
        /// <param name="byteCode"></param>
        /// <returns></returns>
        public virtual byte[] FetchOperands(VMThread thread, byte[] byteCode)
        {
            return new byte[0];
        }
    }


    public class Nop : Instruction
    {
        /// <summary>
        /// 构造方法调用父类构造：base(...)
        /// </summary>
        public Nop() : base(InstructionSet.nop) { }
        public override void Execute(VMThread thread, byte[] byteCode, Frame frame) { }
    }

    public class AConstNull : Instruction
    {
        public AConstNull() : base(InstructionSet.aconst_null) { }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            OperandStack operandStack = frame.OperandStack;
            operandStack.PushObjectRef(null);
        }
    }


    public class ILoad : Instruction
    {
        public ILoad() : base(InstructionSet.iload) { }
        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {

        }
    }

    /// <summary>
    /// ILoad_1/ILoad_2....的Execute()会压缩到一行，逻辑和ILoad_0的一样
    /// </summary>
    public class ILoad_0 : Instruction
    {
        public ILoad_0() : base(InstructionSet.iload_0) { }
        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            //操作数栈
            OperandStack operandStack = frame.OperandStack;
            //局部变量表
            LocalVarsTable localVarsTable = frame.LocalVars;
            //取局部变量
            Slot value = localVarsTable.Get(0);
            //入操作数栈
            operandStack.PushInt(value.Var);
        }
    }

    /// <summary>
    /// 参考ILoad_0的写法
    /// </summary>
    public class ILoad_1 : Instruction
    {
        public ILoad_1() : base(InstructionSet.iload_1) { }
        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            frame.OperandStack.PushInt(frame.LocalVars.Get(1).Var);
        }
    }
    /// <summary>
    /// 参考ILoad_0的写法
    /// </summary>
    public class ILoad_2 : Instruction
    {
        public ILoad_2() : base(InstructionSet.iload_2) { }
        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            frame.OperandStack.PushInt(frame.LocalVars.Get(2).Var);
        }
    }
    /// <summary>
    /// 参考ILoad_0的写法
    /// </summary>
    public class ILoad_3 : Instruction
    {
        public ILoad_3() : base(InstructionSet.iload_3) { }
        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            frame.OperandStack.PushInt(frame.LocalVars.Get(3).Var);
        }
    }

    /// <summary>
    /// 从操作数栈取数据存入局部变量表
    /// </summary>
    public class IStore_0 : Instruction
    {
        public IStore_0() : base(InstructionSet.istore_0) { }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            //操作数栈
            OperandStack operandStack = frame.OperandStack;
            //局部变量表
            LocalVarsTable localVarsTable = frame.LocalVars;
            //弹出操作数栈顶元素
            int val = operandStack.PopInt();
            //存入局部变量表0号位置
            localVarsTable.PutInt(0, val);
        }
    }

    /// <summary>
    /// 参考IStore_0写法
    /// </summary>
    public class IStore_1 : Instruction
    {
        public IStore_1() : base(InstructionSet.istore_1) { }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            frame.LocalVars.PutInt(1, frame.OperandStack.PopInt());
        }
    }
    /// <summary>
    /// 参考IStore_0写法
    /// </summary>
    public class IStore_2 : Instruction
    {
        public IStore_2() : base(InstructionSet.istore_2) { }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            frame.LocalVars.PutInt(2, frame.OperandStack.PopInt());
        }
    }
    /// <summary>
    /// 参考IStore_0写法
    /// </summary>
    public class IStore_3 : Instruction
    {
        public IStore_3() : base(InstructionSet.istore_3) { }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            frame.LocalVars.PutInt(3, frame.OperandStack.PopInt());
        }
    }


    public class IConst_0 : Instruction
    {
        public IConst_0() : base(InstructionSet.iconst_0)
        {
        }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            //操作数栈
            OperandStack operandStack = frame.OperandStack;
            //操作数栈顶存入0
            operandStack.PushInt(0);
        }
    }

    public class IConst_1 : Instruction
    {
        public IConst_1() : base(InstructionSet.iconst_1)
        {
        }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            frame.OperandStack.PushInt(1);
        }
    }
    public class IConst_2 : Instruction
    {
        public IConst_2() : base(InstructionSet.iconst_2)
        {
        }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            frame.OperandStack.PushInt(2);
        }
    }
    public class IConst_3 : Instruction
    {
        public IConst_3() : base(InstructionSet.iconst_3)
        {
        }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            frame.OperandStack.PushInt(3);
        }
    }


    public class SiPush : Instruction
    {
        public SiPush() : base(InstructionSet.sipush)
        {
        }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            byte[] bytes = this.FetchOperands(thread, byteCode);
            int val = (bytes[0] << 8) | bytes[1];
            frame.OperandStack.PushInt(val);
        }

        public override byte[] FetchOperands(VMThread thread, byte[] byteCode)
        {
            return ByteCodeReader.ReadBytes(thread, byteCode, 2);
        }
    }

    public class IAdd : Instruction
    {
        public IAdd() : base(InstructionSet.iadd)
        {
        }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            int value2 = frame.OperandStack.PopInt();
            int value1 = frame.OperandStack.PopInt();
            frame.OperandStack.PushInt(value1 + value2);
        }
    }

    public class ISub : Instruction
    {
        public ISub() : base(InstructionSet.isub)
        {
        }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            int value2 = frame.OperandStack.PopInt();
            int value1 = frame.OperandStack.PopInt();
            frame.OperandStack.PushInt(value1 - value2);
        }
    }

    public class IMult : Instruction
    {
        public IMult() : base(InstructionSet.imul)
        {
        }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            int value2 = frame.OperandStack.PopInt();
            int value1 = frame.OperandStack.PopInt();
            frame.OperandStack.PushInt(value1 * value2);
        }
    }

    public class IDiv : Instruction
    {
        public IDiv() : base(InstructionSet.idiv)
        {
        }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            int value2 = frame.OperandStack.PopInt();
            int value1 = frame.OperandStack.PopInt();
            if(value2 == 0)
            {
                throw new Exception("Div by zero exception");
            }
            frame.OperandStack.PushInt(value1 / value2);
        }
    }


    public class ALoad_0 : Instruction
    {
        public ALoad_0() : base(InstructionSet.aload_0)
        {
        }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            //操作数栈
            OperandStack operandStack = frame.OperandStack;
            //局部变量表
            LocalVarsTable localVarsTable = frame.LocalVars;
            //取局部变量
            Slot value = localVarsTable.Get(0);
            //入操作数栈
            operandStack.PushObjectRef(value.ObjectRef);
        }
    }

    public class ALoad_1 : Instruction
    {
        public ALoad_1() : base(InstructionSet.aload_1)
        {
        }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            frame.OperandStack.PushObjectRef(frame.LocalVars.Get(1).ObjectRef);
        }
    }

    public class ALoad_2 : Instruction
    {
        public ALoad_2() : base(InstructionSet.aload_2)
        {
        }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            frame.OperandStack.PushObjectRef(frame.LocalVars.Get(1).ObjectRef);
        }
    }

    public class ALoad_3 : Instruction
    {
        public ALoad_3() : base(InstructionSet.aload_3)
        {
        }

        public override void Execute(VMThread thread, byte[] byteCode, Frame frame)
        {
            frame.OperandStack.PushObjectRef(frame.LocalVars.Get(1).ObjectRef);
        }
    }
}
