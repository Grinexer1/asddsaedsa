﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfApp1asds
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Zak());
        }

    }
    public static class asd
    {
        public static string role { get; set; }
        public static int x { get; set; }
        public static int y { get; set; }
        public static int l { get; set; }
        public static string log { get; set; }
    }
 

}
