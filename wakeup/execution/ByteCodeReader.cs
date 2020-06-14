using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsJVM.wakeup.runtime;

namespace CsJVM.wakeup.execution
{
    public class ByteCodeReader
    {

        public static byte ReadOperateCode(VMThread thread, byte[] byteCode)
        {
            return ReadU1(thread, byteCode);
        }


        public static short ReadShort(VMThread thread, byte[] byteCode)
        {
            byte high = ReadU1(thread, byteCode);
            byte low = ReadU1(thread, byteCode);
            return (short)((high << 8) | low);
        }

        public static byte[] ReadBytes(VMThread thread, byte[] byteCode, int n)
        {
            byte[] result = new byte[n];
            for(int i = 0; i < n; i++)
            {
                result[i] = byteCode[thread.Pc++];
            }
            return result;
        }

        private static byte ReadU1(VMThread thread, byte[] byteCode)
        {
            return byteCode[thread.Pc++];
        }

    }
}
