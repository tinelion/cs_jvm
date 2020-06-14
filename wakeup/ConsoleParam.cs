using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsJVM.wakeup
{
    public class ConsoleParam
    {
        private string jdkPath = "C:/Program Files/Java/jdk1.8.0_121/jre/lib/rt.jar";
        private string path = "C:/Users/zhl/Desktop";
        private string className = "com/wakeup/compile/CsJVMTest.class";

        public string ClassName { get => className; set => className = value; }
        public string JdkPath { get => jdkPath; set => jdkPath = value; }
        public string Path { get => path; set => path = value; }
    }
}
