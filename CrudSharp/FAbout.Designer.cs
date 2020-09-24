namespace CrudSharp
{
    partial class FrmAbout
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
            this.pictureAbout = new System.Windows.Forms.PictureBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtBuildDate = new System.Windows.Forms.TextBox();
            this.lblBuildDate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureAbout
            // 
            this.pictureAbout.BackgroundImage = global::CrudSharp.Properties.Resources.back;
            this.pictureAbout.Location = new System.Drawing.Point(0, 0);
            this.pictureAbout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureAbout.Name = "pictureAbout";
            this.pictureAbout.Size = new System.Drawing.Size(620, 360);
            this.pictureAbout.TabIndex = 0;
            this.pictureAbout.TabStop = false;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(12, 365);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(64, 20);
            this.lblProduct.TabIndex = 1;
            this.lblProduct.Text = "Product";
            // 
            // txtProduct
            // 
            this.txtProduct.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtProduct.Location = new System.Drawing.Point(16, 388);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.ReadOnly = true;
            this.txtProduct.Size = new System.Drawing.Size(250, 26);
            this.txtProduct.TabIndex = 0;
            this.txtProduct.Text = "Registration System";
            this.txtProduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProduct.Enter += new System.EventHandler(this.txtProduct_Enter);
            // 
            // txtVersion
            // 
            this.txtVersion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtVersion.Location = new System.Drawing.Point(16, 440);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(250, 26);
            this.txtVersion.TabIndex = 1;
            this.txtVersion.Text = "2.0-beta";
            this.txtVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVersion.Enter += new System.EventHandler(this.txtVersion_Enter);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(12, 417);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(63, 20);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "Version";
            // 
            // txtAuthor
            // 
            this.txtAuthor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtAuthor.Location = new System.Drawing.Point(362, 388);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(250, 26);
            this.txtAuthor.TabIndex = 2;
            this.txtAuthor.Text = "Anderson";
            this.txtAuthor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAuthor.Enter += new System.EventHandler(this.txtAuthor_Enter);
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(358, 365);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(57, 20);
            this.lblAuthor.TabIndex = 6;
            this.lblAuthor.Text = "Author";
            // 
            // txtBuildDate
            // 
            this.txtBuildDate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtBuildDate.Location = new System.Drawing.Point(362, 440);
            this.txtBuildDate.Name = "txtBuildDate";
            this.txtBuildDate.ReadOnly = true;
            this.txtBuildDate.Size = new System.Drawing.Size(250, 26);
            this.txtBuildDate.TabIndex = 3;
            this.txtBuildDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBuildDate.Enter += new System.EventHandler(this.txtBuildDate_Enter);
            // 
            // lblBuildDate
            // 
            this.lblBuildDate.AutoSize = true;
            this.lblBuildDate.Location = new System.Drawing.Point(358, 417);
            this.lblBuildDate.Name = "lblBuildDate";
            this.lblBuildDate.Size = new System.Drawing.Size(92, 20);
            this.lblBuildDate.TabIndex = 8;
            this.lblBuildDate.Text = "Compilation";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Salmon;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(215, 489);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(200, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 531);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtBuildDate);
            this.Controls.Add(this.lblBuildDate);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.pictureAbout);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureAbout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureAbout;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtBuildDate;
        private System.Windows.Forms.Label lblBuildDate;
        private System.Windows.Forms.Button btnClose;
    }
}