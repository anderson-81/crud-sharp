using LibCrud;
using LibCrud.Facades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudSharp
{
    public partial class FrmUser : Form
    {
        private int _id = 0;
        private int _rowSelected = 0;

        public FrmUser()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want clear the form?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                ToggleForm(OptionForm.Clear);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (CheckIfNotHaveEmptyFields())
            {
                Facade facade = Facade.FacadeInstance;
                object result = facade.InsertUser(txtName.Text, txtUsername.Text, txtPassword.Text, (cmbTypeUser.SelectedIndex == 0 ? Facade.UserType.User : Facade.UserType.Administrator));
                if (result.Equals(1))
                {
                    MessageBox.Show("Successfully created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ToggleForm(OptionForm.Clear);
                }
                else
                    MessageBox.Show(result.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("There are empty fields on the form.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            this.Enabled = true;
        }

        private bool CheckIfNotHaveEmptyFields()
        {
            if (new StackTrace().GetFrame(1).GetMethod().Name != "btnDelete_Click")
            {
                if (txtName.Text != string.Empty)
                {
                    if (txtUsername.Text != string.Empty)
                    {
                        if (txtPassword.Text != string.Empty)
                        {
                            if (cmbTypeUser.Text != string.Empty)
                            {
                                if (new StackTrace().GetFrame(1).GetMethod().Name != "btnInsert_Click")
                                {
                                    if (_id > 0)
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (_id > 0)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckIfNotMatchWithRegex(TextBox textBox)
        {
            return !Regex.IsMatch(textBox.Text, @"^[a-zA-Z0-9]*$");
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            SetSender(sender);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            SetSender(sender);
        }

        private void SetSender(object sender)
        {
            if (((TextBox)sender).Text != string.Empty)
            {
                if (CheckIfNotMatchWithRegex(((TextBox)sender)))
                {
                    ((TextBox)sender).Clear();
                    ((TextBox)sender).Focus();
                }
            }
        }

        private void txtCreateAt_Enter(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void CheckIfContainsSpace(TextBox textBox)
        {
            if (textBox.Text.Contains(" "))
            {
                textBox.Clear();
                textBox.Focus();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            CheckIfContainsSpace(((TextBox)sender));
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            CheckIfContainsSpace(((TextBox)sender));
        }

        private enum OptionForm
        {
            Clear,
            Select
        }

        private void ToggleForm(OptionForm optionForm)
        {
            bool option = true;

            switch (optionForm)
            {
                case OptionForm.Clear:
                    option = true;
                    break;
                case OptionForm.Select:
                    option = false;
                    break;
            }

            btnInsert.Visible = option;
            btnEdit.Visible = !option;
            btnDelete.Visible = !option;
            dataGridViewUser.Visible = !option;
            lblList.Visible = !option;
            txtName.ReadOnly = !option;
            txtName.BackColor = txtName.ReadOnly ? SystemColors.ControlLight : SystemColors.Window;
            txtCreateAt.Visible = !option;
            lblCreateAt.Visible = !option;

            if (option)
            {
                txtName.Clear();
                ClearUsernamePassword();
                cmbTypeUser.SelectedIndex = 0;
                SetFormHeight(470);
                _id = 0;
            }
            else
            {
                ClearUsernamePassword();
                SetFormHeight(620);
            }
        }

        private void ClearUsernamePassword()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void SetFormHeight(int height)
        {
            this.Height = height;
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            ToggleForm(OptionForm.Clear);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            DialogResult dialogResult = MessageBox.Show("Do you want edit this user?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                if (CheckIfThereIsAtLeastOneAdministrator())
                {
                    if (CheckIfNotHaveEmptyFields())
                    {
                        Facade facade = Facade.FacadeInstance;
                        object result = facade.EditUser(_id, txtName.Text, txtUsername.Text, txtPassword.Text, (cmbTypeUser.SelectedIndex == 0 ? Facade.UserType.User : Facade.UserType.Administrator));
                        if (result.Equals(1))
                        {
                            MessageBox.Show("Successfully edited.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            List();
                        }
                        else
                        {
                            MessageBox.Show(result.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            ClearUsernamePassword();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No users were selected.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("At least one Administrator is required.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            this.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            DialogResult dialogResult = MessageBox.Show("Do you want delete this user?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                if (CheckIfThereIsAtLeastOneAdministrator())
                {
                    if (CheckIfNotHaveEmptyFields())
                    {
                        Facade facade = Facade.FacadeInstance;
                        object result = facade.DeleteUser(_id);
                        if (result.Equals(1))
                        {
                            MessageBox.Show("Successfully deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            List();
                        }
                        else
                        {
                            MessageBox.Show(result.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No users were selected.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("At least one Administrator is required.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            this.Enabled = true;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List();
        }

        private void List()
        {
            this.Enabled = false;
            Facade facade = Facade.FacadeInstance;
            List<UserFacade> list = facade.GetUserByName("");
            if (list != null)
            {
                if (list.Count > 0)
                {
                    this.dataGridViewUser.DataSource = list;
                    this.ToggleForm(OptionForm.Select);
                    this.dataGridViewUser.AutoGenerateColumns = false;

                    if (new StackTrace().GetFrame(1).GetMethod().Name == "btnEdit_Click")
                         SetUserData(_rowSelected);
                    else
                         SetUserData(0);
                }
                else
                {
                    MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ToggleForm(OptionForm.Clear);
                }
            }
            else
                MessageBox.Show("Error listing users.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Enabled = true;
        }

        private void dataGridViewUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void SetUserData(int row)
        {
            dataGridViewUser.Rows[row].Selected = true;
            dataGridViewUser.FirstDisplayedScrollingRowIndex = row;
            _id = int.Parse(this.dataGridViewUser.SelectedRows[0].Cells[0].Value.ToString());
            txtName.Text = this.dataGridViewUser.SelectedRows[0].Cells[1].Value.ToString();
            cmbTypeUser.SelectedIndex = int.Parse(this.dataGridViewUser.SelectedRows[0].Cells[4].Value.ToString());
            txtCreateAt.Text = this.dataGridViewUser.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.ReadOnly)
            {
                txtUsername.Focus();
            }
        }

        private bool CheckIfThereIsAtLeastOneAdministrator()
        {
            if (new StackTrace().GetFrame(1).GetMethod().Name == "btnDelete_Click")
            {
                if (cmbTypeUser.SelectedIndex == 1)
                {
                    int cont = 0;
                    foreach (DataGridViewRow row in dataGridViewUser.Rows)
                    {
                        if (row.Cells[4].Value.ToString() == "1")
                        {
                            cont++;
                        }
                    }
                    return cont > 1;
                }
                return true;
            }
            else
            {
                if (dataGridViewUser.Rows.Count == 1)
                {
                    if (cmbTypeUser.SelectedIndex == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void dataGridViewUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetUserData(e.RowIndex);
            _rowSelected = e.RowIndex;
        }
    }
}
