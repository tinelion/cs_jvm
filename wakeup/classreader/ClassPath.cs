using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsJVM.wakeup
{
    public class ClassPath : Entry
    {
        private Entry bootClassPath;
        private Entry userClassPath;
        public ClassPath(string jdkPath, string path)
        {
            bootClassPath = new ZipEntry();
            bootClassPath.SetClassPath(jdkPath);
            userClassPath = new DirectoryEntry();
            userClassPath.SetClassPath(path);
        }
        public byte[] ReadClass(string className)
        {
            byte[] classData = bootClassPath.ReadClass(className);
            if(classData != null)
            {
                return classData;
            }
            else
            {
                classData = userClassPath.ReadClass(className);
            }

            if(classData != null)
            {
                return classData;
            }
            throw new Exception("ClassNotFoundException");
        }

        public void SetClassPath(string classPath)
        {
            throw new NotImplementedException();
        }
    }
}
