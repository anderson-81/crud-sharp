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
        }

        private void FrmReportOptions_Load(object sender, EventArgs e)
        {
            this.gpBornMonth.Visible = false;
            this.gpBySalary.Visible = false;
            this.gpSalaryRange.Visible = true;
            this.gpAVGSal.Visible = false;
            this.cmbAVG.SelectedIndex = 0;
            this.cmbMonth.SelectedIndex = 0;
            this.cmbSal.SelectedIndex = 0;
        }

        private void txtInitialSal_TextChanged(object sender, EventArgs e)
        {
            if(this.txtInitialSal.Text != String.Empty)
            {
                try
                {
                    Decimal.Parse(this.txtInitialSal.Text);
                }
                catch (Exception)
                {
                    this.txtInitialSal.Clear();
                }
            }
        }

        private void txtFinalInitial_TextChanged(object sender, EventArgs e)
        {
            if (this.txtFinalInitial.Text != String.Empty)
            {
                try
                {
                    Decimal.Parse(this.txtFinalInitial.Text);
                }
                catch (Exception)
                {
                    this.txtFinalInitial.Clear();
                }
            }
        }

        private void rdSalaryRange_CheckedChanged(object sender, EventArgs e)
        {
            this.gpBornMonth.Visible = false;
            this.gpBySalary.Visible = false;
            this.gpSalaryRange.Visible = true;
            this.gpAVGSal.Visible = false;
            this.cmbAVG.SelectedIndex = 0;
            this.cmbMonth.SelectedIndex = 0;
            this.cmbSal.SelectedIndex = 0;
        }

        private void rdAverageWage_CheckedChanged(object sender, EventArgs e)
        {
            this.gpBornMonth.Visible = false;
            this.gpBySalary.Visible = false;
            this.gpSalaryRange.Visible = false;
            this.gpAVGSal.Visible = true;
            this.cmbAVG.SelectedIndex = 0;
            this.cmbMonth.SelectedIndex = 0;
            this.cmbSal.SelectedIndex = 0;
        }

        private void rdBySalary_CheckedChanged(object sender, EventArgs e)
        {
            this.gpBornMonth.Visible = false;
            this.gpBySalary.Visible = true;
            this.gpSalaryRange.Visible = false;
            this.gpAVGSal.Visible = false;
            this.cmbAVG.SelectedIndex = 0;
            this.cmbMonth.SelectedIndex = 0;
            this.cmbSal.SelectedIndex = 0;
        }

        private void rdBornMonth_CheckedChanged(object sender, EventArgs e)
        {
            this.gpBornMonth.Visible = true;
            this.gpBySalary.Visible = false;
            this.gpSalaryRange.Visible = false;
            this.gpAVGSal.Visible = false;
            this.cmbAVG.SelectedIndex = 0;
            this.cmbMonth.SelectedIndex = 0;
            this.cmbSal.SelectedIndex = 0;
        }

        private void rdAll_CheckedChanged(object sender, EventArgs e)
        {
            this.gpBornMonth.Visible = false;
            this.gpBySalary.Visible = false;
            this.gpSalaryRange.Visible = false;
            this.gpAVGSal.Visible = false;
            this.cmbAVG.SelectedIndex = 0;
            this.cmbMonth.SelectedIndex = 0;
            this.cmbSal.SelectedIndex = 0;
        }

        private void rdfinancialGeneral_CheckedChanged(object sender, EventArgs e)
        {
            this.gpBornMonth.Visible = false;
            this.gpBySalary.Visible = false;
            this.gpSalaryRange.Visible = false;
            this.gpAVGSal.Visible = false;
            this.cmbAVG.SelectedIndex = 0;
            this.cmbMonth.SelectedIndex = 0;
            this.cmbSal.SelectedIndex = 0;
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
            this.txtFinalInitial.BackColor = Color.Yellow;
        }

        private void txtFinalInitial_Leave(object sender, EventArgs e)
        {
            this.txtFinalInitial.BackColor = Color.White;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if(rdSalaryRange.Checked)
            {
                if (this.txtInitialSal.Text != String.Empty)
                {
                    if (this.txtFinalInitial.Text != String.Empty)
                    {
                        GenerateSalaryRangeReport();
                    }
                    else
                    {
                        MessageBox.Show("Final salary was not informed.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Initial salary was not informed.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if (rdBySalary.Checked)
            {
                GeneraterSalaryReport();
            }

            if(rdAverageWage.Checked)
            {
                GeneraterAverageWageReport();
            }

            if(rdAll.Checked)
            {
                GeneraterPhysicalPersonReport();
            }

            if(rdBornMonth.Checked)
            {
                GeneraterBornMonth();
            }
        }

        private void GenerateSalaryRangeReport()
        {
           
        }

        private void GeneraterSalaryReport()
        {
          
        }

        private void GeneraterAverageWageReport()
        {
           
        }

        private void GeneraterPhysicalPersonReport()
        {
           
        }

        private void GeneraterBornMonth()
        {
            
        }
    }
}
