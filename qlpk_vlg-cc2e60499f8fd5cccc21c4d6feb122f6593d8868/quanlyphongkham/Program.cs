﻿using quanlyphongkham.FORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlyphongkham
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
            Application.Run(new frmXUATTHUOC());

            //frmDANG_NHAP dn = new frmDANG_NHAP();
            //if (dn.ShowDialog() == DialogResult.OK)
            //{
            //    frmMain frm = new frmMain();
            //    frm.dt = dn.dt;
            //    Application.Run(frm);
            //}


            //if (frmMain.dx == 1)
            //{
            //    frmDANG_NHAP dn2 = new frmDANG_NHAP();
            //    Application.Run(dn2);
            //}
        }
    }
}
