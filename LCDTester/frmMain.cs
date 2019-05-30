using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LCDTester
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }




        #region 防止屏幕闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion


        private void LoadUI()
        {
            this.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Maximized;
            p.CheckFolder();
            p.CreateIni();
            p.ReadIni();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadUI();
        }
    }
}
