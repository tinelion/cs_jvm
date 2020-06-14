using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsJVM.wakeup
{
    public class DirectoryEntry : Entry
    {
        private string ClassPath;
        public byte[] ReadClass(string ClassName)
        {
            string fullPath = string.Format("{0}/{1}", ClassPath, ClassName);
            try
            {
                return File.ReadAllBytes(fullPath);
            } catch (IOException e)
            {

            }
            return null;
        }

        public void SetClassPath(string classPath)
        {
            this.ClassPath = classPath;
        }
    }
}
