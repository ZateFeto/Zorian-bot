using AmongUsCapture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZorianAmongUs
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Task.Factory.StartNew(() =>
            {
                //initialize the main window, set it as the application main window
                //and close the splash screen
                Settings.conInterface = new ZorianLogger();
                Task.Factory.StartNew(() => GameMemReader.getInstance().RunLoop());
            });
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
