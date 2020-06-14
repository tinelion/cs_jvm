using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CsJVM.wakeup;
using CsJVM.wakeup.config;

namespace CsJVM
{
    class Program
    {
        static void Main(string[] args)
        {
            //调试解析过程开关
            Switchs.DebugParse = false;
            //调试解释执行过程
            Switchs.DebugInterpret = true;
            ConsoleParam param = ReadParam.Read();
            JVM jvm = new JVM();
            jvm.StartJVM(param);

            Console.Read();
        }


        public static void test()
        {
            byte[] bytes = new byte[8];
            bytes[3] = 0xCA;
            bytes[2] = 0xFE;
            bytes[1] = 0xBA;
            bytes[0] = 0xBE;
            bytes[4] = 0x00;
            bytes[5] = 0x00;
            bytes[7] = 0x00;
            bytes[6] = 0x10;
            //byte test = BitConverter.GetBytes();

            Console.Out.WriteLine(BitConverter.ToString(bytes));
            Console.Out.WriteLine(BitConverter.ToUInt32(bytes, 0));
            Thread.Sleep(4000);
        }
    }
}
