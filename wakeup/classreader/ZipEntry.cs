using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsJVM.wakeup
{
    public class ZipEntry : Entry
    {
        private string ClassPath;
        public byte[] ReadClass(string className)
        {
            using (ZipArchive zipArchive = ZipFile.Open(ClassPath, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in zipArchive.Entries)
                {
                    if (entry.FullName == className)
                    {
                        using (Stream stream = entry.Open())
                        {
                            byte[] data = new byte[stream.Length];
                            stream.Read(data, 0, data.Length);
                            return data;
                        }
                    }
                }
            }
            return null;
        }

        public void SetClassPath(string classPath)
        {
            this.ClassPath = classPath;
        }
    }
}
