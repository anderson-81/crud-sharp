﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrudSharp
{
    public partial class FrmBornMonth : Form
    {
        private void FrmBornMonth_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}