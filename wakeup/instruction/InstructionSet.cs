using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsJVM.wakeup.instruction
{

    public class InstructionSet
    {

        //常量操作
        public const byte nop = (byte)0x00;    //无动作
        public const byte aconst_null = (byte)0x01;    //把 null 推到操作数栈
        public const byte iconst_m1 = (byte)0x02;    //把 int 常量 –1 推到操作数栈
        public const byte iconst_0 = (byte)0x03;    //把 int 常量 0 推到操作数栈
        public const byte iconst_1 = (byte)0x04;    //把 int 常量 1 推到操作数栈
        public const byte iconst_2 = (byte)0x05;    //把 int 常量 2 推到操作数栈
        public const byte iconst_3 = (byte)0x06;    //把 int 常量 3 推到操作数栈
        public const byte iconst_4 = (byte)0x07;    //把 int 常量 4 推到操作数栈
        public const byte iconst_5 = (byte)0x08;    //把 int 常量 5 推到操作数栈
        public const byte lconst_0 = (byte)0x09;    //把 long 常量 0 推到操作数栈
        public const byte lconst_1 = (byte)0x0A;    //把 long 常量 1 推到操作数栈
        public const byte fconst_0 = (byte)0x0B;    //把 float 常量 0 推到操作数栈
        public const byte fconst_1 = (byte)0x0C;    //把 float 常量 1 推到操作数栈
        public const byte fconst_2 = (byte)0x0D;    //把 float 常量 2 推到操作数栈
        public const byte dconst_0 = (byte)0x0E;    //把 double 常量 0 推到操作数栈
        public const byte dconst_1 = (byte)0x0F;    //把 double 常量 1 推到操作数栈
        public const byte bipush = (byte)0x10;    //把单字节常量（-128~127）推到操作数栈
        public const byte sipush = (byte)0x11;    //把 short 常量（-32768~32767）推到操作数栈
        public const byte ldc = (byte)0x12;    //把常量池中的int，float，String型常量取出并推到操作数栈
        public const byte ldc_w = (byte)0x13;    //把常量池中的int，float，String型常量取出并推到操作数栈（宽索引）
        public const byte ldc2_w = (byte)0x14;    //把常量池中的long，double型常量取出并推到操作数栈（宽索引）

        //载入操作数栈
        public const byte iload = (byte)0x15;    //把 int 型局部变量推到操作数栈
        public const byte lload = (byte)0x16;    //把 long 型局部变量推到操作数栈
        public const byte fload = (byte)0x17;    //把 float 型局部变量推到操作数栈
        public const byte dload = (byte)0x18;    //把 double 型局部变量推到操作数栈
        public const byte aload = (byte)0x19;    //把引用型局部变量推到操作数栈
        public const byte iload_0 = (byte)0x1A;    //把局部变量第 1 个 int 型局部变量推到操作数栈
        public const byte iload_1 = (byte)0x1B;    //把局部变量第 2 个 int 型局部变量推到操作数栈
        public const byte iload_2 = (byte)0x1C;    //把局部变量第 3 个 int 型局部变量推到操作数栈
        public const byte iload_3 = (byte)0x1D;    //把局部变量第 4 个 int 型局部变量推到操作数栈
        public const byte lload_0 = (byte)0x1E;    //把局部变量第 1 个 long 型局部变量推到操作数栈
        public const byte lload_1 = (byte)0x1F;    //把局部变量第 2 个 long 型局部变量推到操作数栈
        public const byte lload_2 = (byte)0x20;    //把局部变量第 3 个 long 型局部变量推到操作数栈
        public const byte lload_3 = (byte)0x21;    //把局部变量第 4 个 long 型局部变量推到操作数栈
        public const byte fload_0 = (byte)0x22;    //把局部变量第 1 个 float 型局部变量推到操作数栈
        public const byte fload_1 = (byte)0x23;    //把局部变量第 2 个 float 型局部变量推到操作数栈
        public const byte fload_2 = (byte)0x24;    //把局部变量第 3 个 float 型局部变量推到操作数栈
        public const byte fload_3 = (byte)0x25;    //把局部变量第 4 个 float 型局部变量推到操作数栈
        public const byte dload_0 = (byte)0x26;    //把局部变量第 1 个 double 型局部变量推到操作数栈
        public const byte dload_1 = (byte)0x27;    //把局部变量第 2 个 double 型局部变量推到操作数栈
        public const byte dload_2 = (byte)0x28;    //把局部变量第 3 个 double 型局部变量推到操作数栈
        public const byte dload_3 = (byte)0x29;    //把局部变量第 4 个 double 型局部变量推到操作数栈
        public const byte aload_0 = (byte)0x2A;    //把局部变量第 1 个引用型局部变量推到操作数栈
        public const byte aload_1 = (byte)0x2B;    //把局部变量第 2 个引用型局部变量推到操作数栈
        public const byte aload_2 = (byte)0x2C;    //把局部变量第 3 个引用型局部变量推到操作数栈
        public const byte aload_3 = (byte)0x2D;    //把局部变量第 4 个引用 型局部变量推到操作数栈
        public const byte iaload = (byte)0x2E;    //把 int 型数组指定索引的值推到操作数栈
        public const byte laload = (byte)0x2F;    //把 long 型数组指定索引的值推到操作数栈
        public const byte faload = (byte)0x30;    //把 float 型数组指定索引的值推到操作数栈
        public const byte daload = (byte)0x31;    //把 double 型数组指定索引的值推到操作数栈
        public const byte aaload = (byte)0x32;    //把引用型数组指定索引的值推到操作数栈
        public const byte baload = (byte)0x33;    //把 boolean或byte型数组指定索引的值推到操作数栈
        public const byte caload = (byte)0x34;    //把 char 型数组指定索引的值推到操作数栈
        public const byte saload = (byte)0x35;    //把 short 型数组指定索引的值推到操作数栈

        //存储局部变量
        public const byte istore = (byte)0x36;    //把栈顶 int 型数值存入指定局部变量
        public const byte lstore = (byte)0x37;    //把栈顶 long 型数值存入指定局部变量
        public const byte fstore = (byte)0x38;    //把栈顶 float 型数值存入指定局部变量
        public const byte dstore = (byte)0x39;    //把栈顶 double 型数值存入指定局部变量
        public const byte astore = (byte)0x3A;    //把栈顶引用型数值存入指定局部变量
        public const byte istore_0 = (byte)0x3B;    //把栈顶 int 型数值存入第 1 个局部变量
        public const byte istore_1 = (byte)0x3C;    //把栈顶 int 型数值存入第 2 个局部变量
        public const byte istore_2 = (byte)0x3D;    //把栈顶 int 型数值存入第 3 个局部变量
        public const byte istore_3 = (byte)0x3E;    //把栈顶 int 型数值存入第 4 个局部变量
        public const byte lstore_0 = (byte)0x3F;    //把栈顶 long 型数值存入第 1 个局部变量
        public const byte lstore_1 = (byte)0x40;    //把栈顶 long 型数值存入第 2 个局部变量
        public const byte lstore_2 = (byte)0x41;    //把栈顶 long 型数值存入第 3 个局部变量
        public const byte lstore_3 = (byte)0x42;    //把栈顶 long 型数值存入第 4 个局部变量
        public const byte fstore_0 = (byte)0x43;    //把栈顶 float 型数值存入第 1 个局部变量
        public const byte fstore_1 = (byte)0x44;    //把栈顶 float 型数值存入第 2 个局部变量
        public const byte fstore_2 = (byte)0x45;    //把栈顶 float 型数值存入第 3 个局部变量
        public const byte fstore_3 = (byte)0x46;    //把栈顶 float 型数值存入第 4 个局部变量
        public const byte dstore_0 = (byte)0x47;    //把栈顶 double 型数值存入第 1 个局部变量
        public const byte dstore_1 = (byte)0x48;    //把栈顶 double 型数值存入第 2 个局部变量
        public const byte dstore_2 = (byte)0x49;    //把栈顶 double 型数值存入第 3 个局部变量
        public const byte dstore_3 = (byte)0x4A;    //把栈顶 double 型数值存入第 4 个局部变量
        public const byte astore_0 = (byte)0x4B;    //把栈顶 引用 型数值存入第 1 个局部变量
        public const byte astore_1 = (byte)0x4C;    //把栈顶 引用 型数值存入第 2 个局部变量
        public const byte astore_2 = (byte)0x4D;    //把栈顶 引用 型数值存入第 3 个局部变量
        public const byte astore_3 = (byte)0x4E;    //把栈顶 引用 型数值存入第 4 个局部变量
        public const byte iastore = (byte)0x4F;    //把栈顶 int 型数值存入数组指定索引位置
        public const byte lastore = (byte)0x50;    //把栈顶 long 型数值存入数组指定索引位置
        public const byte fastore = (byte)0x51;    //把栈顶 float 型数值存入数组指定索引位置
        public const byte dastore = (byte)0x52;    //把栈顶 double 型数值存入数组指定索引位置
        public const byte aastore = (byte)0x53;    //把栈顶 引用 型数值存入数组指定索引位置
        public const byte bastore = (byte)0x54;    //把栈顶 boolean or byte 型数值存入数组指定索引位置
        public const byte castore = (byte)0x55;    //把栈顶 char 型数值存入数组指定索引位置
        public const byte sastore = (byte)0x56;    //把栈顶 short 型数值存入数组指定索引位置

        //栈操作
        public const byte pop = (byte)0x57;    //把栈顶数值弹出（非long，double数值）
        public const byte pop2 = (byte)0x58;    //把栈顶的一个long或double值弹出，或弹出2个其他类型数值
        public const byte dup = (byte)0x59;    //复制栈顶数值并把数值入栈
        public const byte dup_x1 = (byte)0x5A;    //复制栈顶数值并把数值入栈
        public const byte dup_x2 = (byte)0x5B;    //
        public const byte dup2 = (byte)0x5C;    //
        public const byte dup2_x1 = (byte)0x5D;    //
        public const byte dup2_x2 = (byte)0x5E;    //
        public const byte swap = (byte)0x5F;    //把栈顶端的两个数的值交换

        //数学运算
        public const byte iadd = (byte)0x60;    //把栈顶两个 int 型数值相加并将结果入栈
        public const byte ladd = (byte)0x61;    //把栈顶两个 long 型数值相加并将结果入栈
        public const byte fadd = (byte)0x62;    //把栈顶两个 float 型数值相加并将结果入栈
        public const byte dadd = (byte)0x63;    //把栈顶两个 double 型数值相加并将结果入栈
        public const byte isub = (byte)0x64;    //把栈顶两个 int 型数值相减并将结果入栈
        public const byte lsub = (byte)0x65;    //把栈顶两个 long 型数值相减并将结果入栈
        public const byte fsub = (byte)0x66;    //把栈顶两个 float 型数值相减并将结果入栈
        public const byte dsub = (byte)0x67;    //把栈顶两个 double 型数值相减并将结果入栈
        public const byte imul = (byte)0x68;    //把栈顶两个 int 型数值相乘并将结果入栈
        public const byte lmul = (byte)0x69;    //把栈顶两个 long 型数值相乘并将结果入栈
        public const byte fmul = (byte)0x6A;    //把栈顶两个 float 型数值相乘并将结果入栈
        public const byte dmul = (byte)0x6B;    //把栈顶两个 double 型数值相乘并将结果入栈
        public const byte idiv = (byte)0x6C;    //把栈顶两个 int 型数值相除并将结果入栈
        public const byte ldiv = (byte)0x6D;    //把栈顶两个 long 型数值相除并将结果入栈
        public const byte fdiv = (byte)0x6E;    //把栈顶两个 float 型数值相除并将结果入栈
        public const byte ddiv = (byte)0x6F;    //把栈顶两个 double 型数值相除并将结果入栈
        public const byte irem = (byte)0x70;    //把栈顶两个 int 型数值模运算并将结果入栈
        public const byte lrem = (byte)0x71;    //把栈顶两个 long 型数值模运算并将结果入栈
        public const byte frem = (byte)0x72;    //把栈顶两个 float 型数值模运算并将结果入栈
        public const byte drem = (byte)0x73;    //把栈顶两个 double 型数值模运算并将结果入栈
        public const byte ineg = (byte)0x74;    //把栈顶 int 型数值取负并将结果入栈
        public const byte lneg = (byte)0x75;    //把栈顶 long 型数值取负并将结果入栈
        public const byte fneg = (byte)0x76;    //把栈顶 float 型数值取负并将结果入栈
        public const byte dneg = (byte)0x77;    //把栈顶 double 型数值取负并将结果入栈
        public const byte ishl = (byte)0x78;    //把 int 型数左移指定位数并将结果入栈
        public const byte lshl = (byte)0x79;    //把 long 型数左移指定位数并将结果入栈
        public const byte ishr = (byte)0x7A;    //把 int 型数右移指定位数并将结果入栈（有符号）
        public const byte lshr = (byte)0x7B;    //把 long 型数右移指定位数并将结果入栈（有符号）
        public const byte iushr = (byte)0x7C;    //把 int 型数右移指定位数并将结果入栈（无符号）
        public const byte lushr = (byte)0x7D;    //把 long 型数右移指定位数并将结果入栈（无符号）
        public const byte iand = (byte)0x7E;    //把栈顶两个 int 型数值 按位与 并将结果入栈
        public const byte land = (byte)0x7F;    //把栈顶两个 long 型数值 按位与 并将结果入栈
        public const byte ior = (byte)0x80;    //把栈顶两个 int 型数值 按位或 并将结果入栈
        public const byte lor = (byte)0x81;    //把栈顶两个 long 型数值 按或与 并将结果入栈
        public const byte ixor = (byte)0x82;    //把栈顶两个 int 型数值 按位异或 并将结果入栈
        public const byte lxor = (byte)0x83;    //把栈顶两个 long 型数值 按位异或 并将结果入栈
        public const byte iinc = (byte)0x84;    //把指定 int 型增加指定值

        //类型转换
        public const byte i2l = (byte)0x85;    //把栈顶 int 强转 long 并入栈
        public const byte i2f = (byte)0x86;    //把栈顶 int 强转 float 并入栈
        public const byte i2d = (byte)0x87;    //把栈顶 int 强转 double 并入栈
        public const byte l2i = (byte)0x88;    //把栈顶 long 强转 int 并入栈
        public const byte l2f = (byte)0x89;    //把栈顶 long 强转 float 并入栈
        public const byte l2d = (byte)0x8A;    //把栈顶 long 强转 double 并入栈
        public const byte f2i = (byte)0x8B;    //把栈顶 float 强转 int 并入栈
        public const byte f2l = (byte)0x8C;    //把栈顶 float 强转 long 并入栈
        public const byte f2d = (byte)0x8D;    //把栈顶 float 强转 double 并入栈
        public const byte d2i = (byte)0x8E;    //把栈顶 double 强转 int 并入栈
        public const byte d2l = (byte)0x8F;    //把栈顶 double 强转 long 并入栈
        public const byte d2f = (byte)0x90;    //把栈顶 double 强转 float 并入栈
        public const byte i2b = (byte)0x91;    //把栈顶 int 强转 byte 并入栈
        public const byte i2c = (byte)0x92;    //把栈顶 int 强转 char 并入栈
        public const byte i2s = (byte)0x93;    //把栈顶 int 强转 short 并入栈

        //比较运算
        public const byte lcmp = (byte)0x94;    //比较栈顶两个long 型数值，把结果入栈（-1 or 0 or 1）
        public const byte fcmpl = (byte)0x95;    //比较栈顶两个 float 型数值，把结果入栈，若有 NaN，入栈 -1
        public const byte fcmpg = (byte)0x96;    //比较栈顶两个 float 型数值，把结果入栈，若有 NaN，入栈 1
        public const byte dcmpl = (byte)0x97;    //比较栈顶两个 double 型数值，把结果入栈，若有 NaN，入栈 -1
        public const byte dcmpg = (byte)0x98;    //比较栈顶两个 double 型数值，把结果入栈，若有 NaN，入栈 -1
        public const byte ifeq = (byte)0x99;    //当栈顶 int 型数值等于0时，跳转
        public const byte ifne = (byte)0x9A;    //当栈顶 int 型数值不等于0时，跳转
        public const byte iflt = (byte)0x9B;    //当栈顶 int 型数值小于0时，跳转
        public const byte ifge = (byte)0x9C;    //当栈顶 int 型数值大于等于0时，跳转
        public const byte ifgt = (byte)0x9D;    //当栈顶 int 型数值大于0时，跳转
        public const byte ifle = (byte)0x9E;    //当栈顶 int 型数值小于等于0时，跳转
        public const byte if_icmpeq = (byte)0x9F;    //比较栈顶两个 int 型数值，等于0时，跳转
        public const byte if_icmpne = (byte)0xA0;    //比较栈顶两个 int 型数值，不等于0时，跳转
        public const byte if_icmplt = (byte)0xA1;    //比较栈顶两个 int 型数值，小于0时，跳转
        public const byte if_icmpge = (byte)0xA2;    //比较栈顶两个 int 型数值，大于等于0时，跳转
        public const byte if_icmpgt = (byte)0xA3;    //比较栈顶两个 int 型数值，大于0时，跳转
        public const byte if_icmple = (byte)0xA4;    //比较栈顶两个 int 型数值，小于等于0时，跳转
        public const byte if_acmpeq = (byte)0xA5;    //比较栈顶两个 引用 型数值，相等时跳转
        public const byte if_acmpne = (byte)0xA6;    //比较栈顶两个 引用 型数值，不相等时跳转

        //流程控制
        public const byte _goto = (byte)0xA7;    //无条件跳转
        public const byte jsr = (byte)0xA8;    //跳转指定16bit偏移位置，并将jsr下一条指令地址入栈
        public const byte ret = (byte)0xA9;    //返回局部变量指定index指定位置，与jsr，jsr_w配合使用
        public const byte tableswitch = (byte)0xAA;    //switch跳转，case连续
        public const byte lookupswitch = (byte)0xAB;    //switch跳转，case不连续
        public const byte ireturn = (byte)0xAC;    //从当前方法返回 int
        public const byte lreturn = (byte)0xAD;    //从当前方法返回 long
        public const byte freturn = (byte)0xAE;    //从当前方法返回 float
        public const byte dreturn = (byte)0xAF;    //从当前方法返回 double
        public const byte areturn = (byte)0xB0;    //从当前方法返回 对象引用
        public const byte _return = (byte)0xB1;    //从当前方法返回 void

        //引用类型操作
        public const byte get = (byte)0xB2;    //获取类的静态域，并将值入栈顶
        public const byte put = (byte)0xB3;    //为类的静态域赋值
        public const byte getfield = (byte)0xB4;    //获取类的实例域，并将值入栈顶
        public const byte putfield = (byte)0xB5;    //为类的实例域赋值
        public const byte invokevirtual = (byte)0xB6;    //调用实例方法
        public const byte invokespecial = (byte)0xB7;    //调用父类构造方法，实例初始化方法，私有方法
        public const byte invoke = (byte)0xB8;    //调用静态方法
        public const byte invokeinterface = (byte)0xB9;    //调用接口方法
        public const byte invokedynamic = (byte)0xBA;    //调用动态链接方法

        //创建对象
        public const byte _new = (byte)0xBB;    //创建一个对象，并将引用值入栈
        public const byte newarray = (byte)0xBC;    //创建一个原始类型数组，并将引用值入栈
        public const byte anewarray = (byte)0xBD;    //创建一个引用类型数组，并将引用值入栈
        public const byte arraylength = (byte)0xBE;    //获取数组长度并入栈
        public const byte athrow = (byte)0xBF;    //抛出栈顶异常
        public const byte checkcast = (byte)0xC0;    //检验类型转换
        public const byte _instanceof = (byte)0xC1;    //检验是否是类的实例，是1入栈，否0入栈

        //同步
        public const byte monitorenter = (byte)0xC2;    //获取对象的monitor，用于同步块或方法
        public const byte monitorexit = (byte)0xC3;    //释放对象的monitor，用于同步块或方法

        //扩展
        public const byte wide = (byte)0xC4;    //扩展访问局部变量表的索引宽度
        public const byte multianewarray = (byte)0xC5;    //创建多维数组，并将引用值入栈
        public const byte ifnull = (byte)0xC6;    //为 null 时跳转
        public const byte ifnonnull = (byte)0xC7;    //非 null 时跳转
        public const byte goto_w = (byte)0xC8;    //无条件跳转（宽索引）
        public const byte jsr_w = (byte)0xC9;    //跳转指定32bit偏移位置，并将jsr_w下一条指令地址入栈

        //保留
        public const byte breakpoint = (byte)0xCA;    //调试时的断点
        public const byte impdep1 = (byte)0xFE;    //用于在特定硬件中使用的语言后门
        public const byte impdep2 = (byte)0xFF;    //用于在特定硬件中使用的语言后门
    }

}
