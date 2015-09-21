using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerMind.Control
{
    static class MindConvert
    {
        public static Rectangle StringToRectangle(String str)
        {
            String[] subStr = str.Split(',');
            Rectangle rectangle = new Rectangle(Convert.ToInt32(subStr[0]), Convert.ToInt32(subStr[1]), Convert.ToInt32(subStr[2]), Convert.ToInt32(subStr[3]));
            return rectangle;
        }

        public static String RectangleToString(Rectangle rectangle)
        {
            String str = rectangle.X + "," + rectangle.Y + "," + rectangle.Width + "," + rectangle.Height;
            return str;
        }
    }
}
