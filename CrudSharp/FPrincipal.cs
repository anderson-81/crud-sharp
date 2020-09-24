using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrudSharp
{
    public partial class FrmPrincipal : Form
    {
        private FrmLogin frmLogin;
        private FrmReportOptions fro = null;
        private FrmRegistration frm = null;
        private FrmSearch fs = null;
        private string _typeUser = "";


        public FrmPrincipal()
        {
            InitializeComponent();
        }

        public FrmPrincipal(FrmLogin frmLogin)
        {
            InitializeComponent();
            this.frmLogin = frmLogin;
            SetActionsByUserType(frmLogin.CmbTypeUser.SelectedIndex);
            CreateStatusBar();
        }

        private void SetActionsByUserType(int index)
        {
            switch (index)
            {
                case 1:
                    _typeUser = "Administrator";
                    this.administrationToolStripMenuItem.Visible = true;
                    break;
                case 0:
                    _typeUser = "User";
                    this.administrationToolStripMenuItem.Visible = false;
                    break;
            }
        }

        public void CreateStatusBar()
        {
            StatusBar statusBar1 = new StatusBar();
            StatusBarPanel panel1 = new StatusBarPanel();
            StatusBarPanel panel2 = new StatusBarPanel();

            panel1.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            panel1.Text = "User Logged:" + " " + String.Format("{0} - {1}", frmLogin.TxtUser.Text, _typeUser);
            panel1.Alignment = HorizontalAlignment.Left;
            panel1.AutoSize = StatusBarPanelAutoSize.Spring;

            panel2.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            panel2.Text = "Login Datetime:" + " " + DateTime.Now;
            panel2.Alignment = HorizontalAlignment.Right;
            panel2.AutoSize = StatusBarPanelAutoSize.Spring;

            statusBar1.ShowPanels = true;

            statusBar1.Panels.Add(panel1);
            statusBar1.Panels.Add(panel2);

            this.Controls.Add(statusBar1);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registrationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm = new FrmRegistration();
            frm.ShowDialog(this);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fs = new FrmSearch();
            fs.ShowDialog(this);
        }

        private void FrmPrincipal_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info; //Shows the info icon so the user doesn't thing there is an error.
                this.notifyIcon.BalloonTipText = "The system is still active.";
                this.notifyIcon.BalloonTipTitle = "Registration System 2.0-beta";
                this.notifyIcon.Icon = new Icon("../../gear.ico");
                this.notifyIcon.Text = "Registration System 2.0-beta";
                notifyIcon.ShowBalloonTip(3000);
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to leave the system?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case System.Windows.Forms.DialogResult.Yes:
                    Environment.Exit(0);
                    break;
                case System.Windows.Forms.DialogResult.No:
                    this.ShowInTaskbar = false;
                    notifyIcon.Visible = true;
                    e.Cancel = true;
                    this.WindowState = FormWindowState.Minimized;
                    break;
                default:
                    break;
            }
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fro = new FrmReportOptions();
            fro.ShowDialog(this);
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUser frmUser = new FrmUser();
            frmUser.ShowDialog(this);
        }

        private void systemLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLog frmLog = new FrmLog();
            frmLog.ShowDialog(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog(this);
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = @"help/help.chm";
            try
            {
                if (File.Exists(path))
                {
                    FileInfo fileInfo = new FileInfo(path);
                    Process.Start(fileInfo.FullName);  
                }
                else
                {
                    MessageBox.Show("Not found help file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error opening help file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
