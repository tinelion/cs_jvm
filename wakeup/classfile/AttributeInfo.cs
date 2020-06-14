using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsJVM.wakeup.classfile
{

    public class AttributeInfoReader
    {
        private AttributeInfoReader() { }



        public static AttributeInfo Read(ClassReader classReader, ConstantPool constantPool)
        {
            ushort attributeNameIndex = classReader.ReadU2();
            string attributeName = Encoding.UTF8.GetString(((ConstantUtf8)constantPool.ConstantPoolInfo[attributeNameIndex]).Bytes);
            AttributeInfo attributeInfo = null;
            switch (attributeName)
            {
                case "ConstantValue":
                    attributeInfo = new ConstantValue(); break;
                case "Code":
                    attributeInfo = new Code(); break;
                case "Deprecated":
                    attributeInfo = new Deprecated(); break;
                case "LineNumberTable":
                    attributeInfo = new LineNumberTable(); break;
                case "LocalVariableTable":
                    attributeInfo = new LocalVariableTable(); break;
                case "SourceFile":
                    attributeInfo = new SourceFile(); break;
                case "Synthetic":
                    attributeInfo = new Synthetic(); break;
                case "Exceptions":
                    attributeInfo = new Exceptions(); break;
                case "Signature":
                    attributeInfo = new Signature(); break;
                //case "StackMapTable":
                //    attributeInfo = null;
                default:
                    throw new Exception("no such attribute error");
            }
            attributeInfo.AttributeName = attributeName;
            attributeInfo.ReadAttributeInfo(classReader, constantPool);
            return attributeInfo;
        }
    }
    public abstract class AttributeInfo
    {
        private ushort attributeNameIndex;
        private uint attributeLength;
        private string attributeName;

        public void ReadAttributeInfo(ClassReader classReader, ConstantPool constantPool)
        {
            this.attributeLength = classReader.ReadU4();
            Read(classReader, constantPool);
        }

        protected abstract void Read(ClassReader classReader, ConstantPool constantPool);

        public ushort AttributeNameIndex { get => attributeNameIndex; set => attributeNameIndex = value; }
        public uint AttributeLength { get => attributeLength; set => attributeLength = value; }
        public string AttributeName { get => attributeName; set => attributeName = value; }
    }


    public class ConstantValue : AttributeInfo
    {
        private ushort constantValueIndex;

        protected override void Read(ClassReader classReader, ConstantPool constantPool)
        {
            this.constantValueIndex = classReader.ReadU2();
        }
        public ushort ConstantValueIndex { get => constantValueIndex; set => constantValueIndex = value; }

    }

    public class Code : AttributeInfo
    {
        private ushort maxStack;
        private ushort maxLocals;
        private uint codeLength;
        private byte[] codeData;
        private ushort exceptionTableLength;
        private ExceptionTable[] exceptionTable;
        private ushort attributeCount;
        private AttributeInfo[] attributeInfos;

        protected override void Read(ClassReader classReader, ConstantPool constantPool)
        {
            this.maxStack = classReader.ReadU2();
            this.maxLocals = classReader.ReadU2();
            this.codeLength = classReader.ReadU4();
            this.codeData = classReader.ReadBytes(this.codeLength);
            this.exceptionTableLength = classReader.ReadU2();
            this.exceptionTable = new ExceptionTable[this.exceptionTableLength];

            for (int i = 0; i < this.exceptionTableLength; i++)
            {
                exceptionTable[i] = new ExceptionTable(classReader);
            }
            this.attributeCount = classReader.ReadU2();
            this.attributeInfos = new AttributeInfo[this.attributeCount];

            for (int i = 0; i < this.attributeCount; i++)
            {
                this.attributeInfos[i] = AttributeInfoReader.Read(classReader, constantPool);
            }

        }

        public ushort MaxStack { get => maxStack; set => maxStack = value; }
        public ushort MaxLocals { get => maxLocals; set => maxLocals = value; }
        public uint CodeLength { get => codeLength; set => codeLength = value; }
        public byte[] CodeData { get => codeData; set => codeData = value; }
        public ushort ExceptionTableLength { get => exceptionTableLength; set => exceptionTableLength = value; }
        public ExceptionTable[] ExceptionTable { get => exceptionTable; set => exceptionTable = value; }
        public ushort AttributeCount { get => attributeCount; set => attributeCount = value; }
        public AttributeInfo[] AttributeInfos { get => attributeInfos; set => attributeInfos = value; }
    }

    public class SourceFile : AttributeInfo
    {
        private ushort sourceFileIndex;

        public ushort SourceFileIndex { get => sourceFileIndex; set => sourceFileIndex = value; }

        protected override void Read(ClassReader classReader, ConstantPool constantPool)
        {
            this.sourceFileIndex = classReader.ReadU2();
        }

    }

    public class LineNumberTable : AttributeInfo
    {
        private ushort lineNumberTableLength;
        private LineNumberTableEntry[] lineNumberTableEntry;


        public LineNumberTableEntry[] LineNumberTableEntry1 { get => lineNumberTableEntry; set => lineNumberTableEntry = value; }

        protected override void Read(ClassReader classReader, ConstantPool constantPool)
        {
            this.lineNumberTableLength = classReader.ReadU2();
            this.lineNumberTableEntry = new LineNumberTableEntry[this.lineNumberTableLength];
            for (int i = 0; i < this.lineNumberTableLength; i++)
            {
                this.lineNumberTableEntry[i] = new LineNumberTableEntry(classReader);
            }
        }

        public class LineNumberTableEntry
        {
            private ushort startPc;
            private ushort lineNumber;

            public LineNumberTableEntry(ClassReader classReader)
            {
                this.startPc = classReader.ReadU2();
                this.lineNumber = classReader.ReadU2();
            }

            public ushort StartPc { get => startPc; set => startPc = value; }
            public ushort LineNumber { get => lineNumber; set => lineNumber = value; }
        }
    }


    public class LocalVariableTable : AttributeInfo
    {
        private ushort localVariableTableLength;
        private LocalVariableTableEntry[] localVariableTableEntrys;

        public LocalVariableTableEntry[] LocalVariableTableEntrys { get => LocalVariableTableEntrys1; set => LocalVariableTableEntrys1 = value; }
        public LocalVariableTableEntry[] LocalVariableTableEntrys1 { get => localVariableTableEntrys; set => localVariableTableEntrys = value; }

        protected override void Read(ClassReader classReader, ConstantPool constantPool)
        {
            this.localVariableTableLength = classReader.ReadU2();
            this.localVariableTableEntrys = new LocalVariableTableEntry[this.localVariableTableLength];
            for (int i = 0; i < this.localVariableTableLength; i++)
            {
                this.localVariableTableEntrys[i] = new LocalVariableTableEntry(classReader);
            }
        }

        public class LocalVariableTableEntry
        {
            private ushort startPc;
            private ushort length;
            private ushort nameIndex;
            private ushort descriptorIndex;
            private ushort index;

            public LocalVariableTableEntry(ClassReader classReader)
            {
                this.startPc = classReader.ReadU2();
                this.length = classReader.ReadU2();
                this.nameIndex = classReader.ReadU2();
                this.descriptorIndex = classReader.ReadU2();
                this.index = classReader.ReadU2();
            }

            public ushort StartPc { get => startPc; set => startPc = value; }
            public ushort Length { get => length; set => length = value; }
            public ushort NameIndex { get => nameIndex; set => nameIndex = value; }
            public ushort DescriptorIndex { get => descriptorIndex; set => descriptorIndex = value; }
            public ushort Index { get => index; set => index = value; }
        }
    }



    public class ExceptionTable
    {
        private ushort startPc;
        private ushort endPc;
        private ushort handlerPc;
        private ushort catchType;

        public ExceptionTable(ClassReader classReader)
        {
            this.startPc = classReader.ReadU2();
            this.endPc = classReader.ReadU2();
            this.handlerPc = classReader.ReadU2();
            this.catchType = classReader.ReadU2();
        }

        public ushort StartPc { get => startPc; set => startPc = value; }
        public ushort EndPc { get => endPc; set => endPc = value; }
        public ushort HandlerPc { get => handlerPc; set => handlerPc = value; }
        public ushort CatchType { get => catchType; set => catchType = value; }
    }


    public class Deprecated : AttributeInfo
    {
        protected override void Read(ClassReader classReader, ConstantPool constantPool)
        {
            //Do Nothing
        }
    }

    public class Synthetic : AttributeInfo
    {
        protected override void Read(ClassReader classReader, ConstantPool constantPool)
        {
            //Do Nothing
        }
    }

    public class Exceptions : AttributeInfo
    {
        private ushort numberOfExceptions;
        private ushort[] exceptionIndexTable;

        public ushort NumberOfExceptions { get => numberOfExceptions; set => numberOfExceptions = value; }
        public ushort[] ExceptionIndexTable { get => exceptionIndexTable; set => exceptionIndexTable = value; }

        protected override void Read(ClassReader classReader, ConstantPool constantPool)
        {
            this.numberOfExceptions = classReader.ReadU2();
            this.exceptionIndexTable = new ushort[this.numberOfExceptions];

            for (int i = 0; i < this.numberOfExceptions; i++)
            {
                this.exceptionIndexTable[i] = classReader.ReadU2();
            }
        }
    }

    public class Signature : AttributeInfo
    {
        private ushort signatureIndex;

        public ushort SignatureIndex { get => signatureIndex; set => signatureIndex = value; }

        protected override void Read(ClassReader classReader, ConstantPool constantPool)
        {
            this.signatureIndex = classReader.ReadU2();
        }
    }

    public class StackMapTable : AttributeInfo
    {
        private ushort numberOfEntrys;
        private StackMapFrame[] entrys;

        protected override void Read(ClassReader classReader, ConstantPool constantPool)
        {
            throw new NotImplementedException();
        }
    }

    public class StackMapFrame
    {

    }
}
