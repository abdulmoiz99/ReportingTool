using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportingTool
{
    static class Program
    {


        public static void Main()
        {
            Console.WriteLine("OPERATION HAS STARTED");
            while (true)
            {
                if (GenerateReports.CheckToGenerateReport())
                {
                    GenerateReports.Report();
                }
                Thread.Sleep(1000);
            }
        }



















        //  /// <summary>
        //  /// The main entry point for the application.
        //  /// </summary>
        ////  [STAThread]
        //  static void Main()
        //  {
        //      //Application.EnableVisualStyles();
        //      //Application.SetCompatibleTextRenderingDefault(false);
        //      //Application.Run(new frm_GenerateReport());
        //  }
    }
}
