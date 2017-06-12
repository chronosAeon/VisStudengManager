using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisStudengManager
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
            Enter.ShowSplashScreen();
            Thread.Sleep(1000);
            if (Enter.Instance != null)
            {
                Enter.Instance.BeginInvoke(new MethodInvoker(Enter.Instance.Dispose));
                Enter.Instance = null;
            }
            Application.Run(new Admin());
        }
    }
}
