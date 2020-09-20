namespace CrudSharp
{
    partial class FrmReportOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportOptions));
            this.tabPageJuridicalPerson = new System.Windows.Forms.TabPage();
            this.gpOptionsJP = new System.Windows.Forms.GroupBox();
            this.rdAllJuridicalPerson = new System.Windows.Forms.RadioButton();
            this.lblJP = new System.Windows.Forms.Label();
            this.tabPagePhysicalPerson = new System.Windows.Forms.TabPage();
            this.gpOptionsPP = new System.Windows.Forms.GroupBox();
            this.rdAllPhysicalPerson = new System.Windows.Forms.RadioButton();
            this.rdBornMonth = new System.Windows.Forms.RadioButton();
            this.rdBySalary = new System.Windows.Forms.RadioButton();
            this.rdAverageWage = new System.Windows.Forms.RadioButton();
            this.rdSalaryRange = new System.Windows.Forms.RadioButton();
            this.gpSalaryRange = new System.Windows.Forms.GroupBox();
            this.txtFinalSal = new System.Windows.Forms.TextBox();
            this.lblFinal = new System.Windows.Forms.Label();
            this.txtInitialSal = new System.Windows.Forms.TextBox();
            this.lblInitial = new System.Windows.Forms.Label();
            this.gpBySalary = new System.Windows.Forms.GroupBox();
            this.cmbSal = new System.Windows.Forms.ComboBox();
            this.gpAVGSal = new System.Windows.Forms.GroupBox();
            this.cmbAVG = new System.Windows.Forms.ComboBox();
            this.gpBornMonth = new System.Windows.Forms.GroupBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.lblPP = new System.Windows.Forms.Label();
            this.tabPerson = new System.Windows.Forms.TabControl();
            this.gpOperation = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tabPageJuridicalPerson.SuspendLayout();
            this.gpOptionsJP.SuspendLayout();
            this.tabPagePhysicalPerson.SuspendLayout();
            this.gpOptionsPP.SuspendLayout();
            this.gpSalaryRange.SuspendLayout();
            this.gpBySalary.SuspendLayout();
            this.gpAVGSal.SuspendLayout();
            this.gpBornMonth.SuspendLayout();
            this.tabPerson.SuspendLayout();
            this.gpOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageJuridicalPerson
            // 
            this.tabPageJuridicalPerson.Controls.Add(this.gpOptionsJP);
            this.tabPageJuridicalPerson.Controls.Add(this.lblJP);
            this.tabPageJuridicalPerson.Location = new System.Drawing.Point(4, 29);
            this.tabPageJuridicalPerson.Name = "tabPageJuridicalPerson";
            this.tabPageJuridicalPerson.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageJuridicalPerson.Size = new System.Drawing.Size(266, 367);
            this.tabPageJuridicalPerson.TabIndex = 1;
            this.tabPageJuridicalPerson.Text = "Juridical Person";
            this.tabPageJuridicalPerson.UseVisualStyleBackColor = true;
            // 
            // gpOptionsJP
            // 
            this.gpOptionsJP.Controls.Add(this.rdAllJuridicalPerson);
            this.gpOptionsJP.Location = new System.Drawing.Point(9, 29);
            this.gpOptionsJP.Margin = new System.Windows.Forms.Padding(2);
            this.gpOptionsJP.Name = "gpOptionsJP";
            this.gpOptionsJP.Padding = new System.Windows.Forms.Padding(2);
            this.gpOptionsJP.Size = new System.Drawing.Size(240, 180);
            this.gpOptionsJP.TabIndex = 31;
            this.gpOptionsJP.TabStop = false;
            this.gpOptionsJP.Text = "Options";
            // 
            // rdAllJuridicalPerson
            // 
            this.rdAllJuridicalPerson.AutoSize = true;
            this.rdAllJuridicalPerson.Checked = true;
            this.rdAllJuridicalPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdAllJuridicalPerson.Location = new System.Drawing.Point(33, 23);
            this.rdAllJuridicalPerson.Margin = new System.Windows.Forms.Padding(2);
            this.rdAllJuridicalPerson.Name = "rdAllJuridicalPerson";
            this.rdAllJuridicalPerson.Size = new System.Drawing.Size(159, 24);
            this.rdAllJuridicalPerson.TabIndex = 0;
            this.rdAllJuridicalPerson.TabStop = true;
            this.rdAllJuridicalPerson.Text = "All Juridical Person";
            this.rdAllJuridicalPerson.UseVisualStyleBackColor = true;
            this.rdAllJuridicalPerson.CheckedChanged += new System.EventHandler(this.rdAllJuridicalPerson_CheckedChanged);
            // 
            // lblJP
            // 
            this.lblJP.AutoSize = true;
            this.lblJP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJP.Location = new System.Drawing.Point(5, 3);
            this.lblJP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblJP.Name = "lblJP";
            this.lblJP.Size = new System.Drawing.Size(160, 24);
            this.lblJP.TabIndex = 30;
            this.lblJP.Text = "Juridical Person";
            // 
            // tabPagePhysicalPerson
            // 
            this.tabPagePhysicalPerson.Controls.Add(this.gpOptionsPP);
            this.tabPagePhysicalPerson.Controls.Add(this.gpSalaryRange);
            this.tabPagePhysicalPerson.Controls.Add(this.gpBySalary);
            this.tabPagePhysicalPerson.Controls.Add(this.gpAVGSal);
            this.tabPagePhysicalPerson.Controls.Add(this.gpBornMonth);
            this.tabPagePhysicalPerson.Controls.Add(this.lblPP);
            this.tabPagePhysicalPerson.Location = new System.Drawing.Point(4, 29);
            this.tabPagePhysicalPerson.Name = "tabPagePhysicalPerson";
            this.tabPagePhysicalPerson.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePhysicalPerson.Size = new System.Drawing.Size(266, 367);
            this.tabPagePhysicalPerson.TabIndex = 0;
            this.tabPagePhysicalPerson.Text = "Physical Person";
            this.tabPagePhysicalPerson.UseVisualStyleBackColor = true;
            // 
            // gpOptionsPP
            // 
            this.gpOptionsPP.Controls.Add(this.rdAllPhysicalPerson);
            this.gpOptionsPP.Controls.Add(this.rdBornMonth);
            this.gpOptionsPP.Controls.Add(this.rdBySalary);
            this.gpOptionsPP.Controls.Add(this.rdAverageWage);
            this.gpOptionsPP.Controls.Add(this.rdSalaryRange);
            this.gpOptionsPP.Location = new System.Drawing.Point(9, 29);
            this.gpOptionsPP.Margin = new System.Windows.Forms.Padding(2);
            this.gpOptionsPP.Name = "gpOptionsPP";
            this.gpOptionsPP.Padding = new System.Windows.Forms.Padding(2);
            this.gpOptionsPP.Size = new System.Drawing.Size(240, 180);
            this.gpOptionsPP.TabIndex = 12;
            this.gpOptionsPP.TabStop = false;
            this.gpOptionsPP.Text = "Options";
            // 
            // rdAllPhysicalPerson
            // 
            this.rdAllPhysicalPerson.AutoSize = true;
            this.rdAllPhysicalPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdAllPhysicalPerson.Location = new System.Drawing.Point(33, 135);
            this.rdAllPhysicalPerson.Margin = new System.Windows.Forms.Padding(2);
            this.rdAllPhysicalPerson.Name = "rdAllPhysicalPerson";
            this.rdAllPhysicalPerson.Size = new System.Drawing.Size(159, 24);
            this.rdAllPhysicalPerson.TabIndex = 4;
            this.rdAllPhysicalPerson.Text = "All Physical Person";
            this.rdAllPhysicalPerson.UseVisualStyleBackColor = true;
            this.rdAllPhysicalPerson.CheckedChanged += new System.EventHandler(this.rdAllPhysicalPerson_CheckedChanged);
            // 
            // rdBornMonth
            // 
            this.rdBornMonth.AutoSize = true;
            this.rdBornMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdBornMonth.Location = new System.Drawing.Point(33, 107);
            this.rdBornMonth.Margin = new System.Windows.Forms.Padding(2);
            this.rdBornMonth.Name = "rdBornMonth";
            this.rdBornMonth.Size = new System.Drawing.Size(153, 24);
            this.rdBornMonth.TabIndex = 3;
            this.rdBornMonth.Text = "Born in the Month";
            this.rdBornMonth.UseVisualStyleBackColor = true;
            this.rdBornMonth.CheckedChanged += new System.EventHandler(this.rdBornMonth_CheckedChanged);
            // 
            // rdBySalary
            // 
            this.rdBySalary.AutoSize = true;
            this.rdBySalary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdBySalary.Location = new System.Drawing.Point(33, 79);
            this.rdBySalary.Margin = new System.Windows.Forms.Padding(2);
            this.rdBySalary.Name = "rdBySalary";
            this.rdBySalary.Size = new System.Drawing.Size(93, 24);
            this.rdBySalary.TabIndex = 2;
            this.rdBySalary.Text = "By Salary";
            this.rdBySalary.UseVisualStyleBackColor = true;
            this.rdBySalary.CheckedChanged += new System.EventHandler(this.rdBySalary_CheckedChanged);
            // 
            // rdAverageWage
            // 
            this.rdAverageWage.AutoSize = true;
            this.rdAverageWage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdAverageWage.Location = new System.Drawing.Point(33, 51);
            this.rdAverageWage.Margin = new System.Windows.Forms.Padding(2);
            this.rdAverageWage.Name = "rdAverageWage";
            this.rdAverageWage.Size = new System.Drawing.Size(132, 24);
            this.rdAverageWage.TabIndex = 1;
            this.rdAverageWage.Text = "Average Wage";
            this.rdAverageWage.UseVisualStyleBackColor = true;
            this.rdAverageWage.CheckedChanged += new System.EventHandler(this.rdAverageWage_CheckedChanged);
            // 
            // rdSalaryRange
            // 
            this.rdSalaryRange.AutoSize = true;
            this.rdSalaryRange.Checked = true;
            this.rdSalaryRange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdSalaryRange.Location = new System.Drawing.Point(33, 23);
            this.rdSalaryRange.Margin = new System.Windows.Forms.Padding(2);
            this.rdSalaryRange.Name = "rdSalaryRange";
            this.rdSalaryRange.Size = new System.Drawing.Size(123, 24);
            this.rdSalaryRange.TabIndex = 0;
            this.rdSalaryRange.TabStop = true;
            this.rdSalaryRange.Text = "Salary Range";
            this.rdSalaryRange.UseVisualStyleBackColor = true;
            this.rdSalaryRange.CheckedChanged += new System.EventHandler(this.rdSalaryRange_CheckedChanged);
            // 
            // gpSalaryRange
            // 
            this.gpSalaryRange.Controls.Add(this.txtFinalSal);
            this.gpSalaryRange.Controls.Add(this.lblFinal);
            this.gpSalaryRange.Controls.Add(this.txtInitialSal);
            this.gpSalaryRange.Controls.Add(this.lblInitial);
            this.gpSalaryRange.Location = new System.Drawing.Point(9, 213);
            this.gpSalaryRange.Margin = new System.Windows.Forms.Padding(2);
            this.gpSalaryRange.Name = "gpSalaryRange";
            this.gpSalaryRange.Padding = new System.Windows.Forms.Padding(2);
            this.gpSalaryRange.Size = new System.Drawing.Size(240, 133);
            this.gpSalaryRange.TabIndex = 8;
            this.gpSalaryRange.TabStop = false;
            this.gpSalaryRange.Text = "Salary Range";
            // 
            // txtFinalSal
            // 
            this.txtFinalSal.Location = new System.Drawing.Point(8, 96);
            this.txtFinalSal.Margin = new System.Windows.Forms.Padding(2);
            this.txtFinalSal.Name = "txtFinalSal";
            this.txtFinalSal.Size = new System.Drawing.Size(226, 26);
            this.txtFinalSal.TabIndex = 3;
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.Location = new System.Drawing.Point(4, 73);
            this.lblFinal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(91, 20);
            this.lblFinal.TabIndex = 2;
            this.lblFinal.Text = "Final Salary";
            // 
            // txtInitialSal
            // 
            this.txtInitialSal.Location = new System.Drawing.Point(8, 43);
            this.txtInitialSal.Margin = new System.Windows.Forms.Padding(2);
            this.txtInitialSal.Name = "txtInitialSal";
            this.txtInitialSal.Size = new System.Drawing.Size(226, 26);
            this.txtInitialSal.TabIndex = 1;
            // 
            // lblInitial
            // 
            this.lblInitial.AutoSize = true;
            this.lblInitial.Location = new System.Drawing.Point(4, 21);
            this.lblInitial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInitial.Name = "lblInitial";
            this.lblInitial.Size = new System.Drawing.Size(94, 20);
            this.lblInitial.TabIndex = 0;
            this.lblInitial.Text = "Initial Salary";
            // 
            // gpBySalary
            // 
            this.gpBySalary.Controls.Add(this.cmbSal);
            this.gpBySalary.Location = new System.Drawing.Point(9, 213);
            this.gpBySalary.Margin = new System.Windows.Forms.Padding(2);
            this.gpBySalary.Name = "gpBySalary";
            this.gpBySalary.Padding = new System.Windows.Forms.Padding(2);
            this.gpBySalary.Size = new System.Drawing.Size(240, 83);
            this.gpBySalary.TabIndex = 11;
            this.gpBySalary.TabStop = false;
            this.gpBySalary.Text = "Salary";
            // 
            // cmbSal
            // 
            this.cmbSal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSal.FormattingEnabled = true;
            this.cmbSal.Items.AddRange(new object[] {
            "Lowest",
            "Highest"});
            this.cmbSal.Location = new System.Drawing.Point(8, 43);
            this.cmbSal.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSal.Name = "cmbSal";
            this.cmbSal.Size = new System.Drawing.Size(226, 28);
            this.cmbSal.TabIndex = 5;
            // 
            // gpAVGSal
            // 
            this.gpAVGSal.Controls.Add(this.cmbAVG);
            this.gpAVGSal.Location = new System.Drawing.Point(9, 213);
            this.gpAVGSal.Margin = new System.Windows.Forms.Padding(2);
            this.gpAVGSal.Name = "gpAVGSal";
            this.gpAVGSal.Padding = new System.Windows.Forms.Padding(2);
            this.gpAVGSal.Size = new System.Drawing.Size(240, 83);
            this.gpAVGSal.TabIndex = 10;
            this.gpAVGSal.TabStop = false;
            this.gpAVGSal.Text = "Average Wage";
            // 
            // cmbAVG
            // 
            this.cmbAVG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAVG.FormattingEnabled = true;
            this.cmbAVG.Items.AddRange(new object[] {
            "Under",
            "Equal",
            "Above",
            "",
            ""});
            this.cmbAVG.Location = new System.Drawing.Point(8, 43);
            this.cmbAVG.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAVG.Name = "cmbAVG";
            this.cmbAVG.Size = new System.Drawing.Size(226, 28);
            this.cmbAVG.TabIndex = 5;
            // 
            // gpBornMonth
            // 
            this.gpBornMonth.Controls.Add(this.cmbMonth);
            this.gpBornMonth.Location = new System.Drawing.Point(9, 213);
            this.gpBornMonth.Margin = new System.Windows.Forms.Padding(2);
            this.gpBornMonth.Name = "gpBornMonth";
            this.gpBornMonth.Padding = new System.Windows.Forms.Padding(2);
            this.gpBornMonth.Size = new System.Drawing.Size(240, 83);
            this.gpBornMonth.TabIndex = 9;
            this.gpBornMonth.TabStop = false;
            this.gpBornMonth.Text = "Born in the Month";
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbMonth.Location = new System.Drawing.Point(8, 43);
            this.cmbMonth.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(226, 28);
            this.cmbMonth.TabIndex = 5;
            // 
            // lblPP
            // 
            this.lblPP.AutoSize = true;
            this.lblPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPP.Location = new System.Drawing.Point(5, 3);
            this.lblPP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPP.Name = "lblPP";
            this.lblPP.Size = new System.Drawing.Size(159, 24);
            this.lblPP.TabIndex = 0;
            this.lblPP.Text = "Physical Person";
            // 
            // tabPerson
            // 
            this.tabPerson.Controls.Add(this.tabPagePhysicalPerson);
            this.tabPerson.Controls.Add(this.tabPageJuridicalPerson);
            this.tabPerson.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPerson.Location = new System.Drawing.Point(0, 0);
            this.tabPerson.Name = "tabPerson";
            this.tabPerson.SelectedIndex = 0;
            this.tabPerson.Size = new System.Drawing.Size(274, 400);
            this.tabPerson.TabIndex = 19;
            // 
            // gpOperation
            // 
            this.gpOperation.Controls.Add(this.btnGenerate);
            this.gpOperation.Location = new System.Drawing.Point(4, 406);
            this.gpOperation.Name = "gpOperation";
            this.gpOperation.Size = new System.Drawing.Size(266, 70);
            this.gpOperation.TabIndex = 20;
            this.gpOperation.TabStop = false;
            this.gpOperation.Text = "Operation";
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(19, 24);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(230, 30);
            this.btnGenerate.TabIndex = 14;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // FrmReportOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(274, 491);
            this.Controls.Add(this.gpOperation);
            this.Controls.Add(this.tabPerson);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmReportOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Reports";
            this.tabPageJuridicalPerson.ResumeLayout(false);
            this.tabPageJuridicalPerson.PerformLayout();
            this.gpOptionsJP.ResumeLayout(false);
            this.gpOptionsJP.PerformLayout();
            this.tabPagePhysicalPerson.ResumeLayout(false);
            this.tabPagePhysicalPerson.PerformLayout();
            this.gpOptionsPP.ResumeLayout(false);
            this.gpOptionsPP.PerformLayout();
            this.gpSalaryRange.ResumeLayout(false);
            this.gpSalaryRange.PerformLayout();
            this.gpBySalary.ResumeLayout(false);
            this.gpAVGSal.ResumeLayout(false);
            this.gpBornMonth.ResumeLayout(false);
            this.tabPerson.ResumeLayout(false);
            this.gpOperation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageJuridicalPerson;
        private System.Windows.Forms.Label lblJP;
        private System.Windows.Forms.TabPage tabPagePhysicalPerson;
        private System.Windows.Forms.GroupBox gpOptionsPP;
        private System.Windows.Forms.RadioButton rdAllPhysicalPerson;
        private System.Windows.Forms.RadioButton rdBornMonth;
        private System.Windows.Forms.RadioButton rdBySalary;
        private System.Windows.Forms.RadioButton rdAverageWage;
        private System.Windows.Forms.RadioButton rdSalaryRange;
        private System.Windows.Forms.GroupBox gpBySalary;
        private System.Windows.Forms.ComboBox cmbSal;
        private System.Windows.Forms.GroupBox gpAVGSal;
        private System.Windows.Forms.ComboBox cmbAVG;
        private System.Windows.Forms.GroupBox gpBornMonth;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.GroupBox gpSalaryRange;
        private System.Windows.Forms.TextBox txtFinalSal;
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.TextBox txtInitialSal;
        private System.Windows.Forms.Label lblInitial;
        private System.Windows.Forms.Label lblPP;
        private System.Windows.Forms.TabControl tabPerson;
        private System.Windows.Forms.GroupBox gpOperation;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox gpOptionsJP;
        private System.Windows.Forms.RadioButton rdAllJuridicalPerson;

    }
}