using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsJVM.wakeup.config;
using CsJVM.wakeup.execution;
using CsJVM.wakeup.instruction;

namespace CsJVM.wakeup
{
    public class JVM
    {
        public void StartJVM(ConsoleParam param)
        {
            //初始化指令集
            Instruction.InitialInstructions();
            Entry classPath = new ClassPath(param.JdkPath, param.Path);

            byte[] classData = classPath.ReadClass(param.ClassName);
            if (Switchs.DebugParse)
            {
                Console.Write(BitConverter.ToString(classData));
            }
            Console.WriteLine();
            ClassFile classFile = ClassReader.Read(classData);
            Interpreter interpreter = new Interpreter();
            interpreter.interpret(classFile.Methods[1]);
            

            Console.Write("finished with exit code 0");
        }
    }
}
