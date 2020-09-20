using LibCrud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrudSharp
{
    public partial class FrmReport : Form
    {
        public FrmReport(ReportDesignData reportDesignData)
        {
            InitializeComponent();
            this.Text = reportDesignData.Title;
            this.reportViewer.LocalReport.ReportEmbeddedResource = reportDesignData.Design;
            this.PersonFacadeBindingSource.DataSource = reportDesignData.DataSource;
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();
        }
    }
}
