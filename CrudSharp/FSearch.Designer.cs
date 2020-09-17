namespace CrudSharp
{
    partial class FrmSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSearch));
            this.tabSearch = new System.Windows.Forms.TabControl();
            this.tabPagePhysicalPerson = new System.Windows.Forms.TabPage();
            this.mskTextCPF = new System.Windows.Forms.MaskedTextBox();
            this.gpOptionsPP = new System.Windows.Forms.GroupBox();
            this.rdForCPF = new System.Windows.Forms.RadioButton();
            this.rdForNamePP = new System.Windows.Forms.RadioButton();
            this.btnSearchPP = new System.Windows.Forms.Button();
            this.lblDataSearchPP = new System.Windows.Forms.Label();
            this.txtSearchPP = new System.Windows.Forms.TextBox();
            this.lblPP = new System.Windows.Forms.Label();
            this.tabPageJuridicalPerson = new System.Windows.Forms.TabPage();
            this.mskTextCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.gpOptionsJP = new System.Windows.Forms.GroupBox();
            this.rdForCNPJ = new System.Windows.Forms.RadioButton();
            this.rdForNameJP = new System.Windows.Forms.RadioButton();
            this.btnSearchJP = new System.Windows.Forms.Button();
            this.lblDataSearchJP = new System.Windows.Forms.Label();
            this.txtSearchJP = new System.Windows.Forms.TextBox();
            this.lblJP = new System.Windows.Forms.Label();
            this.dgvPerson = new System.Windows.Forms.DataGridView();
            this.columnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRegister = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSearch.SuspendLayout();
            this.tabPagePhysicalPerson.SuspendLayout();
            this.gpOptionsPP.SuspendLayout();
            this.tabPageJuridicalPerson.SuspendLayout();
            this.gpOptionsJP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.tabPagePhysicalPerson);
            this.tabSearch.Controls.Add(this.tabPageJuridicalPerson);
            this.tabSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabSearch.Location = new System.Drawing.Point(0, 0);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.SelectedIndex = 0;
            this.tabSearch.Size = new System.Drawing.Size(484, 130);
            this.tabSearch.TabIndex = 13;
            this.tabSearch.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabSearch_Selecting);
            // 
            // tabPagePhysicalPerson
            // 
            this.tabPagePhysicalPerson.Controls.Add(this.mskTextCPF);
            this.tabPagePhysicalPerson.Controls.Add(this.gpOptionsPP);
            this.tabPagePhysicalPerson.Controls.Add(this.btnSearchPP);
            this.tabPagePhysicalPerson.Controls.Add(this.lblDataSearchPP);
            this.tabPagePhysicalPerson.Controls.Add(this.txtSearchPP);
            this.tabPagePhysicalPerson.Controls.Add(this.lblPP);
            this.tabPagePhysicalPerson.Location = new System.Drawing.Point(4, 29);
            this.tabPagePhysicalPerson.Name = "tabPagePhysicalPerson";
            this.tabPagePhysicalPerson.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePhysicalPerson.Size = new System.Drawing.Size(476, 97);
            this.tabPagePhysicalPerson.TabIndex = 0;
            this.tabPagePhysicalPerson.Text = "Physical Person";
            this.tabPagePhysicalPerson.UseVisualStyleBackColor = true;
            // 
            // mskTextCPF
            // 
            this.mskTextCPF.Location = new System.Drawing.Point(9, 55);
            this.mskTextCPF.Mask = "999.999.999-99";
            this.mskTextCPF.Name = "mskTextCPF";
            this.mskTextCPF.Size = new System.Drawing.Size(350, 26);
            this.mskTextCPF.TabIndex = 56;
            this.mskTextCPF.Visible = false;
            // 
            // gpOptionsPP
            // 
            this.gpOptionsPP.Controls.Add(this.rdForCPF);
            this.gpOptionsPP.Controls.Add(this.rdForNamePP);
            this.gpOptionsPP.Location = new System.Drawing.Point(218, 3);
            this.gpOptionsPP.Name = "gpOptionsPP";
            this.gpOptionsPP.Size = new System.Drawing.Size(250, 45);
            this.gpOptionsPP.TabIndex = 55;
            this.gpOptionsPP.TabStop = false;
            this.gpOptionsPP.Text = "Status";
            // 
            // rdForCPF
            // 
            this.rdForCPF.AutoSize = true;
            this.rdForCPF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdForCPF.Location = new System.Drawing.Point(150, 16);
            this.rdForCPF.Margin = new System.Windows.Forms.Padding(2);
            this.rdForCPF.Name = "rdForCPF";
            this.rdForCPF.Size = new System.Drawing.Size(86, 24);
            this.rdForCPF.TabIndex = 27;
            this.rdForCPF.Text = "For CPF";
            this.rdForCPF.UseVisualStyleBackColor = true;
            this.rdForCPF.CheckedChanged += new System.EventHandler(this.rdCPF_CheckedChanged);
            // 
            // rdForNamePP
            // 
            this.rdForNamePP.AutoSize = true;
            this.rdForNamePP.Checked = true;
            this.rdForNamePP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdForNamePP.Location = new System.Drawing.Point(49, 16);
            this.rdForNamePP.Margin = new System.Windows.Forms.Padding(2);
            this.rdForNamePP.Name = "rdForNamePP";
            this.rdForNamePP.Size = new System.Drawing.Size(97, 24);
            this.rdForNamePP.TabIndex = 26;
            this.rdForNamePP.TabStop = true;
            this.rdForNamePP.Text = "For Name";
            this.rdForNamePP.UseVisualStyleBackColor = true;
            this.rdForNamePP.CheckedChanged += new System.EventHandler(this.rdForNamePP_CheckedChanged);
            // 
            // btnSearchPP
            // 
            this.btnSearchPP.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnSearchPP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchPP.ForeColor = System.Drawing.Color.White;
            this.btnSearchPP.Location = new System.Drawing.Point(360, 53);
            this.btnSearchPP.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchPP.Name = "btnSearchPP";
            this.btnSearchPP.Size = new System.Drawing.Size(109, 30);
            this.btnSearchPP.TabIndex = 28;
            this.btnSearchPP.Text = "Search";
            this.btnSearchPP.UseVisualStyleBackColor = false;
            this.btnSearchPP.Click += new System.EventHandler(this.btnSearchPP_Click);
            // 
            // lblDataSearchPP
            // 
            this.lblDataSearchPP.AutoSize = true;
            this.lblDataSearchPP.Location = new System.Drawing.Point(5, 33);
            this.lblDataSearchPP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataSearchPP.Name = "lblDataSearchPP";
            this.lblDataSearchPP.Size = new System.Drawing.Size(103, 20);
            this.lblDataSearchPP.TabIndex = 26;
            this.lblDataSearchPP.Text = "Data Search:";
            // 
            // txtSearchPP
            // 
            this.txtSearchPP.Location = new System.Drawing.Point(9, 55);
            this.txtSearchPP.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchPP.Name = "txtSearchPP";
            this.txtSearchPP.Size = new System.Drawing.Size(350, 26);
            this.txtSearchPP.TabIndex = 27;
            // 
            // lblPP
            // 
            this.lblPP.AutoSize = true;
            this.lblPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPP.Location = new System.Drawing.Point(5, 3);
            this.lblPP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPP.Name = "lblPP";
            this.lblPP.Size = new System.Drawing.Size(159, 24);
            this.lblPP.TabIndex = 25;
            this.lblPP.Text = "Physical Person";
            // 
            // tabPageJuridicalPerson
            // 
            this.tabPageJuridicalPerson.Controls.Add(this.mskTextCNPJ);
            this.tabPageJuridicalPerson.Controls.Add(this.gpOptionsJP);
            this.tabPageJuridicalPerson.Controls.Add(this.btnSearchJP);
            this.tabPageJuridicalPerson.Controls.Add(this.lblDataSearchJP);
            this.tabPageJuridicalPerson.Controls.Add(this.txtSearchJP);
            this.tabPageJuridicalPerson.Controls.Add(this.lblJP);
            this.tabPageJuridicalPerson.Location = new System.Drawing.Point(4, 29);
            this.tabPageJuridicalPerson.Name = "tabPageJuridicalPerson";
            this.tabPageJuridicalPerson.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageJuridicalPerson.Size = new System.Drawing.Size(476, 97);
            this.tabPageJuridicalPerson.TabIndex = 1;
            this.tabPageJuridicalPerson.Text = "Juridical Person";
            this.tabPageJuridicalPerson.UseVisualStyleBackColor = true;
            // 
            // mskTextCNPJ
            // 
            this.mskTextCNPJ.Location = new System.Drawing.Point(9, 55);
            this.mskTextCNPJ.Mask = "99.999.999/9999-99";
            this.mskTextCNPJ.Name = "mskTextCNPJ";
            this.mskTextCNPJ.Size = new System.Drawing.Size(350, 26);
            this.mskTextCNPJ.TabIndex = 55;
            this.mskTextCNPJ.Visible = false;
            // 
            // gpOptionsJP
            // 
            this.gpOptionsJP.Controls.Add(this.rdForCNPJ);
            this.gpOptionsJP.Controls.Add(this.rdForNameJP);
            this.gpOptionsJP.Location = new System.Drawing.Point(218, 3);
            this.gpOptionsJP.Name = "gpOptionsJP";
            this.gpOptionsJP.Size = new System.Drawing.Size(250, 45);
            this.gpOptionsJP.TabIndex = 54;
            this.gpOptionsJP.TabStop = false;
            this.gpOptionsJP.Text = "Status";
            // 
            // rdForCNPJ
            // 
            this.rdForCNPJ.AutoSize = true;
            this.rdForCNPJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdForCNPJ.Location = new System.Drawing.Point(150, 16);
            this.rdForCNPJ.Margin = new System.Windows.Forms.Padding(2);
            this.rdForCNPJ.Name = "rdForCNPJ";
            this.rdForCNPJ.Size = new System.Drawing.Size(95, 24);
            this.rdForCNPJ.TabIndex = 27;
            this.rdForCNPJ.Text = "For CNPJ";
            this.rdForCNPJ.UseVisualStyleBackColor = true;
            this.rdForCNPJ.CheckedChanged += new System.EventHandler(this.rdForCNPJ_CheckedChanged);
            // 
            // rdForNameJP
            // 
            this.rdForNameJP.AutoSize = true;
            this.rdForNameJP.Checked = true;
            this.rdForNameJP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdForNameJP.Location = new System.Drawing.Point(49, 16);
            this.rdForNameJP.Margin = new System.Windows.Forms.Padding(2);
            this.rdForNameJP.Name = "rdForNameJP";
            this.rdForNameJP.Size = new System.Drawing.Size(97, 24);
            this.rdForNameJP.TabIndex = 26;
            this.rdForNameJP.TabStop = true;
            this.rdForNameJP.Text = "For Name";
            this.rdForNameJP.UseVisualStyleBackColor = true;
            this.rdForNameJP.CheckedChanged += new System.EventHandler(this.rdForNameJP_CheckedChanged);
            // 
            // btnSearchJP
            // 
            this.btnSearchJP.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnSearchJP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchJP.ForeColor = System.Drawing.Color.White;
            this.btnSearchJP.Location = new System.Drawing.Point(360, 53);
            this.btnSearchJP.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchJP.Name = "btnSearchJP";
            this.btnSearchJP.Size = new System.Drawing.Size(109, 30);
            this.btnSearchJP.TabIndex = 22;
            this.btnSearchJP.Text = "Search";
            this.btnSearchJP.UseVisualStyleBackColor = false;
            this.btnSearchJP.Click += new System.EventHandler(this.btnSearchJP_Click);
            // 
            // lblDataSearchJP
            // 
            this.lblDataSearchJP.AutoSize = true;
            this.lblDataSearchJP.Location = new System.Drawing.Point(5, 33);
            this.lblDataSearchJP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataSearchJP.Name = "lblDataSearchJP";
            this.lblDataSearchJP.Size = new System.Drawing.Size(103, 20);
            this.lblDataSearchJP.TabIndex = 20;
            this.lblDataSearchJP.Text = "Data Search:";
            // 
            // txtSearchJP
            // 
            this.txtSearchJP.Location = new System.Drawing.Point(9, 55);
            this.txtSearchJP.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchJP.Name = "txtSearchJP";
            this.txtSearchJP.Size = new System.Drawing.Size(350, 26);
            this.txtSearchJP.TabIndex = 21;
            // 
            // lblJP
            // 
            this.lblJP.AutoSize = true;
            this.lblJP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJP.Location = new System.Drawing.Point(5, 3);
            this.lblJP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblJP.Name = "lblJP";
            this.lblJP.Size = new System.Drawing.Size(160, 24);
            this.lblJP.TabIndex = 19;
            this.lblJP.Text = "Juridical Person";
            // 
            // dgvPerson
            // 
            this.dgvPerson.AllowUserToAddRows = false;
            this.dgvPerson.AllowUserToDeleteRows = false;
            this.dgvPerson.AllowUserToResizeColumns = false;
            this.dgvPerson.AllowUserToResizeRows = false;
            this.dgvPerson.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPerson.CausesValidation = false;
            this.dgvPerson.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerson.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnID,
            this.columnRegister,
            this.columnName});
            this.dgvPerson.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPerson.Location = new System.Drawing.Point(0, 132);
            this.dgvPerson.MultiSelect = false;
            this.dgvPerson.Name = "dgvPerson";
            this.dgvPerson.ReadOnly = true;
            this.dgvPerson.RowHeadersVisible = false;
            this.dgvPerson.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPerson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPerson.Size = new System.Drawing.Size(484, 429);
            this.dgvPerson.TabIndex = 14;
            this.dgvPerson.Visible = false;
            this.dgvPerson.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPerson_CellDoubleClick);
            // 
            // columnID
            // 
            this.columnID.DataPropertyName = "Id";
            this.columnID.Frozen = true;
            this.columnID.HeaderText = "ID";
            this.columnID.Name = "columnID";
            this.columnID.ReadOnly = true;
            this.columnID.Visible = false;
            // 
            // columnRegister
            // 
            this.columnRegister.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.columnRegister.DataPropertyName = "CPF";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.columnRegister.DefaultCellStyle = dataGridViewCellStyle1;
            this.columnRegister.Frozen = true;
            this.columnRegister.HeaderText = "CPF";
            this.columnRegister.MaxInputLength = 25;
            this.columnRegister.MinimumWidth = 130;
            this.columnRegister.Name = "columnRegister";
            this.columnRegister.ReadOnly = true;
            this.columnRegister.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnRegister.Width = 130;
            // 
            // columnName
            // 
            this.columnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.columnName.DataPropertyName = "Name";
            this.columnName.Frozen = true;
            this.columnName.HeaderText = "NAME";
            this.columnName.MaxInputLength = 45;
            this.columnName.MinimumWidth = 414;
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            this.columnName.Width = 414;
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.dgvPerson);
            this.Controls.Add(this.tabSearch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.tabSearch.ResumeLayout(false);
            this.tabPagePhysicalPerson.ResumeLayout(false);
            this.tabPagePhysicalPerson.PerformLayout();
            this.gpOptionsPP.ResumeLayout(false);
            this.gpOptionsPP.PerformLayout();
            this.tabPageJuridicalPerson.ResumeLayout(false);
            this.tabPageJuridicalPerson.PerformLayout();
            this.gpOptionsJP.ResumeLayout(false);
            this.gpOptionsJP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSearch;
        private System.Windows.Forms.TabPage tabPagePhysicalPerson;
        private System.Windows.Forms.TabPage tabPageJuridicalPerson;
        private System.Windows.Forms.Button btnSearchJP;
        private System.Windows.Forms.Label lblDataSearchJP;
        private System.Windows.Forms.TextBox txtSearchJP;
        private System.Windows.Forms.Label lblJP;
        private System.Windows.Forms.Button btnSearchPP;
        private System.Windows.Forms.Label lblDataSearchPP;
        private System.Windows.Forms.TextBox txtSearchPP;
        private System.Windows.Forms.Label lblPP;
        private System.Windows.Forms.GroupBox gpOptionsJP;
        private System.Windows.Forms.RadioButton rdForCNPJ;
        private System.Windows.Forms.RadioButton rdForNameJP;
        private System.Windows.Forms.GroupBox gpOptionsPP;
        private System.Windows.Forms.RadioButton rdForCPF;
        private System.Windows.Forms.RadioButton rdForNamePP;
        private System.Windows.Forms.MaskedTextBox mskTextCPF;
        private System.Windows.Forms.MaskedTextBox mskTextCNPJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnRegister;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridView dgvPerson;

    }
}