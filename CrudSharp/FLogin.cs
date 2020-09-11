﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using LibCrud;

namespace CrudSharp
{
    public partial class FrmLogin : Form
    {
        private FrmConfigDB frmConfigDB = null;
        private FrmSplash frmSplash = null;

        public FrmLogin()
        {
            InitializeComponent();
        }

        public FrmLogin(FrmSplash frmSplash)
        {
            InitializeComponent();
            this.frmSplash = frmSplash;
        }

        public FrmLogin(FrmConfigDB frmConfigDB)
        {
            InitializeComponent();
            this.frmConfigDB = frmConfigDB;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want exit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FrmPrincipal frmPrincipal = new FrmPrincipal(this);
            this.Hide();
            frmPrincipal.ShowDialog(this);
            this.Close();
        }

        private bool CheckContainText(TextBox textBox, string text)
        {
            return textBox.Text.Contains(text);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (CheckContainText(this.txtUsername, " "))
            {
                this.txtUsername.Clear();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (CheckContainText(this.txtPassword, " "))
            {
                this.txtPassword.Clear();
            }
        }

        private void btnDBConfig_Click(object sender, EventArgs e)
        {
            ConfigurationDatabase configDB = new ConfigurationDatabase();
            if (configDB.GetConnectionConfiguration() == null)
            {
                this.Hide();
                FrmSelectDB frmSelectDB = new FrmSelectDB(this);
                frmSelectDB.ShowDialog(this);
            }
            else
            {
                this.Hide();
                FrmConfigDB frmConfigDB = new FrmConfigDB();
                frmConfigDB.frmLogin = this;
                frmConfigDB.ShowDialog(this);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            ConfigurationDatabase configDB = new ConfigurationDatabase();
            this.btnLogin.Enabled = (configDB.GetConnectionConfiguration() != null);
        }
    }
}
