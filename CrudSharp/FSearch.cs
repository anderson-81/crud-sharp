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
    public partial class FrmSearch : Form
    {
        private FrmRegistration _frmRegistration = null;
        private bool _p;

        private enum OptionOfPersonRegister
        {
            PhysicalPerson,
            JuridicalPerson
        }

        public FrmSearch()
        {
            InitializeComponent();
            this.tabSearch.SelectedTab = tabPagePhysicalPerson;
            ConfigureDataGridViewForTypeOfPerson();
        }

        public FrmSearch(bool result)
        {
            InitializeComponent();
            this.tabSearch.SelectedTab = result ? this.tabPagePhysicalPerson : this.tabPageJuridicalPerson;
            ConfigureDataGridViewForTypeOfPerson();
        }

        public FrmSearch(FrmRegistration frmRegistration, bool result)
        {
            InitializeComponent();
            this._frmRegistration = frmRegistration;
            this.tabSearch.SelectedTab = result ? this.tabPagePhysicalPerson : this.tabPageJuridicalPerson;
            ConfigureDataGridViewForTypeOfPerson();
        }

        private void btnSearchPP_Click(object sender, EventArgs e)
        {
            Search();
        }

        private string GetPersonRegisterClean(OptionOfPersonRegister option)
        {
            string clean = "";

            switch (option)
            {
                case OptionOfPersonRegister.PhysicalPerson:
                    clean = mskTextCPF.Text.Replace(",", "").Replace("-", "").Trim();
                    break;
                case OptionOfPersonRegister.JuridicalPerson:
                    clean = mskTextCNPJ.Text.Replace(",", "").Replace("/", "").Replace("-", "").Trim();
                    break;
            }

            return clean;
        }

        private void rdCPF_CheckedChanged(object sender, EventArgs e)
        {
            mskTextCPF.Visible = true;
            txtSearchPP.Visible = false;
            ClearAndHideDataGridView();
        }

        private void rdForNamePP_CheckedChanged(object sender, EventArgs e)
        {
            mskTextCPF.Visible = false;
            txtSearchPP.Visible = true;
            ClearAndHideDataGridView();
        }

        private void rdForNameJP_CheckedChanged(object sender, EventArgs e)
        {
            mskTextCNPJ.Visible = false;
            txtSearchJP.Visible = true;
            ClearAndHideDataGridView();
        }

        private void rdForCNPJ_CheckedChanged(object sender, EventArgs e)
        {
            mskTextCNPJ.Visible = true;
            txtSearchJP.Visible = false;
            ClearAndHideDataGridView();
        }

        private void tabSearch_Selecting(object sender, TabControlCancelEventArgs e)
        {
            this.ClearForm(e.TabPage);
            ClearAndHideDataGridView();
            ConfigureDataGridViewForTypeOfPerson();
        }

        private void ClearAndHideDataGridView()
        {
            this.dgvPerson.DataSource = null;
            this.dgvPerson.Visible = false;
        }

        private void ClearForm(TabPage tabPage)
        {
            if (tabPage == tabPagePhysicalPerson)
            {
                this.rdForNamePP.Checked = true;
                mskTextCPF.Clear();
                mskTextCPF.Visible = false;
                txtSearchPP.Clear();
                txtSearchPP.Visible = true;

            }
            else
            {
                this.rdForNameJP.Checked = true;
                mskTextCNPJ.Clear();
                mskTextCNPJ.Visible = false;
                txtSearchJP.Clear();
                txtSearchJP.Visible = true;
            }
        }

        private void btnSearchJP_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            this.Enabled = false;
            this.dgvPerson.AutoGenerateColumns = false;
            this.dgvPerson.Visible = false;
            this.dgvPerson.DataSource = null;
            bool execute = false;
            PersonFacade pf = null;

            Facade facade = Facade.FacadeInstance;
            if (tabSearch.SelectedTab == tabPagePhysicalPerson)
            {
                if (rdForCPF.Checked)
                {
                    if (GetPersonRegisterClean(OptionOfPersonRegister.PhysicalPerson) != string.Empty)
                    {
                        execute = true;
                        pf = facade.GetPhysicalPersonByCPF(GetPersonRegisterClean(OptionOfPersonRegister.PhysicalPerson));
                        if(pf != null)
                        {
                            this.dgvPerson.DataSource = new List<PersonFacade> { pf };
                        }
                    }
                    else
                        MessageBox.Show("No CPF was informed.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    execute = true;
                    this.dgvPerson.DataSource = facade.GetPersonByName(txtSearchPP.Text, Facade.OptionPerson.PhysicalPersonOption);
                }
            }

            if (tabSearch.SelectedTab == tabPageJuridicalPerson)
            {
                if (rdForCNPJ.Checked)
                {
                    if (GetPersonRegisterClean(OptionOfPersonRegister.JuridicalPerson) != string.Empty)
                    {
                        execute = true;
                        pf = facade.GetJuridicalPersonByCNPJ(GetPersonRegisterClean(OptionOfPersonRegister.JuridicalPerson));
                        if (pf != null)
                        {
                            this.dgvPerson.DataSource = new List<PersonFacade> { pf };
                        }
                    }
                    else
                        MessageBox.Show("No CNPJ was informed.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    execute = true;
                    this.dgvPerson.DataSource = facade.GetPersonByName(txtSearchJP.Text, Facade.OptionPerson.JuridicalPersonOption);  
                }
            }

            if(execute)
            {
                if (this.dgvPerson.DataSource == null)
                {
                    this.dgvPerson.Visible = false;
                    MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.dgvPerson.Visible = true;
                }
            }
            
            this.Enabled = true;
        }

        private void dgvPerson_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Facade facade = Facade.FacadeInstance;
            bool status = false;

            if (_frmRegistration == null)
            {
                status = true;
                _frmRegistration = new FrmRegistration(this);
            }

            if (tabSearch.SelectedTab == tabPagePhysicalPerson)
                _frmRegistration.SetPersonData(facade.GetPhysicalPersonByID(int.Parse(this.dgvPerson.SelectedRows[0].Cells[0].Value.ToString())));
            else
                _frmRegistration.SetPersonData(facade.GetJuridicalPersonByID(int.Parse(this.dgvPerson.SelectedRows[0].Cells[0].Value.ToString())));

            if(status)
            {
                this.Hide();
                _frmRegistration.ShowDialog(this);
                this.Close();
            }
            else
            {
                _frmRegistration.Show();
                this.Close();
            }
        }

        private void ConfigureDataGridViewForTypeOfPerson()
        {
            if (tabSearch.SelectedTab == tabPagePhysicalPerson)
            {
                dgvPerson.Columns[1].HeaderText = "CPF";
                dgvPerson.Columns[1].DataPropertyName = "CPF";
            }
            else
            {
                dgvPerson.Columns[1].HeaderText = "CNPJ";
                dgvPerson.Columns[1].DataPropertyName = "CNPJ";
            }
        }
    }
}
