using LibCrud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudSharp
{
    public partial class FrmConfigDB : Form
    {
        private FrmSelectDB frmSelectDB = null;
        public FrmLogin frmLogin = null;
        private int dbSelectedIndex = 0;
        
        public FrmConfigDB()
        {
            InitializeComponent();
        }

        public FrmConfigDB(FrmSelectDB frmSelectDB, int dbSelectedIndex)
        {
            InitializeComponent();
            this.frmSelectDB = frmSelectDB;
            this.dbSelectedIndex = dbSelectedIndex;
            this.ShowConfiguration(dbSelectedIndex);
        }

        public FrmConfigDB(FrmSelectDB frmSelectDB, FrmLogin frmLogin, int dbSelectedIndex)
        {
            InitializeComponent();
            this.frmSelectDB = frmSelectDB;
            this.frmLogin = frmLogin;
            this.dbSelectedIndex = dbSelectedIndex;
            this.ShowConfiguration(dbSelectedIndex);
        }

        public void ShowConfiguration(int id)
        {
            if(id == 0)
            {
                SetGroupBoxShow(gpConfiguration01, false);
                SetGroupBoxShow(gpConfiguration02, true);
            }
            else
            {
                SetGroupBoxShow(gpConfiguration02, false);
                SetGroupBoxShow(gpConfiguration01, true);
            }
        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(this.txtPort.Text);
            }
            catch (Exception)
            {
                this.txtPort.Clear();
            }
        }

        private void Clear()
        {
            foreach(Control ctr in this.Controls)
            {
                if(ctr is TextBox)
                {
                    ctr.Text = String.Empty;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.DeleteConfiguration();
        }

        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {
            if(CheckContainText(this.txtDatabase, " "))
            {
                this.txtDatabase.Clear();
            }
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

        private bool CheckContainText(TextBox textBox, string text)
        {
            return textBox.Text.Contains(text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(gpConfiguration01.Visible)
                {
                    if (CheckIfFieldIsEmpty())
                    {
                        ConfigurationDatabase configDB = new ConfigurationDatabase(GetDatabaseName(), txtDatabase.Text, txtHostname.Text, ushort.Parse(txtPort.Text), txtUsername.Text, txtPassword.Text, "");
                        bool result = configDB.CreateConfiguration();
                        if (result)
                        {
                            MessageBox.Show("Successfully created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmLogin = new FrmLogin(this);
                            this.Hide();
                            frmLogin.ShowDialog(this);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("One or more fields are empty or have invalid data.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("There are one or more empty fields.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (CheckIfFieldIsEmpty())
                    {
                        ConfigurationDatabase configDB = new ConfigurationDatabase(GetDatabaseName(), @txtPath.Text, "", 0, "", "", "");
                        bool result = configDB.CreateConfiguration();
                        if (result)
                        {
                            MessageBox.Show("Successfully created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmLogin = new FrmLogin(this);
                            this.Hide();
                            frmLogin.ShowDialog(this);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("The path to sqlite database is empty.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The path to sqlite database is empty.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error saving database connection configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetGroupBoxShow(GroupBox gp, bool show)
        {
            gp.Visible = show;
        }

        private ConfigurationDatabase.DatabaseName GetDatabaseName()
        {
            if (dbSelectedIndex == 1)
                return ConfigurationDatabase.DatabaseName.PostgreSQL;
            if (dbSelectedIndex == 2)
                return ConfigurationDatabase.DatabaseName.SQLServer;
            if (dbSelectedIndex == 3)
                return ConfigurationDatabase.DatabaseName.MySQL;

            return ConfigurationDatabase.DatabaseName.SQLite;
        }

        private void FrmConfigDB_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.frmLogin != null)
            {
                this.frmLogin.Show();
            }
        }

        private bool CheckIfFieldIsEmpty()
        {
            if (this.gpConfiguration01.Visible)
            {
                foreach (Control control in gpConfiguration01.Controls)
                {
                    if(control is TextBox)
                    {
                        if ((control as TextBox).Text == String.Empty)
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                if (this.txtPath.Text == String.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        private void GetConnectionConfiguration()
        {
            ConfigurationDatabase configDB = new ConfigurationDatabase().GetConnectionConfiguration();
            if(configDB != null)
            {
                if (configDB.hostname != string.Empty)
                    this.gpConfiguration01.Visible = true;
                else
                    this.gpConfiguration02.Visible = true;

                if (this.gpConfiguration01.Visible)
                {
                    txtDatabase.Text = configDB.database;
                    txtHostname.Text = configDB.hostname;
                    txtPort.Text = configDB.port.ToString();
                    txtUsername.Text = configDB.username;
                    txtPassword.Text = configDB.password;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = true;

                    foreach (Control control in gpConfiguration01.Controls)
                    {
                        if (control is TextBox)
                        {
                            (control as TextBox).Enabled = false;
                        }
                    }
                }
                else
                {
                    txtPath.Text = configDB.database;
                    btnBrowser.Enabled = false;
                    this.txtPath.ReadOnly = true;
                }
                btnSave.Enabled = false;
                btnCreateTables1.Enabled = true;
                btnCreateTables2.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnCreateTables1.Enabled = false;
                btnCreateTables2.Enabled = false;
                btnSave.Enabled = true;
            }
        }

        private void FrmConfigDB_Load(object sender, EventArgs e)
        {
            this.GetConnectionConfiguration();
        }

        private void DeleteConfiguration()
        {
            DialogResult result = MessageBox.Show("Do you want delete the database connection configuration?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    if (gpConfiguration01.Visible)
                    {
                        foreach (Control control in gpConfiguration01.Controls)
                        {
                            if (control is TextBox)
                            {
                                (control as TextBox).Enabled = true;
                                (control as TextBox).Clear();
                            }
                        }
                    }
                    else
                    {
                        txtPath.Clear();
                        btnBrowser.Enabled = true;
                    }

                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;

                    File.Delete("database.xml");
                    MessageBox.Show("Successfully deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("There is no configuration for connecting to the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("The system will be closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                    if(frmLogin != null)
                    {
                        frmLogin.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error deleting database connection configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
        }

        private void btnCreateTables2_Click(object sender, EventArgs e)
        {
            CreateTables();
        }

        private void CreateTables()
        {
            DialogResult dialogResult = MessageBox.Show("Do you want create the system tables?" + Environment.NewLine + "Existing tables will be deleted.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Facade facade = Facade.FacadeInstance;
                object result = facade.CreateTables();
                if(result.Equals(1))
                    MessageBox.Show("Successfully created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error creating system tables.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateTables1_Click(object sender, EventArgs e)
        {
            CreateTables();
        }

        private void btnCreateTables2_Click_1(object sender, EventArgs e)
        {
            CreateTables();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtPath.Text = openFileDialog.FileName;
            }
        }
    }
}