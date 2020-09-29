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
    public partial class FrmReportOptions : Form
    {
        public FrmReportOptions()
        {
            InitializeComponent();
            ClearForm(this.gpSalaryRange);
        }

        private void ClearForm(GroupBox groupBoxParam)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TabControl)
                {
                    foreach (Control tabCtrItem in control.Controls)
                    {
                        if (tabCtrItem is TabPage)
                        {
                            foreach (Control tabPageItem in tabCtrItem.Controls)
                            {
                                if (tabPageItem is GroupBox)
                                {
                                    if ((((GroupBox)tabPageItem) == gpOptionsPP) || (((GroupBox)tabPageItem) == gpOptionsJP))
                                    {
                                        ((GroupBox)tabPageItem).Visible = true;
                                    }
                                    else
                                    {
                                        ((GroupBox)tabPageItem).Visible = false;
                                    }

                                    foreach (Control gpItem in tabPageItem.Controls)
                                    {
                                        if (gpItem is TextBox)
                                        {
                                            ((TextBox)gpItem).Clear();
                                        }

                                        if (gpItem is ComboBox)
                                        {
                                            ((ComboBox)gpItem).SelectedIndex = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            SetMaskEvents(txtInitialSal);
            SetMaskEvents(txtFinalSal);
            groupBoxParam.Visible = true;
        }

        private void txtInitialSal_Enter(object sender, EventArgs e)
        {
            this.txtInitialSal.BackColor = Color.Yellow;
        }

        private void txtInitialSal_Leave(object sender, EventArgs e)
        {
            this.txtInitialSal.BackColor = Color.White;
        }

        private void txtFinalInitial_Enter(object sender, EventArgs e)
        {
            this.txtFinalSal.BackColor = Color.Yellow;
        }

        private void txtFinalInitial_Leave(object sender, EventArgs e)
        {
            this.txtFinalSal.BackColor = Color.White;
        }

        private void GenerateSalaryRangeReport()
        {
            this.btnGenerate.Focus();
            if((txtInitialSal.Text != string.Empty) && (txtFinalSal.Text != string.Empty))
            {
                ClearFormatting();
                if (_salaryInitial < _salaryFinal)
                {
                    List<PersonFacade> datasource = Facade.FacadeInstance.GetPhysicalPersonBySalaryRange(_salaryInitial, _salaryFinal);
                    
                    if(datasource != null)
                    {
                        if (datasource.Count > 0)
                        {
                            FrmReport frmReport = new FrmReport(new ReportDesignData(ReportDesignData.ReportDesignOption.ReportSalaryRange, datasource));
                            frmReport.ShowDialog(this);
                        }
                        else
                            MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Error generating report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Starting Salary must be less than Final Salary.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("There are empty fields.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void GeneraterSalaryReport()
        {
            Facade.OptionSalary optionSalary;
            optionSalary = optionSalary = Facade.OptionSalary.Lower; 

            switch(cmbSal.SelectedIndex)
            {
                case 0:
                    optionSalary = Facade.OptionSalary.Lower;
                    break;
                case 1:
                    optionSalary = Facade.OptionSalary.Higher;
                    break;
            }

            PersonFacade datasource = Facade.FacadeInstance.GetPhysicalPersonBySalary(optionSalary);
            if(datasource != null)
            {
                if (!string.IsNullOrEmpty(datasource.CPF))
                {
                    FrmReport frmReport = new FrmReport(new ReportDesignData(ReportDesignData.ReportDesignOption.ReportBySalary, datasource));
                    frmReport.ShowDialog(this);
                }
                else
                    MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error generating report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void GeneraterAverageWageReport()
        {
            Facade.OptionAVGSalary optionAVGSalary;
            optionAVGSalary = Facade.OptionAVGSalary.Under;

            switch (cmbAVG.SelectedIndex)
            {
                case 0:
                    optionAVGSalary = Facade.OptionAVGSalary.Under;
                    break;
                case 1:
                    optionAVGSalary = Facade.OptionAVGSalary.Equal;
                    break;
                case 2:
                    optionAVGSalary = Facade.OptionAVGSalary.Above;
                    break;
            }

            List<PersonFacade> datasource = Facade.FacadeInstance.GetPhysicalPersonByAVGSalary(optionAVGSalary);

            if(datasource != null)
            {
                if (datasource.Count > 0)
                {
                    FrmReport frmReport = new FrmReport(new ReportDesignData(ReportDesignData.ReportDesignOption.ReportAverageWaze, datasource));
                    frmReport.ShowDialog(this);
                }
                else
                    MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error generating report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void GeneraterPhysicalPersonReport()
        {
            List<PersonFacade> datasource = Facade.FacadeInstance.GetPersonByName("", Facade.OptionPerson.PhysicalPersonOption);

            if (datasource != null)
            {
                if(datasource.Count > 0)
                {
                    FrmReport frmReport = new FrmReport(new ReportDesignData(ReportDesignData.ReportDesignOption.ReportPhysicalPerson, datasource));
                    frmReport.ShowDialog(this);
                }
                else
                    MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error generating report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void GeneraterBornMonth()
        {
            List<PersonFacade> datasource = Facade.FacadeInstance.GetPhysicalPersonByBirthMonth(cmbMonth.SelectedIndex + 1);
            if (datasource != null)
            {
                if(datasource.Count > 0)
                {
                    FrmReport frmReport = new FrmReport(new ReportDesignData(ReportDesignData.ReportDesignOption.ReportByMonth, datasource));
                    frmReport.ShowDialog(this);
                }
                else
                    MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error generating report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            this.Hide();

            if(tabPerson.SelectedTab == tabPageJuridicalPerson)
            {
                rdAllJuridicalPerson.Checked = true;

                GeneraterJuridicalPersonReport();
            }
            else
            {
                if (rdSalaryRange.Checked)
                {
                    GenerateSalaryRangeReport();
                }

                if (rdBySalary.Checked)
                {
                    GeneraterSalaryReport();
                }

                if (rdAverageWage.Checked)
                {
                    GeneraterAverageWageReport();
                }

                if (rdAllPhysicalPerson.Checked)
                {
                    GeneraterPhysicalPersonReport();
                }

                if (rdBornMonth.Checked)
                {
                    GeneraterBornMonth();
                }
            }

            this.Show();
        }

        private void GeneraterJuridicalPersonReport()
        {
            List<PersonFacade> datasource = Facade.FacadeInstance.GetPersonByName("", Facade.OptionPerson.JuridicalPersonOption);
            if (datasource != null)
            {
                FrmReport frmReport = new FrmReport(new ReportDesignData(ReportDesignData.ReportDesignOption.ReportJuridicalPerson, datasource));
                frmReport.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rdSalaryRange_CheckedChanged(object sender, EventArgs e)
        {
            ClearForm(this.gpSalaryRange);
        }

        private void rdAverageWage_CheckedChanged(object sender, EventArgs e)
        {
            ClearForm(this.gpAVGSal);
        }

        private void rdBySalary_CheckedChanged(object sender, EventArgs e)
        {
            ClearForm(this.gpBySalary);
        }

        private void rdBornMonth_CheckedChanged(object sender, EventArgs e)
        {
            ClearForm(this.gpBornMonth);
        }

        private void rdAllPhysicalPerson_CheckedChanged(object sender, EventArgs e)
        {
            ClearForm(this.gpOptionsPP);
        }

        private void rdAllJuridicalPerson_CheckedChanged(object sender, EventArgs e)
        {
            ClearForm(this.gpOptionsJP);
        }

        #region Mask
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

        private decimal _salaryInitial = 0;
        private decimal _salaryFinal = 0;

        public void ClearFormatting()
        {
            _salaryInitial = decimal.Parse(txtInitialSal.Text.Replace("R$", "").Replace(".", "").Replace(".", ",").Trim());
            _salaryFinal = decimal.Parse(txtFinalSal.Text.Replace("R$", "").Replace(".", "").Replace(".", ",").Trim());
        }
        #endregion
    }
}
