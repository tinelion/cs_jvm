using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsJVM.wakeup
{
    public class ConstantPool
    {
        private ushort length;
        private ConstantPoolInfo[] constantPoolInfos;

        private ConstantPool() { }

        public ConstantPool(ClassReader classReader, ushort length)
        {
           this.constantPoolInfos = new ConstantPoolInfo[length];
            this.Length = length;
            //i=0位置无效
            for (int i = 1; i < this.Length; i++)
            {
                ConstantPoolInfo temp = ConstantPoolInfoReader.Read(classReader);
                constantPoolInfos[i] = temp;
                //long/double类型使得下一个位置无效，需跳过
                if(temp.Tag == 5 || temp.Tag == 6)
                {
                    i++;
                }
            }
        }
        

        public ushort Length { get => length; set => length = value; }
        public ConstantPoolInfo[] ConstantPoolInfo { get => constantPoolInfos; set => constantPoolInfos = value; }
    }
}
