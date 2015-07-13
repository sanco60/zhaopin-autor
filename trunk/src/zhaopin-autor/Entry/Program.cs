using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstWebTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!init())
            {
                Console.WriteLine("Error: init failed!");
                return;
            }
            s_Form1 = new Form1();
            Application.Run(s_Form1);
        }

        static bool init()
        {
            if (!UserManager.init())
            {
                return false;
            }
            if (!SearchFactorManager.init())
            {
                return false;
            }
            if (!ForbiddenCorpManager.init())
            {
                return false;
            }
            return true;
        }

        private static Form1 s_Form1;
    }
}

