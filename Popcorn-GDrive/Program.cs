using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Popcorn_GDrive
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        static System.Threading.Mutex systemMutex = null;

        [STAThread]
        static void Main()
        {
            /*if (PriorProcess() != null)
            {
                Application.Exit();
                //MessageBox.Show("You can run only 1 instance at a time!");
                return;
            }*/

            bool instantiated;
            systemMutex = new System.Threading.Mutex(false, "Popcorn-GDrive", out instantiated);
            if (instantiated)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mainForm());
            }


        }

        /*public static Process PriorProcess()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);
            foreach (Process p in processes)
            {
                if ((p.Id != currentProcess.Id) && (p.MainModule.FileName == currentProcess.MainModule.FileName))
                    return p;
            }
            return null;
        }*/
    }
}
