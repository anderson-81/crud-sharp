using LibCrud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudSharp
{
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {
            InitializeComponent();
        }

        private void FrmSplash_Shown(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            this.Hide();
            ConfigurationDatabase configDB = new ConfigurationDatabase();
            if (configDB.GetConnectionConfiguration() != null)
            {
                FrmLogin frmLogin = new FrmLogin(this);
                frmLogin.ShowDialog(this);
                this.Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want create a connection's configuration to database?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    FrmSelectDB frmSelectDB = new FrmSelectDB(this);
                    frmSelectDB.ShowDialog(this);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The system will be closed.", "Question", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
            }
        }
    }
}
