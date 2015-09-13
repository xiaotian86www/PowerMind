﻿using PowerStone.Core;
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
            Context.ParseXml("text.xml");
            Book.Book bk = (Book.Book)Context.GetStone("PowerMind.Stone.Book");
            if (bk == null)
            {
                Console.WriteLine("11111");
                return;
            }
            bk.Main();
        }
    }
}
