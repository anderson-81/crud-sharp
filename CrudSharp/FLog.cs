using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudSharp
{
    public partial class FrmLog : Form
    {
        public FrmLog()
        {
            InitializeComponent();
        }

        private void txtNameFile_Enter(object sender, EventArgs e)
        {
            btnOpen.Focus();
        }

        private void txtSize_Enter(object sender, EventArgs e)
        {
            btnOpen.Focus();
        }

        private void txtCreateAt_Enter(object sender, EventArgs e)
        {
            btnOpen.Focus();
        }

        private void txtUpdateDate_Enter(object sender, EventArgs e)
        {
            btnOpen.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want delete the log file?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    if (File.Exists("log.txt"))
                    {
                        File.Delete("log.txt");
                        MessageBox.Show("Successfully deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Not found log file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error opening log file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("log.txt"))
                {
                    Process.Start("notepad.exe", "log.txt");
                }
                else
                {
                    MessageBox.Show("Not found log file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error opening log file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetLogFileInformation()
        {
            this.Enabled = false;
            try
            {
                if (File.Exists("log.txt"))
                {
                    FileInfo file = new FileInfo("log.txt");
                    txtNameFile.Text = file.Name;
                    txtSize.Text = FormatSize(file.Length);
                    txtCreateAt.Text = file.CreationTime.ToString();
                    txtUpdateDate.Text = file.LastWriteTime.ToString();
                    this.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Not found log file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error opening log file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtNameFile.Clear();
            txtSize.Clear();
            txtCreateAt.Clear();
            txtUpdateDate.Clear();
            btnDelete.Enabled = false;
            btnOpen.Enabled = false;
            this.Close();
        }
        

        #region Convert Bytes To KB, MB In C#
        // Font: https://www.c-sharpcorner.com/article/csharp-convert-bytes-to-kb-mb-gb/
        private readonly string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };
        private string FormatSize(Int64 bytes)
        {
            int counter = 0;
            decimal number = (decimal)bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number = number / 1024;
                counter++;
            }
            return string.Format("{0:n1}{1}", number, suffixes[counter]);
        }
        #endregion

        private void FrmLog_Load(object sender, EventArgs e)
        {
            GetLogFileInformation();
        }
    }
}
