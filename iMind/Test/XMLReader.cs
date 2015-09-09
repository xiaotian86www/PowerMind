using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Test
{
    class XMLReader
    {
        public static void Main(String[] args)
        {
            FileInfo fi = new FileInfo("text.xml");
            if (!fi.Exists)
            {
                Console.WriteLine("text.xml 不存在");
                return;
            }

            XmlDocument xmld = new XmlDocument();

            xmld.Load(fi.FullName);

            XmlNode xmln = xmld.FirstChild;
            XmlNode xmle = xmln.FirstChild;
            Console.WriteLine(xmle.Value);
        }
    }
}
