using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsJVM.wakeup
{
    class ReadParam
    {
        public static ConsoleParam Read()
        {
            Console.Out.Write("CsJVM: ");

            //string param = Console.ReadLine();
            //string[] paramArray = param.Split(' ');
            //while (paramArray.Length != 3)
            //{
            //    Console.Out.WriteLine("IllegalArguments");
            //    param = Console.ReadLine();
            //    paramArray = param.Split(' ');
            //}
            ConsoleParam consoleParam = new ConsoleParam();
            //string classFullName = paramArray[2];
            //classFullName = classFullName.Replace(".class", "`class");
            //classFullName = classFullName.Replace('.', '/');
            //classFullName = classFullName.Replace("`class", ".class");
            //consoleParam.ClassName = classFullName;
            return consoleParam;
        }
    }
}
