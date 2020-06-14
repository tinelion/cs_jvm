using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsJVM.wakeup
{

    public class ConstantPoolInfoReader
    {
        private ConstantPoolInfoReader() { }

        public static ConstantPoolInfo Read(ClassReader classReader)
        {
            ushort tag = classReader.ReadU1();
            ConstantPoolInfo constantPoolInfo = null;
            switch (tag)
            {
                case 7:
                    constantPoolInfo = new ConstantClass(); break;
                case 9:
                    constantPoolInfo = new ConstantFieldRef(); break;
                case 10:
                    constantPoolInfo = new ConstantMethodRef(); break;
                case 11:
                    constantPoolInfo = new ConstantInterfaceMethodRef(); break;
                case 8:
                    constantPoolInfo = new ConstantString(); break;
                case 3:
                    constantPoolInfo = new ConstantInteger(); break;
                case 4:
                    constantPoolInfo = new ConstantFloat(); break;
                case 5:
                    constantPoolInfo = new ConstantLong(); break;
                case 6:
                    constantPoolInfo = new ConstantDouble(); break;
                case 12:
                    constantPoolInfo = new ConstantNameAndType(); break;
                case 1:
                    constantPoolInfo = new ConstantUtf8(); break;
                case 15:
                    constantPoolInfo = new ConstantMethodHandle(); break;
                case 16:
                    constantPoolInfo = new ConstantMethodType(); break;
                case 18:
                    constantPoolInfo = new ConstantInvokeDynamic(); break;
                default:
                    throw new Exception("ClassFileError:constantPoolInfo incorrect");
            }
            constantPoolInfo.Tag = tag;
            constantPoolInfo.ReadConstantPoolInfo(classReader);

            return constantPoolInfo;
        }
    }
    public abstract class ConstantPoolInfo
    {
        private ushort tag;


        public abstract void ReadConstantPoolInfo(ClassReader classReader);

        public ushort Tag { get => tag; set => tag = value; }
    }

    public class ConstantInteger : ConstantPoolInfo
    {
        private uint bytes;
        public override void ReadConstantPoolInfo(ClassReader classReader)
        {
            this.bytes = classReader.ReadU4();
        }
        public uint Bytes { get => bytes; set => bytes = value; }


    }

    public class ConstantLong : ConstantPoolInfo
    {
        private long bytes;

        public override void ReadConstantPoolInfo(ClassReader classReader)
        {
            this.bytes = classReader.ReadU8();
        }

        public long Bytes { get => bytes; set => bytes = value; }
    }

    public class ConstantFloat : ConstantPoolInfo
    {
        private float bytes;
        public override void ReadConstantPoolInfo(ClassReader classReader)
        {
            this.bytes = classReader.ReadF4();
        }
        public float Bytes { get => bytes; set => bytes = value; }
    }


    public class ConstantDouble : ConstantPoolInfo
    {
        private double bytes;

        public override void ReadConstantPoolInfo(ClassReader classReader)
        {
            this.bytes = classReader.ReadF8();
        }

        public double Bytes { get => bytes; set => bytes = value; }
    }


    public class ConstantUtf8 : ConstantPoolInfo
    {
        private ushort length;
        private byte[] bytes;
        public override void ReadConstantPoolInfo(ClassReader classReader)
        {
            this.length = classReader.ReadU2();
            this.bytes = classReader.ReadBytes(this.length);
        }


        public ushort Length { get => length; set => length = value; }
        public byte[] Bytes { get => bytes; set => bytes = value; }
    }

    public class ConstantString : ConstantPoolInfo
    {
        private ushort stringIndex;

        public override void ReadConstantPoolInfo(ClassReader classReader)
        {
            this.stringIndex = classReader.ReadU2();
        }
        public ushort StringIndex { get => stringIndex; set => stringIndex = value; }
    }

    public class ConstantClass : ConstantPoolInfo
    {
        private ushort classIndex;
        public override void ReadConstantPoolInfo(ClassReader classReader)
        {
            this.classIndex = classReader.ReadU2();
        }
        public ushort ClassIndex { get => classIndex; set => classIndex = value; }
    }

    public class ConstantNameAndType : ConstantPoolInfo
    {
        private ushort nameIndex;
        private ushort descriptorIndex; //描述符所在索引
        public override void ReadConstantPoolInfo(ClassReader classReader)
        {
            this.nameIndex = classReader.ReadU2();
            this.descriptorIndex = classReader.ReadU2();
        }

        public ushort NameIndex { get => nameIndex; set => nameIndex = value; }
        public ushort DescriptorIndex { get => descriptorIndex; set => descriptorIndex = value; }
    }

    public class ConstantFieldRef : ConstantPoolInfo
    {
        private ushort classIndex;
        private ushort nameAndTypeIndex;

        public override void ReadConstantPoolInfo(ClassReader classReader)
        {
            this.classIndex = classReader.ReadU2();
            this.nameAndTypeIndex = classReader.ReadU2();
        }

        public ushort ClassIndex { get => classIndex; set => classIndex = value; }
        public ushort NameAndTypeIndex { get => nameAndTypeIndex; set => nameAndTypeIndex = value; }
    }


    public class ConstantMethodRef : ConstantPoolInfo
    {
        private ushort classIndex;
        private ushort nameAndTypeIndex;

        public override void ReadConstantPoolInfo(ClassReader classReader)
        {
            this.classIndex = classReader.ReadU2();
            this.nameAndTypeIndex = classReader.ReadU2();
        }
        public ushort ClassIndex { get => classIndex; set => classIndex = value; }
        public ushort NameAndTypeIndex { get => nameAndTypeIndex; set => nameAndTypeIndex = value; }
    }

    public class ConstantInterfaceMethodRef : ConstantPoolInfo
    {
        private ushort classIndex;
        private ushort nameAndTypeIndex;

        public override void ReadConstantPoolInfo(ClassReader classReader)
        {
            this.classIndex = classReader.ReadU2();
            this.nameAndTypeIndex = classReader.ReadU2();
        }

        public ushort ClassIndex { get => classIndex; set => classIndex = value; }
        public ushort NameAndTypeIndex { get => nameAndTypeIndex; set => nameAndTypeIndex = value; }
    }

    public class ConstantMethodHandle : ConstantPoolInfo
    {
        private byte referenceKind;
        private ushort referenceIndex;

        public override void ReadConstantPoolInfo(ClassReader classReader)
        {
            this.referenceKind = classReader.ReadU1();
            this.referenceIndex = classReader.ReadU2();
        }

        public byte ReferenceKind { get => referenceKind; set => referenceKind = value; }
        public ushort ReferenceIndex { get => referenceIndex; set => referenceIndex = value; }
    }

    public class ConstantMethodType : ConstantPoolInfo
    {
        private ushort descriptorIndex;

        public override void ReadConstantPoolInfo(ClassReader classReader)
        {
            this.descriptorIndex = classReader.ReadU2();
        }
        public ushort DescriptorIndex { get => descriptorIndex; set => descriptorIndex = value; }
    }

    public class ConstantInvokeDynamic : ConstantPoolInfo
    {
        private ushort bootstrapMethodAttrIndex;
        private ushort nameAndTypeIndex;
        public override void ReadConstantPoolInfo(ClassReader classReader)
        {
            this.bootstrapMethodAttrIndex = classReader.ReadU2();
            this.nameAndTypeIndex = classReader.ReadU2();
        }
        public ushort BootstrapMethodAttrIndex { get => bootstrapMethodAttrIndex; set => bootstrapMethodAttrIndex = value; }
        public ushort NameAndTypeIndex { get => nameAndTypeIndex; set => nameAndTypeIndex = value; }
    }
}
