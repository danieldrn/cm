﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace CORUJAMANAGER
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.Automatic);
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormLogin());
            }
#if DEBUG
            else
            {
                ExecuteAplicacao(args);
            }
#endif
        }

        private static void ExecuteAplicacao(IReadOnlyList<string> args)
        {
            var idFormulario = args[0];
            var ass = Assembly.GetExecutingAssembly();

            if (!(ass.CreateInstance($"CORUJAMANAGER.{idFormulario}") is Form frm))
            {
                MessageBox.Show($@"Formulário não encontrado: {idFormulario}", @"Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            Application.Run(frm);
        }
    }
}