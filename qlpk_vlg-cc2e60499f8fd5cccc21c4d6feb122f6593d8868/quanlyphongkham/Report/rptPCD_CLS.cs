using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace quanlyphongkham.Report
{
    public partial class rptPCD_CLS : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPCD_CLS()
        {
            InitializeComponent();
        }

        public void BindData()
        {
            lbCLS_TEN.DataBindings.Add("Text", DataSource, "CLS_TEN");
            lbCTCLS_SL.DataBindings.Add("Text", DataSource, "CTCLS_SOLUONG");
            
        }

    }
}
