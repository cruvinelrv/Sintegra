using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Multisoft.SistemaSintegra.Code;

namespace Multisoft.SistemaSintegra
{
    static class Program
    {
        public static EnumSoftware software;

        private static DateTime _data;

        public static void SetMes(DateTime mes)
        {
            _data = Functions.PrimeiroDia(mes);
        }
        public static DateTime dtInicial
        {
            get { return _data; }
        }
        public static DateTime dtFinal
        {
            get { return Functions.UltimoDia(_data); }
        }





        public static bool isMFD;

        public static FormPrincipal form;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new FormPrincipal();
            Application.Run(form);
        }
    }
}
