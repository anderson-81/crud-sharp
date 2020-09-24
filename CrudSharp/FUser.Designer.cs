namespace CrudSharp
{
    partial class FrmUser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUser));
            this.gpUserData = new System.Windows.Forms.GroupBox();
            this.lblCreateAt = new System.Windows.Forms.Label();
            this.txtCreateAt = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbTypeUser = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gpOperations = new System.Windows.Forms.GroupBox();
            this.btnList = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblList = new System.Windows.Forms.Label();
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.clID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCreateAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUserTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpUserData.SuspendLayout();
            this.gpOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            this.SuspendLayout();
            // 
            // gpUserData
            // 
            this.gpUserData.Controls.Add(this.lblCreateAt);
            this.gpUserData.Controls.Add(this.txtCreateAt);
            this.gpUserData.Controls.Add(this.lblName);
            this.gpUserData.Controls.Add(this.txtName);
            this.gpUserData.Controls.Add(this.cmbTypeUser);
            this.gpUserData.Controls.Add(this.lblType);
            this.gpUserData.Controls.Add(this.txtPassword);
            this.gpUserData.Controls.Add(this.lblPassword);
            this.gpUserData.Controls.Add(this.txtUsername);
            this.gpUserData.Controls.Add(this.lblUsername);
            this.gpUserData.Location = new System.Drawing.Point(12, 36);
            this.gpUserData.Name = "gpUserData";
            this.gpUserData.Size = new System.Drawing.Size(400, 300);
            this.gpUserData.TabIndex = 1;
            this.gpUserData.TabStop = false;
            this.gpUserData.Text = "User\'s Data";
            // 
            // lblCreateAt
            // 
            this.lblCreateAt.AutoSize = true;
            this.lblCreateAt.Location = new System.Drawing.Point(221, 232);
            this.lblCreateAt.Name = "lblCreateAt";
            this.lblCreateAt.Size = new System.Drawing.Size(77, 20);
            this.lblCreateAt.TabIndex = 8;
            this.lblCreateAt.Text = "Create At";
            // 
            // txtCreateAt
            // 
            this.txtCreateAt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCreateAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreateAt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCreateAt.Location = new System.Drawing.Point(225, 255);
            this.txtCreateAt.MaxLength = 45;
            this.txtCreateAt.Name = "txtCreateAt";
            this.txtCreateAt.ReadOnly = true;
            this.txtCreateAt.Size = new System.Drawing.Size(155, 26);
            this.txtCreateAt.TabIndex = 7;
            this.txtCreateAt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCreateAt.Enter += new System.EventHandler(this.txtCreateAt_Enter);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Location = new System.Drawing.Point(10, 45);
            this.txtName.MaxLength = 45;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(370, 26);
            this.txtName.TabIndex = 0;
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // cmbTypeUser
            // 
            this.cmbTypeUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeUser.FormattingEnabled = true;
            this.cmbTypeUser.Items.AddRange(new object[] {
            "User",
            "Administrator"});
            this.cmbTypeUser.Location = new System.Drawing.Point(10, 201);
            this.cmbTypeUser.Name = "cmbTypeUser";
            this.cmbTypeUser.Size = new System.Drawing.Size(370, 28);
            this.cmbTypeUser.TabIndex = 3;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 178);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(81, 20);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type User";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(10, 149);
            this.txtPassword.MaxLength = 45;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(370, 26);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(6, 126);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(78, 20);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(10, 97);
            this.txtUsername.MaxLength = 45;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(370, 26);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(6, 74);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(83, 20);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(8, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(53, 24);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "User";
            // 
            // gpOperations
            // 
            this.gpOperations.Controls.Add(this.btnList);
            this.gpOperations.Controls.Add(this.btnDelete);
            this.gpOperations.Controls.Add(this.btnEdit);
            this.gpOperations.Controls.Add(this.btnInsert);
            this.gpOperations.Location = new System.Drawing.Point(12, 342);
            this.gpOperations.Name = "gpOperations";
            this.gpOperations.Size = new System.Drawing.Size(400, 79);
            this.gpOperations.TabIndex = 3;
            this.gpOperations.TabStop = false;
            this.gpOperations.Text = "Operations";
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.ForeColor = System.Drawing.Color.White;
            this.btnList.Location = new System.Drawing.Point(204, 24);
            this.btnList.Margin = new System.Windows.Forms.Padding(2);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(90, 30);
            this.btnList.TabIndex = 11;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Salmon;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(10, 24);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(104, 24);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 30);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.Location = new System.Drawing.Point(298, 24);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(2);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(90, 30);
            this.btnInsert.TabIndex = 4;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkGray;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(323, 7);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblList.Location = new System.Drawing.Point(12, 424);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(41, 24);
            this.lblList.TabIndex = 11;
            this.lblList.Text = "List";
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.AllowUserToAddRows = false;
            this.dataGridViewUser.AllowUserToDeleteRows = false;
            this.dataGridViewUser.AllowUserToResizeColumns = false;
            this.dataGridViewUser.AllowUserToResizeRows = false;
            this.dataGridViewUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewUser.CausesValidation = false;
            this.dataGridViewUser.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridViewUser.ColumnHeadersHeight = 25;
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clID,
            this.clName,
            this.clUsername,
            this.clPassword,
            this.clCreateAt,
            this.clUserType,
            this.clUserTypeName});
            this.dataGridViewUser.Location = new System.Drawing.Point(12, 451);
            this.dataGridViewUser.MultiSelect = false;
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.ReadOnly = true;
            this.dataGridViewUser.RowHeadersVisible = false;
            this.dataGridViewUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewUser.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUser.ShowCellErrors = false;
            this.dataGridViewUser.ShowCellToolTips = false;
            this.dataGridViewUser.ShowEditingIcon = false;
            this.dataGridViewUser.ShowRowErrors = false;
            this.dataGridViewUser.Size = new System.Drawing.Size(400, 120);
            this.dataGridViewUser.TabIndex = 15;
            this.dataGridViewUser.Visible = false;
            this.dataGridViewUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUser_CellClick);
            this.dataGridViewUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUser_CellDoubleClick);
            // 
            // clID
            // 
            this.clID.DataPropertyName = "Id";
            this.clID.HeaderText = "ID";
            this.clID.MaxInputLength = 10;
            this.clID.Name = "clID";
            this.clID.ReadOnly = true;
            this.clID.Visible = false;
            this.clID.Width = 129;
            // 
            // clName
            // 
            this.clName.DataPropertyName = "Name";
            this.clName.HeaderText = "NAME";
            this.clName.MaxInputLength = 45;
            this.clName.Name = "clName";
            this.clName.ReadOnly = true;
            this.clName.Width = 265;
            // 
            // clUsername
            // 
            this.clUsername.DataPropertyName = "Username";
            this.clUsername.HeaderText = "USERNAME";
            this.clUsername.MaxInputLength = 128;
            this.clUsername.Name = "clUsername";
            this.clUsername.ReadOnly = true;
            this.clUsername.Visible = false;
            // 
            // clPassword
            // 
            this.clPassword.DataPropertyName = "Password";
            this.clPassword.HeaderText = "PASSWORD";
            this.clPassword.MaxInputLength = 128;
            this.clPassword.Name = "clPassword";
            this.clPassword.ReadOnly = true;
            this.clPassword.Visible = false;
            // 
            // clCreateAt
            // 
            this.clCreateAt.DataPropertyName = "CreateAt";
            this.clCreateAt.HeaderText = "CREATEAT";
            this.clCreateAt.MaxInputLength = 30;
            this.clCreateAt.Name = "clCreateAt";
            this.clCreateAt.ReadOnly = true;
            this.clCreateAt.Visible = false;
            // 
            // clUserType
            // 
            this.clUserType.DataPropertyName = "UserType";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clUserType.DefaultCellStyle = dataGridViewCellStyle1;
            this.clUserType.HeaderText = "USERTYPE";
            this.clUserType.MaxInputLength = 1;
            this.clUserType.Name = "clUserType";
            this.clUserType.ReadOnly = true;
            this.clUserType.Visible = false;
            this.clUserType.Width = 132;
            // 
            // clUserTypeName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clUserTypeName.DefaultCellStyle = dataGridViewCellStyle2;
            this.clUserTypeName.HeaderText = "USERTYPE";
            this.clUserTypeName.MaxInputLength = 15;
            this.clUserTypeName.Name = "clUserTypeName";
            this.clUserTypeName.ReadOnly = true;
            this.clUserTypeName.Width = 132;
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 431);
            this.Controls.Add(this.dataGridViewUser);
            this.Controls.Add(this.lblList);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.gpOperations);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gpUserData);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User";
            this.Load += new System.EventHandler(this.FrmUser_Load);
            this.gpUserData.ResumeLayout(false);
            this.gpUserData.PerformLayout();
            this.gpOperations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpUserData;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ComboBox cmbTypeUser;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.GroupBox gpOperations;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dataGridViewUser;
        private System.Windows.Forms.Label lblCreateAt;
        private System.Windows.Forms.TextBox txtCreateAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn clID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCreateAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUserTypeName;

    }
}