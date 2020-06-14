using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsJVM.wakeup.classfile
{
    /// <summary>
    /// 字段、方法
    /// </summary>
    public class MemberInfo
    {
        private ushort accessFlag;
        private ushort nameIndex;
        private ushort descriptorIndex;
        private ushort attributesCount;
        private AttributeInfo[] attributes;


        public MemberInfo(ClassReader classReader, ConstantPool constantPool)
        {
            this.accessFlag = classReader.ReadU2();
            this.nameIndex = classReader.ReadU2();
            this.descriptorIndex = classReader.ReadU2();
            this.attributesCount = classReader.ReadU2();
            this.attributes = new AttributeInfo[this.attributesCount];

            for(int i = 0; i < this.attributesCount; i++)
            {
                this.attributes[i] = AttributeInfoReader.Read(classReader, constantPool);

            }
        }

        public Code CodeAttribute()
        {
            foreach(AttributeInfo attribute in attributes)
            {
                if(attribute.AttributeName == "Code")
                {
                    return (Code)attribute;
                }
            }
            return null;
        }

        public ushort AccessFlag { get => accessFlag; set => accessFlag = value; }
        public ushort NameIndex { get => nameIndex; set => nameIndex = value; }
        public ushort DescriptorIndex { get => descriptorIndex; set => descriptorIndex = value; }
        public ushort AttributesCount { get => attributesCount; set => attributesCount = value; }
        public AttributeInfo[] Attributes { get => attributes; set => attributes = value; }
    }
}
