using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsJVM.wakeup.classfile;

namespace CsJVM.wakeup
{
    public class ClassFile
    {
        private uint magic; 
        private ushort minor_version;
        private ushort major_version;
        private ushort constant_pool_count;
        private ConstantPool constant_pool;    //常量个数=constant_pool_count - 1
        private ushort access_flag;
        private ushort this_class;
        private ushort super_class;
        private ushort interface_count;
        private ushort[] interfaces;   //存储的是常量池中的索引
        private ushort fields_count;
        private MemberInfo[] fields;
        private ushort methods_count;
        private MemberInfo[] methods;
        private ushort attributes_count;
        private AttributeInfo[] attributes;

        public uint Magic { get => magic; set => magic = value; }
        public ushort Minor_version { get => minor_version; set => minor_version = value; }
        public ushort Major_version { get => major_version; set => major_version = value; }
        public ushort Constant_pool_count { get => constant_pool_count; set => constant_pool_count = value; }
        public ConstantPool Constant_pool { get => constant_pool; set => constant_pool = value; }
        public ushort Access_flag { get => access_flag; set => access_flag = value; }
        public ushort This_class { get => this_class; set => this_class = value; }
        public ushort Super_class { get => super_class; set => super_class = value; }
        public ushort Interface_count { get => interface_count; set => interface_count = value; }
        public ushort[] Interfaces { get => interfaces; set => interfaces = value; }
        public ushort Fields_count { get => fields_count; set => fields_count = value; }
        public ushort Methods_count { get => methods_count; set => methods_count = value; }
        public MemberInfo[] Methods { get => methods; set => methods = value; }
        public ushort Attributes_count { get => attributes_count; set => attributes_count = value; }
        public AttributeInfo[] Attributes { get => attributes; set => attributes = value; }
        public MemberInfo[] Fields { get => fields; set => fields = value; }
    }
}
