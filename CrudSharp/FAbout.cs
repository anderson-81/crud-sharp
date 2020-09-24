using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudSharp
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            SetBuildDate();
        }

        private void SetBuildDate()
        {
            DateTime buildDate = new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime;
            txtBuildDate.Text = buildDate.ToString();
        }

        private void txtProduct_Enter(object sender, EventArgs e)
        {
            this.btnClose.Focus();
        }

        private void txtVersion_Enter(object sender, EventArgs e)
        {
            this.btnClose.Focus();
        }

        private void txtAuthor_Enter(object sender, EventArgs e)
        {
            this.btnClose.Focus();
        }

        private void txtBuildDate_Enter(object sender, EventArgs e)
        {
            this.btnClose.Focus();
        }
    }
}
