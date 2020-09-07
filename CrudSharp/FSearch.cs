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
        private FrmRegistration freg;
       
        public FrmSearch()
        {
            InitializeComponent();
        }

        public FrmSearch(FrmRegistration freg)
        {
            InitializeComponent();
            this.freg = freg;
        }

        private void txtDataSearch_Load(object sender, EventArgs e)
        {
            ClearSearch();
        }

        private void ClearSearch()
        {
            this.GridPhysicalPerson.Visible = false;
            this.rdName.Checked = true;
            this.txtDataSearch.Clear();
            this.txtDataSearch.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClearGrid();

            if (this.rdCode.Checked)
            {
                if (this.txtDataSearch.Text != String.Empty)
                {
                    if (true)
                    {
                    }
                    else
                    {
                        MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearSearch();
                    }
                }
                else
                    MessageBox.Show("Enter a code to search.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
              
                if (this.GridPhysicalPerson.RowCount > 0)
                {
                    this.GridPhysicalPerson.Visible = true;
                }
                else
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearSearch();
                }
            }
        }

        private void GridPhysicalPerson_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.freg == null)
            {
                this.freg = new FrmRegistration();
            }


            if (!this.freg.Visible)
            {
               this.freg.ShowDialog(this);
            }
        }

        private void txtDataSearch_Enter(object sender, EventArgs e)
        {
            this.txtDataSearch.BackColor = Color.Yellow;
        }

        private void rdCode_CheckedChanged(object sender, EventArgs e)
        {
            ClearGrid();
        }

        private void rdName_CheckedChanged(object sender, EventArgs e)
        {
            ClearGrid();
        }

        private void ClearGrid()
        {
            this.GridPhysicalPerson.Visible = false;
            this.GridPhysicalPerson.DataSource = null;
        }

        private void txtDataSearch_TextChanged(object sender, EventArgs e)
        {
            if(this.rdCode.Checked)
            {
                if(this.txtDataSearch.Text != String.Empty)
                {
                    try
                    {
                        Int32.Parse(this.txtDataSearch.Text);
                    }
                    catch (Exception)
                    {
                        this.txtDataSearch.Clear();
                    }
                }
            }
        }

        private void rdCode_Click(object sender, EventArgs e)
        {
            ClearGrid();
        }

        private void rdName_Click(object sender, EventArgs e)
        {
            ClearGrid();
        }

        private void txtDataSearch_Leave(object sender, EventArgs e)
        {
            this.txtDataSearch.BackColor = Color.White;
        }

    }
}
