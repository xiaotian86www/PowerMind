using PowerMind.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerMind
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Context context = Context.GetContext();

            if (0 == args.Length)
            {
                context.AddXmlMind("newMind");
                Application.Run(new MainForm("newMind"));
            }
            else
            {
                foreach (String arg in args)
                {
                    context.LoadXmlMind(arg);
                    Application.Run(new MainForm(arg));
                }
            }
        }
    }
}
