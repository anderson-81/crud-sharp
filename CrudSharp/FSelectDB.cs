using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudSharp
{
    public partial class FrmSelectDB : Form
    {
        private FrmSplash frmSplash = null;
        private FrmLogin frmLogin = null;

        public FrmSelectDB()
        {
            InitializeComponent();
        }

        public FrmSelectDB(FrmLogin frmLogin)
        {
            InitializeComponent();
            this.frmLogin = frmLogin;
        }

        public FrmSelectDB(FrmSplash frmSplash)
        {
            InitializeComponent();
            this.frmSplash = frmSplash;
        }

        private void FrmSelectDB_Load(object sender, EventArgs e)
        {
            this.cmbDatabases.SelectedIndex = 0;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmConfigDB frmConfigDB = null;
            if (this.frmLogin != null)
            {
                frmConfigDB = new FrmConfigDB(this, this.frmLogin, this.cmbDatabases.SelectedIndex);
            }
            else
            {
                frmConfigDB = new FrmConfigDB(this, this.cmbDatabases.SelectedIndex);
            }
            frmConfigDB.ShowDialog(this);
        }
    }
}
