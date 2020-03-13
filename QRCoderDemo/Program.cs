using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QRCoderDemo
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            if(args.Length > 0)
            {
                Application.Run(new Form1(args[0]));
            }
            else
            {
                MessageBox.Show("请加上参数");
                //Application.Run(new Form1());
            }
           
        }
    }
}
