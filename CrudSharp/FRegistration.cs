using LibCrud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CrudSharp
{
    public partial class FrmRegistration : Form
    {
        private string _cpf = "";
        private string _salary = "";
        private char _gender;
        private string _cnpj = "";
        private FrmSearch _frmSearch = null;
        private bool _lockTab = true;
        private int _id = 0;
        private DateTime _birthday;
        private bool _question = true;

        public FrmRegistration()
        {
            InitializeComponent();
            tabPerson.SelectedTab = tabPagePhysicalPerson;
            this.ClearForm();
            SetMaskEvents(txtSalary);
        }

        public FrmRegistration(FrmSearch frmSearch)
        {
            InitializeComponent();
            this.ClearForm();
            SetMaskEvents(txtSalary);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            _frmSearch = new FrmSearch(this, (tabPerson.SelectedTab == tabPagePhysicalPerson));
            _frmSearch.ShowDialog(this);
        }

        private void btnClearPP_Click(object sender, EventArgs e)
        {
            this.ClearFormButton();
        }

        private void ClearForm()
        {
            foreach (Control control in tabPagePhysicalPerson.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).Clear();
                }
            }

            foreach (Control control in tabPageJuridicalPerson.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).Clear();
                }
            }

            this.rdActiveJP.Checked = true;
            this.rdActivePP.Checked = true;
            this.rdMale.Checked = true;
            this.dtBirthday.Value = DateTime.Now.AddYears(-18);
            this.dtBirthday.MaxDate = DateTime.Now.AddYears(-18).AddDays(1);
            this.mskTextCNPJ.Clear();
            this.mskTextCPF.Clear();
            this.mskTextCNPJ.Enabled = true;
            this.mskTextCPF.Enabled = true;
            _lockTab = false;
            _question = true;

            if (tabPerson.SelectedTab == tabPagePhysicalPerson)
                this.mskTextCPF.Focus();
            else
                this.mskTextCNPJ.Focus();

            EnableButtons(OptionsButtons.Include);
        }

        private void btnClearJP_Click(object sender, EventArgs e)
        {
            this.ClearFormButton();
        }

        private void ClearFormButton()
        {
            DialogResult result;

            result = MessageBox.Show("Do you want clear the form?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.ClearForm();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            object result;
            Facade facade = Facade.FacadeInstance;
            ClearFormatting();
            if (CheckIfNotEmptyFromTabPage(tabPerson.SelectedTab))
            {
                if (tabPerson.SelectedTab == tabPagePhysicalPerson)
                    result = facade.InsertPhysicalPerson(_cpf, txtNamePP.Text, txtEmailPP.Text, (decimal.Parse(_salary) / 100), _birthday, _gender, txtCommentPP.Text, rdActivePP.Checked);
                else
                    result = facade.InsertJuridicalPerson(_cnpj, txtNameJP.Text, txtCompanyName.Text, txtEmailJP.Text, txtCommentJP.Text, rdActiveJP.Checked);

                if (result.Equals(1))
                {
                    MessageBox.Show("Successfully created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ClearForm();
                }
                else
                {
                    MessageBox.Show(result.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("There are one or more empty fields", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool CheckRegex(TextBox textBox, string regex)
        {
            Regex rx = new Regex(@regex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rx.IsMatch(textBox.Text);
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
        }

        private void SetMask(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            try
            {
                txt.Text = decimal.Parse(txt.Text).ToString("C2");
            }
            catch (Exception)
            {
                txt.Text = decimal.Parse("0").ToString("C2");
            }
        }

        private void TakeOffMask(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = txt.Text.Replace("R$", "").Trim();
        }

        private void OnlyNumber(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txt.Text.Contains(','));
                }
                else
                    e.Handled = true;
            }
        }

        private void SetMaskEvents(TextBox txt)
        {
            txt.Enter += TakeOffMask;
            txt.Leave += SetMask;
            txt.KeyPress += OnlyNumber;
        }

        public bool CheckIfNotEmptyFromTabPage(TabPage tabPage)
        {
            bool result = true;

            foreach (Control control in tabPage.Controls)
            {
                if (control is TextBox)
                {
                    string var1 = (control as TextBox).Text;

                    if (((control as TextBox).Text == string.Empty) || ((control as TextBox).Text == "R$ 0,00"))
                    {
                        result = false;
                    }
                }

                if (control is MaskedTextBox)
                {
                    string var2 = (control as MaskedTextBox).Text.Replace(",", "").Replace("-", "").Replace("/", "").Trim();

                    if ((control as MaskedTextBox).Text.Replace(",", "").Replace("-", "").Replace("/", "").Trim() == string.Empty)
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        public void ClearFormatting()
        {
            _salary = txtSalary.Text.Replace("R$", "").Replace(".", "").Replace(",", ".").Trim();
            _cpf = mskTextCPF.Text.Replace(",", "").Replace("-", "").Trim();
            _gender = rdMale.Checked ? 'M' : 'F';
            _cnpj = mskTextCNPJ.Text.Replace(",", "").Replace("/", "").Replace("-", "").Trim();
            _birthday = dtBirthday.Value;
        }

        private void tabPerson_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_lockTab)
            {
                e.Cancel = true;
            }
            else
            {
                if(_question)
                {
                    DialogResult result;

                    if (tabPerson.SelectedTab == tabPagePhysicalPerson)
                        result = MessageBox.Show("Do you want go to Physical Person tab?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    else
                        result = MessageBox.Show("Do you want go to Juridical Person tab?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                        this.ClearForm();
                    else
                        e.Cancel = true;
                }
            }
        }

        public void SetPersonData(PersonFacade personFacade)
        {
            this.ClearForm();
            _id = personFacade.Id;
            _question = false;
            if (string.IsNullOrEmpty(personFacade.CNPJ))
            {
                tabPerson.SelectedTab = tabPagePhysicalPerson;
                mskTextCPF.Enabled = false;
                mskTextCPF.Text = personFacade.CPF;
                txtNamePP.Text = personFacade.Name;
                txtEmailPP.Text = personFacade.Email;
                txtSalary.Text = personFacade.Salary.ToString("C2");
                dtBirthday.Value = personFacade.Birthday;
                rdMale.Checked = (personFacade.Gender == 77) ? true : false;
                rdFemale.Checked = (personFacade.Gender == 70) ? true : false;
                txtCommentPP.Text = personFacade.Comment;
                rdActivePP.Checked = personFacade.Status;
                rdInactivePP.Checked = !personFacade.Status;
            }
            else
            {
                tabPerson.SelectedTab = tabPageJuridicalPerson;
                mskTextCNPJ.Enabled = false;
                mskTextCNPJ.Text = personFacade.CNPJ;
                txtNameJP.Text = personFacade.Name;
                txtEmailJP.Text = personFacade.Email;
                txtCompanyName.Text = personFacade.CompanyName;
                txtCommentJP.Text = personFacade.Comment;
                rdActiveJP.Checked = personFacade.Status;
                rdInactiveJP.Checked = !personFacade.Status;
            }
            _lockTab = true;
            _question = true;
            EnableButtons(OptionsButtons.EditAndDelete);
        }

        public enum OptionsButtons
        {
            Include,
            EditAndDelete
        }

        public void EnableButtons(OptionsButtons option)
        {
            if (option == OptionsButtons.Include)
            {
                btnInsert.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }

            if (option == OptionsButtons.EditAndDelete)
            {
                btnInsert.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want edit this record?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                object result;
                Facade facade = Facade.FacadeInstance;
                ClearFormatting();
                if (CheckIfNotEmptyFromTabPage(tabPerson.SelectedTab))
                {
                    if (tabPerson.SelectedTab == tabPagePhysicalPerson)
                        result = facade.EditPhysicalPerson(_id, txtNamePP.Text, txtEmailPP.Text, (decimal.Parse(_salary) / 100), dtBirthday.Value, _gender, txtCommentPP.Text, rdActivePP.Checked);
                    else
                        result = facade.EditJuridicalPerson(_id, txtNameJP.Text, txtCompanyName.Text, txtEmailJP.Text, txtCommentJP.Text, rdActiveJP.Checked);

                    if (result.Equals(1))
                        MessageBox.Show("Successfully edited.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(result.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("There are one or more empty fields", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want delete this record?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                object result;
                Facade facade = Facade.FacadeInstance;
                if (!_id.Equals(0))
                {
                    if (tabPerson.SelectedTab == tabPagePhysicalPerson)
                        result = facade.DeletePhysicalPerson(_id);
                    else
                        result = facade.DeleteJuridicalPerson(_id);

                    if (result.Equals(1))
                    {
                        MessageBox.Show("Successfully deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ClearForm();
                    }
                    else
                    {
                        MessageBox.Show(result.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("There are one or more empty fields", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
