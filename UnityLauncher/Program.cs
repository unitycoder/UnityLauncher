using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnityLauncher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            // TODO allow only single instance https://stackoverflow.com/a/6486341/5452781
            bool result = false;
            var mutex = new System.Threading.Mutex(true, "UniqueAppId", out result);

            if (result == false)
            {
                // another instance already running, decide what to do
                MessageBox.Show("Another instance is already running.");
                return;
            }*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //GC.KeepAlive(mutex);
        }
    }
}
