using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsJVM.wakeup.classfile;
using CsJVM.wakeup.config;

namespace CsJVM.wakeup
{
    public class ClassReader
    {
        private byte[] classData;
        private int offset = 0;
        private ClassFile classFile = new ClassFile();

        private ClassReader() { }

        public static ClassFile Read(byte[] classData)
        {
            ClassReader classReader = new ClassReader();
            return classReader.ReadClass(classData);
        }


        protected ClassFile ReadClass(byte[] classData)
        {
            ClassReader classReader = new ClassReader();
            this.classData = classData;
            ReadMagic();
            ReadVersion();
            ReadConstantPoolSize();
            ReadConstantPool();
            ReadAccessFlag();
            ReadThisClassIndex();
            ReadSuperClassIndex();
            ReadInterfaceCount();
            ReadInterfaces();
            ReadFieldsCount();
            ReadFields();
            ReadMethodsCount();
            ReadMethods();
            ReadAttributesCount();
            ReadAttributes();

            return this.classFile;
        }


        private void ReadMagic()
        {
            uint magic = ReadU4();
  
            if (magic != 0xCAFEBABE)
            {
                throw new Exception("Not a class file");
            }
            classFile.Magic = magic;
        }

        private void ReadVersion()
        {
            ushort minorVersion = ReadU2();
            ushort majorVersion = ReadU2();
            if (majorVersion > 52)
            {
                throw new Exception("Unsupported version of 54+");
            }
            classFile.Major_version = majorVersion;
            classFile.Minor_version = minorVersion;
        }

        private void ReadConstantPoolSize()
        {
            classFile.Constant_pool_count = ReadU2();
        }

        private void ReadConstantPool()
        {
            classFile.Constant_pool = new ConstantPool(this, classFile.Constant_pool_count);
            DebugConstantName(classFile.Constant_pool);    //打印常量池Utf8，调试用
        }
        private static void DebugConstantName(ConstantPool constantPool)
        {
            if (!Switchs.DebugParse)
            {
                return;
            }
            Console.Out.WriteLine();  //另起一行
            for (int i = 1; i < constantPool.Length; i++)
            {
                ConstantPoolInfo info = constantPool.ConstantPoolInfo[i];
                if (info.Tag == 1)
                {
                    string name = Encoding.UTF8.GetString(((ConstantUtf8)info).Bytes);
                    Console.Out.WriteLine(string.Format("序号:{0},名称:{1}", i, name));
                }
            }
        }


        private void ReadAccessFlag()
        {
            classFile.Access_flag = ReadU2();
        }

        private void ReadThisClassIndex()
        {
            classFile.This_class = ReadU2();
        }
        private void ReadSuperClassIndex()
        {
            classFile.Super_class = ReadU2();
        }

        private void ReadInterfaceCount()
        {
            classFile.Interface_count = ReadU2();
        }

        private void ReadInterfaces()
        {
            classFile.Interfaces = new ushort[classFile.Interface_count];
            for(int i = 0; i < classFile.Interface_count; i++)
            {
                classFile.Interfaces[i] = ReadU2();
            }
        }


        private void ReadFieldsCount()
        {
            classFile.Fields_count = ReadU2();
        }

        private void ReadFields()
        {
            classFile.Fields = new MemberInfo[classFile.Fields_count];

            for (int i = 0; i < classFile.Fields_count; i++)
            {
                classFile.Fields[i] = new MemberInfo(this, classFile.Constant_pool);
            }
        }


        private void ReadMethodsCount()
        {
            classFile.Methods_count = ReadU2();
        }

        private void ReadMethods()
        {
            classFile.Methods = new MemberInfo[classFile.Methods_count];

            for (int i = 0; i < classFile.Methods_count; i++)
            {
                classFile.Methods[i] = new MemberInfo(this, classFile.Constant_pool);
            }
        }


        private void ReadAttributesCount()
        {
            classFile.Attributes_count = ReadU2();
        }

        private void ReadAttributes()
        {
            for(int i = 0; i < classFile.Attributes_count; i++)
            {
                AttributeInfoReader.Read(this, this.classFile.Constant_pool);
            }
        }


        public byte ReadU1()
        {
            return classData[offset++];
        }

        public ushort ReadU2()
        {
            return BitConverter.ToUInt16(GetReversedByte(2), 0);
        }

        private byte[] GetReversedByte(uint n)
        {
            byte[] value = ReadBytes(n);
            Array.Reverse(value);
            return value;
        }

        public uint ReadU4OfUint()
        {
            uint value = BitConverter.ToUInt32(classData, offset);
            offset += 4;
            return value;
        }

        public uint ReadU4()
        {
            return BitConverter.ToUInt32(GetReversedByte(4), 0);
        }

        public float ReadF4()
        {
            return BitConverter.ToSingle(GetReversedByte(4), 0);
        }


        public double ReadF8()
        {
            return BitConverter.ToDouble(GetReversedByte(8), 0);
        }

        public byte[] ReadBytes(uint n)
        {
            byte[] bytes = new byte[n];
            for(int i = 0; i < n; i++)
            {
                bytes[i] = classData[offset++];
            }
            DebugParsedByte(bytes);
            return bytes;
        }

        private void DebugParsedByte(byte[] bytes)
        {
            if (!Switchs.DebugParse)
            {
                return;
            }
            Console.Out.WriteLine(BitConverter.ToString(bytes));
        }

        public long ReadU8()
        {
            return BitConverter.ToInt64(GetReversedByte(8), offset);
        }
    }
}
