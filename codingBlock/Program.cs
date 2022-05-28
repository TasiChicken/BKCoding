﻿using System;
using System.IO;
using System.Windows.Forms;

namespace codingBlock
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(args.Length > 0 && File.Exists(args[0]) ? new SelectProjectForm(args[0]) : new SelectProjectForm());
        }
    }
}