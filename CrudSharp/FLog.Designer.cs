namespace CrudSharp
{
    partial class FrmLog
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
            this.lblLog = new System.Windows.Forms.Label();
            this.gpLogFileData = new System.Windows.Forms.GroupBox();
            this.txtUpdateDate = new System.Windows.Forms.TextBox();
            this.lblUpdateDate = new System.Windows.Forms.Label();
            this.txtCreateAt = new System.Windows.Forms.TextBox();
            this.lblCreateAt = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtNameFile = new System.Windows.Forms.TextBox();
            this.lblNameFile = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.gpLogFileData.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(12, 9);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(45, 24);
            this.lblLog.TabIndex = 0;
            this.lblLog.Text = "Log";
            // 
            // gpLogFileData
            // 
            this.gpLogFileData.Controls.Add(this.txtUpdateDate);
            this.gpLogFileData.Controls.Add(this.lblUpdateDate);
            this.gpLogFileData.Controls.Add(this.txtCreateAt);
            this.gpLogFileData.Controls.Add(this.lblCreateAt);
            this.gpLogFileData.Controls.Add(this.txtSize);
            this.gpLogFileData.Controls.Add(this.lblSize);
            this.gpLogFileData.Controls.Add(this.txtNameFile);
            this.gpLogFileData.Controls.Add(this.lblNameFile);
            this.gpLogFileData.Location = new System.Drawing.Point(16, 36);
            this.gpLogFileData.Name = "gpLogFileData";
            this.gpLogFileData.Size = new System.Drawing.Size(260, 245);
            this.gpLogFileData.TabIndex = 1;
            this.gpLogFileData.TabStop = false;
            this.gpLogFileData.Text = "Log File Data";
            // 
            // txtUpdateDate
            // 
            this.txtUpdateDate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtUpdateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUpdateDate.ForeColor = System.Drawing.Color.Navy;
            this.txtUpdateDate.Location = new System.Drawing.Point(10, 201);
            this.txtUpdateDate.Name = "txtUpdateDate";
            this.txtUpdateDate.ReadOnly = true;
            this.txtUpdateDate.Size = new System.Drawing.Size(240, 26);
            this.txtUpdateDate.TabIndex = 7;
            this.txtUpdateDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUpdateDate.Enter += new System.EventHandler(this.txtUpdateDate_Enter);
            // 
            // lblUpdateDate
            // 
            this.lblUpdateDate.AutoSize = true;
            this.lblUpdateDate.Location = new System.Drawing.Point(6, 178);
            this.lblUpdateDate.Name = "lblUpdateDate";
            this.lblUpdateDate.Size = new System.Drawing.Size(130, 20);
            this.lblUpdateDate.TabIndex = 6;
            this.lblUpdateDate.Text = "File Update Date";
            // 
            // txtCreateAt
            // 
            this.txtCreateAt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCreateAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreateAt.ForeColor = System.Drawing.Color.Navy;
            this.txtCreateAt.Location = new System.Drawing.Point(10, 149);
            this.txtCreateAt.Name = "txtCreateAt";
            this.txtCreateAt.ReadOnly = true;
            this.txtCreateAt.Size = new System.Drawing.Size(240, 26);
            this.txtCreateAt.TabIndex = 5;
            this.txtCreateAt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCreateAt.Enter += new System.EventHandler(this.txtCreateAt_Enter);
            // 
            // lblCreateAt
            // 
            this.lblCreateAt.AutoSize = true;
            this.lblCreateAt.Location = new System.Drawing.Point(6, 126);
            this.lblCreateAt.Name = "lblCreateAt";
            this.lblCreateAt.Size = new System.Drawing.Size(125, 20);
            this.lblCreateAt.TabIndex = 4;
            this.lblCreateAt.Text = "File Create Date";
            // 
            // txtSize
            // 
            this.txtSize.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSize.ForeColor = System.Drawing.Color.Navy;
            this.txtSize.Location = new System.Drawing.Point(10, 97);
            this.txtSize.Name = "txtSize";
            this.txtSize.ReadOnly = true;
            this.txtSize.Size = new System.Drawing.Size(240, 26);
            this.txtSize.TabIndex = 3;
            this.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSize.Enter += new System.EventHandler(this.txtSize_Enter);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(6, 74);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(69, 20);
            this.lblSize.TabIndex = 2;
            this.lblSize.Text = "Size File";
            // 
            // txtNameFile
            // 
            this.txtNameFile.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtNameFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameFile.ForeColor = System.Drawing.Color.Navy;
            this.txtNameFile.Location = new System.Drawing.Point(10, 45);
            this.txtNameFile.Name = "txtNameFile";
            this.txtNameFile.ReadOnly = true;
            this.txtNameFile.Size = new System.Drawing.Size(240, 26);
            this.txtNameFile.TabIndex = 1;
            this.txtNameFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNameFile.Enter += new System.EventHandler(this.txtNameFile_Enter);
            // 
            // lblNameFile
            // 
            this.lblNameFile.AutoSize = true;
            this.lblNameFile.Location = new System.Drawing.Point(6, 22);
            this.lblNameFile.Name = "lblNameFile";
            this.lblNameFile.Size = new System.Drawing.Size(105, 20);
            this.lblNameFile.TabIndex = 0;
            this.lblNameFile.Text = "Log Filename";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Salmon;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(16, 287);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(125, 40);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Location = new System.Drawing.Point(147, 287);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(125, 40);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // FrmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 341);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.gpLogFileData);
            this.Controls.Add(this.lblLog);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log";
            this.Load += new System.EventHandler(this.FrmLog_Load);
            this.gpLogFileData.ResumeLayout(false);
            this.gpLogFileData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.GroupBox gpLogFileData;
        private System.Windows.Forms.TextBox txtUpdateDate;
        private System.Windows.Forms.Label lblUpdateDate;
        private System.Windows.Forms.TextBox txtCreateAt;
        private System.Windows.Forms.Label lblCreateAt;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtNameFile;
        private System.Windows.Forms.Label lblNameFile;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnOpen;
    }
}