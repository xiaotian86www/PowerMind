using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerMind.Context.Base
{
    class InitFile
    {
        // 文件名字段属性
        private String fileName;

        public String FileName
        {
            get { return fileName; }
            set { this.fileName = value; }
        }

        // 声明读写INI文件的API函数
        [DllImport("kernel32")]
        private static extern bool WriteWritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);
        
        // 构造函数
        public InitFile(String fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);

            if (!fileInfo.Exists)
            {
                StreamWriter sw = new StreamWriter(fileName, false, Encoding.Default);
            }

            FileName = fileInfo.FullName;
        }
    }
}
