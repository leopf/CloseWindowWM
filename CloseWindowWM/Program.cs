using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CloseWindowWM.HotKeyEventArgs;

namespace CloseWindowWM
{
    class Program
    {
        private static string ErrorMessage = null;

        static void Main(string[] args)
        {
            ErrorMessage = File.ReadAllText("errormsg.txt");

            HotKeyManager.HotKeyPressed += (ss, ee) => CloseWindow();
            HotKeyManager.RegisterHotKey(Keys.L, KeyModifiers.Alt);
            Thread.Sleep(Timeout.Infinite);
        }

        private static void CloseWindow()
        {
            Process process = WindowManager.GetForgroundProcess();
            process.Kill();

            string msg = ErrorMessage.Replace("[[processname]]", process.ProcessName);

            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
