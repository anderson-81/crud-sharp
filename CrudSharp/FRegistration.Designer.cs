namespace CrudSharp
{
    partial class FrmRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistration));
            this.lblPP = new System.Windows.Forms.Label();
            this.lblNamePP = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.txtEmailPP = new System.Windows.Forms.TextBox();
            this.lblEmailPP = new System.Windows.Forms.Label();
            this.txtNamePP = new System.Windows.Forms.TextBox();
            this.lblSalary = new System.Windows.Forms.Label();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.dtBirthday = new System.Windows.Forms.DateTimePicker();
            this.tabPerson = new System.Windows.Forms.TabControl();
            this.tabPagePhysicalPerson = new System.Windows.Forms.TabPage();
            this.mskTextCPF = new System.Windows.Forms.MaskedTextBox();
            this.gpStatusPP = new System.Windows.Forms.GroupBox();
            this.rdInactivePP = new System.Windows.Forms.RadioButton();
            this.rdActivePP = new System.Windows.Forms.RadioButton();
            this.gpGender = new System.Windows.Forms.GroupBox();
            this.rdFemale = new System.Windows.Forms.RadioButton();
            this.rdMale = new System.Windows.Forms.RadioButton();
            this.btnClearPP = new System.Windows.Forms.Button();
            this.txtCommentPP = new System.Windows.Forms.TextBox();
            this.lblCommentPP = new System.Windows.Forms.Label();
            this.lblCPF = new System.Windows.Forms.Label();
            this.tabPageJuridicalPerson = new System.Windows.Forms.TabPage();
            this.mskTextCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.gpStatusJP = new System.Windows.Forms.GroupBox();
            this.rdInactiveJP = new System.Windows.Forms.RadioButton();
            this.rdActiveJP = new System.Windows.Forms.RadioButton();
            this.btnClearJP = new System.Windows.Forms.Button();
            this.txtCommentJP = new System.Windows.Forms.TextBox();
            this.lblCommentJP = new System.Windows.Forms.Label();
            this.lblCNPJ = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblJP = new System.Windows.Forms.Label();
            this.lblNameJP = new System.Windows.Forms.Label();
            this.txtNameJP = new System.Windows.Forms.TextBox();
            this.lblEmailJP = new System.Windows.Forms.Label();
            this.txtEmailJP = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.gpOperations = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.tabPerson.SuspendLayout();
            this.tabPagePhysicalPerson.SuspendLayout();
            this.gpStatusPP.SuspendLayout();
            this.gpGender.SuspendLayout();
            this.tabPageJuridicalPerson.SuspendLayout();
            this.gpStatusJP.SuspendLayout();
            this.gpOperations.SuspendLayout();
            this.SuspendLayout();
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
            // lblNamePP
            // 
            this.lblNamePP.AutoSize = true;
            this.lblNamePP.Location = new System.Drawing.Point(5, 91);
            this.lblNamePP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNamePP.Name = "lblNamePP";
            this.lblNamePP.Size = new System.Drawing.Size(51, 20);
            this.lblNamePP.TabIndex = 1;
            this.lblNamePP.Text = "Name";
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(9, 213);
            this.txtSalary.Margin = new System.Windows.Forms.Padding(2);
            this.txtSalary.MaxLength = 18;
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(370, 26);
            this.txtSalary.TabIndex = 3;
            // 
            // txtEmailPP
            // 
            this.txtEmailPP.Location = new System.Drawing.Point(9, 163);
            this.txtEmailPP.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailPP.MaxLength = 45;
            this.txtEmailPP.Name = "txtEmailPP";
            this.txtEmailPP.Size = new System.Drawing.Size(370, 26);
            this.txtEmailPP.TabIndex = 2;
            // 
            // lblEmailPP
            // 
            this.lblEmailPP.AutoSize = true;
            this.lblEmailPP.Location = new System.Drawing.Point(5, 141);
            this.lblEmailPP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmailPP.Name = "lblEmailPP";
            this.lblEmailPP.Size = new System.Drawing.Size(48, 20);
            this.lblEmailPP.TabIndex = 3;
            this.lblEmailPP.Text = "Email";
            // 
            // txtNamePP
            // 
            this.txtNamePP.Location = new System.Drawing.Point(9, 113);
            this.txtNamePP.Margin = new System.Windows.Forms.Padding(2);
            this.txtNamePP.MaxLength = 45;
            this.txtNamePP.Name = "txtNamePP";
            this.txtNamePP.Size = new System.Drawing.Size(370, 26);
            this.txtNamePP.TabIndex = 1;
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new System.Drawing.Point(5, 191);
            this.lblSalary.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(53, 20);
            this.lblSalary.TabIndex = 5;
            this.lblSalary.Text = "Salary";
            // 
            // lblBirthday
            // 
            this.lblBirthday.AutoSize = true;
            this.lblBirthday.Location = new System.Drawing.Point(5, 241);
            this.lblBirthday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(67, 20);
            this.lblBirthday.TabIndex = 7;
            this.lblBirthday.Text = "Birthday";
            // 
            // dtBirthday
            // 
            this.dtBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBirthday.Location = new System.Drawing.Point(9, 263);
            this.dtBirthday.Margin = new System.Windows.Forms.Padding(2);
            this.dtBirthday.Name = "dtBirthday";
            this.dtBirthday.Size = new System.Drawing.Size(184, 26);
            this.dtBirthday.TabIndex = 4;
            // 
            // tabPerson
            // 
            this.tabPerson.Controls.Add(this.tabPagePhysicalPerson);
            this.tabPerson.Controls.Add(this.tabPageJuridicalPerson);
            this.tabPerson.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPerson.Location = new System.Drawing.Point(0, 0);
            this.tabPerson.Name = "tabPerson";
            this.tabPerson.SelectedIndex = 0;
            this.tabPerson.Size = new System.Drawing.Size(404, 500);
            this.tabPerson.TabIndex = 18;
            this.tabPerson.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabPerson_Selecting);
            // 
            // tabPagePhysicalPerson
            // 
            this.tabPagePhysicalPerson.Controls.Add(this.mskTextCPF);
            this.tabPagePhysicalPerson.Controls.Add(this.gpStatusPP);
            this.tabPagePhysicalPerson.Controls.Add(this.gpGender);
            this.tabPagePhysicalPerson.Controls.Add(this.btnClearPP);
            this.tabPagePhysicalPerson.Controls.Add(this.txtCommentPP);
            this.tabPagePhysicalPerson.Controls.Add(this.lblCommentPP);
            this.tabPagePhysicalPerson.Controls.Add(this.lblCPF);
            this.tabPagePhysicalPerson.Controls.Add(this.txtNamePP);
            this.tabPagePhysicalPerson.Controls.Add(this.dtBirthday);
            this.tabPagePhysicalPerson.Controls.Add(this.lblPP);
            this.tabPagePhysicalPerson.Controls.Add(this.lblNamePP);
            this.tabPagePhysicalPerson.Controls.Add(this.txtSalary);
            this.tabPagePhysicalPerson.Controls.Add(this.lblEmailPP);
            this.tabPagePhysicalPerson.Controls.Add(this.txtEmailPP);
            this.tabPagePhysicalPerson.Controls.Add(this.lblSalary);
            this.tabPagePhysicalPerson.Controls.Add(this.lblBirthday);
            this.tabPagePhysicalPerson.Location = new System.Drawing.Point(4, 29);
            this.tabPagePhysicalPerson.Name = "tabPagePhysicalPerson";
            this.tabPagePhysicalPerson.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePhysicalPerson.Size = new System.Drawing.Size(396, 467);
            this.tabPagePhysicalPerson.TabIndex = 0;
            this.tabPagePhysicalPerson.Text = "Physical Person";
            this.tabPagePhysicalPerson.UseVisualStyleBackColor = true;
            // 
            // mskTextCPF
            // 
            this.mskTextCPF.Location = new System.Drawing.Point(9, 64);
            this.mskTextCPF.Mask = "999.999.999-99";
            this.mskTextCPF.Name = "mskTextCPF";
            this.mskTextCPF.Size = new System.Drawing.Size(370, 26);
            this.mskTextCPF.TabIndex = 53;
            // 
            // gpStatusPP
            // 
            this.gpStatusPP.Controls.Add(this.rdInactivePP);
            this.gpStatusPP.Controls.Add(this.rdActivePP);
            this.gpStatusPP.Location = new System.Drawing.Point(203, 416);
            this.gpStatusPP.Name = "gpStatusPP";
            this.gpStatusPP.Size = new System.Drawing.Size(176, 45);
            this.gpStatusPP.TabIndex = 52;
            this.gpStatusPP.TabStop = false;
            this.gpStatusPP.Text = "Status";
            // 
            // rdInactivePP
            // 
            this.rdInactivePP.AutoSize = true;
            this.rdInactivePP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdInactivePP.Location = new System.Drawing.Point(89, 16);
            this.rdInactivePP.Margin = new System.Windows.Forms.Padding(2);
            this.rdInactivePP.Name = "rdInactivePP";
            this.rdInactivePP.Size = new System.Drawing.Size(82, 24);
            this.rdInactivePP.TabIndex = 9;
            this.rdInactivePP.Text = "Inactive";
            this.rdInactivePP.UseVisualStyleBackColor = true;
            // 
            // rdActivePP
            // 
            this.rdActivePP.AutoSize = true;
            this.rdActivePP.Checked = true;
            this.rdActivePP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdActivePP.Location = new System.Drawing.Point(12, 16);
            this.rdActivePP.Margin = new System.Windows.Forms.Padding(2);
            this.rdActivePP.Name = "rdActivePP";
            this.rdActivePP.Size = new System.Drawing.Size(70, 24);
            this.rdActivePP.TabIndex = 8;
            this.rdActivePP.TabStop = true;
            this.rdActivePP.Text = "Active";
            this.rdActivePP.UseVisualStyleBackColor = true;
            // 
            // gpGender
            // 
            this.gpGender.Controls.Add(this.rdFemale);
            this.gpGender.Controls.Add(this.rdMale);
            this.gpGender.Location = new System.Drawing.Point(203, 244);
            this.gpGender.Name = "gpGender";
            this.gpGender.Size = new System.Drawing.Size(176, 45);
            this.gpGender.TabIndex = 51;
            this.gpGender.TabStop = false;
            this.gpGender.Text = "Gender";
            // 
            // rdFemale
            // 
            this.rdFemale.AutoSize = true;
            this.rdFemale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdFemale.Location = new System.Drawing.Point(96, 16);
            this.rdFemale.Margin = new System.Windows.Forms.Padding(2);
            this.rdFemale.Name = "rdFemale";
            this.rdFemale.Size = new System.Drawing.Size(80, 24);
            this.rdFemale.TabIndex = 6;
            this.rdFemale.Text = "Female";
            this.rdFemale.UseVisualStyleBackColor = true;
            // 
            // rdMale
            // 
            this.rdMale.AutoSize = true;
            this.rdMale.Checked = true;
            this.rdMale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdMale.Location = new System.Drawing.Point(12, 16);
            this.rdMale.Margin = new System.Windows.Forms.Padding(2);
            this.rdMale.Name = "rdMale";
            this.rdMale.Size = new System.Drawing.Size(61, 24);
            this.rdMale.TabIndex = 5;
            this.rdMale.TabStop = true;
            this.rdMale.Text = "Male";
            this.rdMale.UseVisualStyleBackColor = true;
            // 
            // btnClearPP
            // 
            this.btnClearPP.BackColor = System.Drawing.Color.DarkGray;
            this.btnClearPP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearPP.ForeColor = System.Drawing.Color.White;
            this.btnClearPP.Location = new System.Drawing.Point(297, 5);
            this.btnClearPP.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearPP.Name = "btnClearPP";
            this.btnClearPP.Size = new System.Drawing.Size(90, 30);
            this.btnClearPP.TabIndex = 8;
            this.btnClearPP.Text = "Clear";
            this.btnClearPP.UseVisualStyleBackColor = false;
            this.btnClearPP.Click += new System.EventHandler(this.btnClearPP_Click);
            // 
            // txtCommentPP
            // 
            this.txtCommentPP.HideSelection = false;
            this.txtCommentPP.Location = new System.Drawing.Point(9, 313);
            this.txtCommentPP.Margin = new System.Windows.Forms.Padding(2);
            this.txtCommentPP.MaxLength = 200;
            this.txtCommentPP.Multiline = true;
            this.txtCommentPP.Name = "txtCommentPP";
            this.txtCommentPP.Size = new System.Drawing.Size(370, 100);
            this.txtCommentPP.TabIndex = 7;
            // 
            // lblCommentPP
            // 
            this.lblCommentPP.AutoSize = true;
            this.lblCommentPP.Location = new System.Drawing.Point(5, 291);
            this.lblCommentPP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCommentPP.Name = "lblCommentPP";
            this.lblCommentPP.Size = new System.Drawing.Size(78, 20);
            this.lblCommentPP.TabIndex = 20;
            this.lblCommentPP.Text = "Comment";
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Location = new System.Drawing.Point(5, 41);
            this.lblCPF.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(40, 20);
            this.lblCPF.TabIndex = 18;
            this.lblCPF.Text = "CPF";
            // 
            // tabPageJuridicalPerson
            // 
            this.tabPageJuridicalPerson.Controls.Add(this.mskTextCNPJ);
            this.tabPageJuridicalPerson.Controls.Add(this.gpStatusJP);
            this.tabPageJuridicalPerson.Controls.Add(this.btnClearJP);
            this.tabPageJuridicalPerson.Controls.Add(this.txtCommentJP);
            this.tabPageJuridicalPerson.Controls.Add(this.lblCommentJP);
            this.tabPageJuridicalPerson.Controls.Add(this.lblCNPJ);
            this.tabPageJuridicalPerson.Controls.Add(this.txtCompanyName);
            this.tabPageJuridicalPerson.Controls.Add(this.lblJP);
            this.tabPageJuridicalPerson.Controls.Add(this.lblNameJP);
            this.tabPageJuridicalPerson.Controls.Add(this.txtNameJP);
            this.tabPageJuridicalPerson.Controls.Add(this.lblEmailJP);
            this.tabPageJuridicalPerson.Controls.Add(this.txtEmailJP);
            this.tabPageJuridicalPerson.Controls.Add(this.lblCompanyName);
            this.tabPageJuridicalPerson.Location = new System.Drawing.Point(4, 29);
            this.tabPageJuridicalPerson.Name = "tabPageJuridicalPerson";
            this.tabPageJuridicalPerson.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageJuridicalPerson.Size = new System.Drawing.Size(396, 467);
            this.tabPageJuridicalPerson.TabIndex = 1;
            this.tabPageJuridicalPerson.Text = "Juridical Person";
            this.tabPageJuridicalPerson.UseVisualStyleBackColor = true;
            // 
            // mskTextCNPJ
            // 
            this.mskTextCNPJ.Location = new System.Drawing.Point(9, 62);
            this.mskTextCNPJ.Mask = "99.999.999/9999-99";
            this.mskTextCNPJ.Name = "mskTextCNPJ";
            this.mskTextCNPJ.Size = new System.Drawing.Size(370, 26);
            this.mskTextCNPJ.TabIndex = 54;
            // 
            // gpStatusJP
            // 
            this.gpStatusJP.Controls.Add(this.rdInactiveJP);
            this.gpStatusJP.Controls.Add(this.rdActiveJP);
            this.gpStatusJP.Location = new System.Drawing.Point(203, 371);
            this.gpStatusJP.Name = "gpStatusJP";
            this.gpStatusJP.Size = new System.Drawing.Size(176, 45);
            this.gpStatusJP.TabIndex = 53;
            this.gpStatusJP.TabStop = false;
            this.gpStatusJP.Text = "Status";
            // 
            // rdInactiveJP
            // 
            this.rdInactiveJP.AutoSize = true;
            this.rdInactiveJP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdInactiveJP.Location = new System.Drawing.Point(89, 16);
            this.rdInactiveJP.Margin = new System.Windows.Forms.Padding(2);
            this.rdInactiveJP.Name = "rdInactiveJP";
            this.rdInactiveJP.Size = new System.Drawing.Size(82, 24);
            this.rdInactiveJP.TabIndex = 6;
            this.rdInactiveJP.Text = "Inactive";
            this.rdInactiveJP.UseVisualStyleBackColor = true;
            // 
            // rdActiveJP
            // 
            this.rdActiveJP.AutoSize = true;
            this.rdActiveJP.Checked = true;
            this.rdActiveJP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdActiveJP.Location = new System.Drawing.Point(12, 16);
            this.rdActiveJP.Margin = new System.Windows.Forms.Padding(2);
            this.rdActiveJP.Name = "rdActiveJP";
            this.rdActiveJP.Size = new System.Drawing.Size(70, 24);
            this.rdActiveJP.TabIndex = 5;
            this.rdActiveJP.TabStop = true;
            this.rdActiveJP.Text = "Active";
            this.rdActiveJP.UseVisualStyleBackColor = true;
            // 
            // btnClearJP
            // 
            this.btnClearJP.BackColor = System.Drawing.Color.DarkGray;
            this.btnClearJP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearJP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearJP.ForeColor = System.Drawing.Color.White;
            this.btnClearJP.Location = new System.Drawing.Point(297, 5);
            this.btnClearJP.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearJP.Name = "btnClearJP";
            this.btnClearJP.Size = new System.Drawing.Size(90, 30);
            this.btnClearJP.TabIndex = 7;
            this.btnClearJP.Text = "Clear";
            this.btnClearJP.UseVisualStyleBackColor = false;
            this.btnClearJP.Click += new System.EventHandler(this.btnClearJP_Click);
            // 
            // txtCommentJP
            // 
            this.txtCommentJP.HideSelection = false;
            this.txtCommentJP.Location = new System.Drawing.Point(9, 266);
            this.txtCommentJP.Margin = new System.Windows.Forms.Padding(2);
            this.txtCommentJP.MaxLength = 200;
            this.txtCommentJP.Multiline = true;
            this.txtCommentJP.Name = "txtCommentJP";
            this.txtCommentJP.Size = new System.Drawing.Size(370, 100);
            this.txtCommentJP.TabIndex = 4;
            // 
            // lblCommentJP
            // 
            this.lblCommentJP.AutoSize = true;
            this.lblCommentJP.Location = new System.Drawing.Point(5, 241);
            this.lblCommentJP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCommentJP.Name = "lblCommentJP";
            this.lblCommentJP.Size = new System.Drawing.Size(78, 20);
            this.lblCommentJP.TabIndex = 44;
            this.lblCommentJP.Text = "Comment";
            // 
            // lblCNPJ
            // 
            this.lblCNPJ.AutoSize = true;
            this.lblCNPJ.Location = new System.Drawing.Point(5, 41);
            this.lblCNPJ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCNPJ.Name = "lblCNPJ";
            this.lblCNPJ.Size = new System.Drawing.Size(49, 20);
            this.lblCNPJ.TabIndex = 42;
            this.lblCNPJ.Text = "CNPJ";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(9, 213);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(2);
            this.txtCompanyName.MaxLength = 45;
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(370, 26);
            this.txtCompanyName.TabIndex = 3;
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
            // lblNameJP
            // 
            this.lblNameJP.AutoSize = true;
            this.lblNameJP.Location = new System.Drawing.Point(5, 91);
            this.lblNameJP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNameJP.Name = "lblNameJP";
            this.lblNameJP.Size = new System.Drawing.Size(51, 20);
            this.lblNameJP.TabIndex = 31;
            this.lblNameJP.Text = "Name";
            // 
            // txtNameJP
            // 
            this.txtNameJP.Location = new System.Drawing.Point(9, 113);
            this.txtNameJP.Margin = new System.Windows.Forms.Padding(2);
            this.txtNameJP.MaxLength = 45;
            this.txtNameJP.Name = "txtNameJP";
            this.txtNameJP.Size = new System.Drawing.Size(370, 26);
            this.txtNameJP.TabIndex = 1;
            // 
            // lblEmailJP
            // 
            this.lblEmailJP.AutoSize = true;
            this.lblEmailJP.Location = new System.Drawing.Point(5, 141);
            this.lblEmailJP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmailJP.Name = "lblEmailJP";
            this.lblEmailJP.Size = new System.Drawing.Size(48, 20);
            this.lblEmailJP.TabIndex = 33;
            this.lblEmailJP.Text = "Email";
            // 
            // txtEmailJP
            // 
            this.txtEmailJP.Location = new System.Drawing.Point(9, 163);
            this.txtEmailJP.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailJP.MaxLength = 45;
            this.txtEmailJP.Name = "txtEmailJP";
            this.txtEmailJP.Size = new System.Drawing.Size(370, 26);
            this.txtEmailJP.TabIndex = 2;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(5, 191);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(122, 20);
            this.lblCompanyName.TabIndex = 35;
            this.lblCompanyName.Text = "Company Name";
            // 
            // gpOperations
            // 
            this.gpOperations.BackColor = System.Drawing.SystemColors.Menu;
            this.gpOperations.Controls.Add(this.btnDelete);
            this.gpOperations.Controls.Add(this.btnEdit);
            this.gpOperations.Controls.Add(this.btnSearch);
            this.gpOperations.Controls.Add(this.btnInsert);
            this.gpOperations.Location = new System.Drawing.Point(4, 506);
            this.gpOperations.Name = "gpOperations";
            this.gpOperations.Size = new System.Drawing.Size(396, 70);
            this.gpOperations.TabIndex = 19;
            this.gpOperations.TabStop = false;
            this.gpOperations.Text = "Operations";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Salmon;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(9, 24);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(103, 24);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 30);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(203, 24);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.Location = new System.Drawing.Point(297, 24);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(2);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(90, 30);
            this.btnInsert.TabIndex = 9;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // FrmRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(404, 581);
            this.Controls.Add(this.gpOperations);
            this.Controls.Add(this.tabPerson);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.Load += new System.EventHandler(this.FrmRegistration_Load);
            this.tabPerson.ResumeLayout(false);
            this.tabPagePhysicalPerson.ResumeLayout(false);
            this.tabPagePhysicalPerson.PerformLayout();
            this.gpStatusPP.ResumeLayout(false);
            this.gpStatusPP.PerformLayout();
            this.gpGender.ResumeLayout(false);
            this.gpGender.PerformLayout();
            this.tabPageJuridicalPerson.ResumeLayout(false);
            this.tabPageJuridicalPerson.PerformLayout();
            this.gpStatusJP.ResumeLayout(false);
            this.gpStatusJP.PerformLayout();
            this.gpOperations.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPP;
        private System.Windows.Forms.Label lblNamePP;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.TextBox txtEmailPP;
        private System.Windows.Forms.Label lblEmailPP;
        private System.Windows.Forms.TextBox txtNamePP;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.DateTimePicker dtBirthday;
        private System.Windows.Forms.TabControl tabPerson;
        private System.Windows.Forms.TabPage tabPagePhysicalPerson;
        private System.Windows.Forms.TabPage tabPageJuridicalPerson;
        private System.Windows.Forms.TextBox txtCommentPP;
        private System.Windows.Forms.Label lblCommentPP;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.GroupBox gpOperations;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnClearJP;
        private System.Windows.Forms.TextBox txtCommentJP;
        private System.Windows.Forms.Label lblCommentJP;
        private System.Windows.Forms.Label lblCNPJ;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblJP;
        private System.Windows.Forms.Label lblNameJP;
        private System.Windows.Forms.TextBox txtNameJP;
        private System.Windows.Forms.Label lblEmailJP;
        private System.Windows.Forms.TextBox txtEmailJP;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Button btnClearPP;
        private System.Windows.Forms.GroupBox gpStatusPP;
        private System.Windows.Forms.RadioButton rdInactivePP;
        private System.Windows.Forms.RadioButton rdActivePP;
        private System.Windows.Forms.GroupBox gpGender;
        private System.Windows.Forms.RadioButton rdFemale;
        private System.Windows.Forms.RadioButton rdMale;
        private System.Windows.Forms.GroupBox gpStatusJP;
        private System.Windows.Forms.RadioButton rdInactiveJP;
        private System.Windows.Forms.RadioButton rdActiveJP;
        private System.Windows.Forms.MaskedTextBox mskTextCPF;
        private System.Windows.Forms.MaskedTextBox mskTextCNPJ;
    }
}