using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloseWindowWM
{
    public static class WindowManager
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out IntPtr ProcessId);

        public static Process GetForgroundProcess()
        {
            IntPtr windowHwnd = GetForegroundWindow();
            GetWindowThreadProcessId(windowHwnd, out IntPtr processHwnd);
            return Process.GetProcessById(processHwnd.ToInt32());
        }
    }
}
