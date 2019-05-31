using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Edward;
using HalconDotNet;

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

        #region 界面移动
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        #endregion

        private bool IsRuning = false;

       

        private void LoadUI()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = p.AppTitle;
            lblTitle.Text = p.AppTitle;
            txtImgFile.SetWatermark("雙擊此處選擇圖像文件.");
            p.CheckFolder();
            p.CreateIni();
            p.ReadIni();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadUI();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            if (!IsRuning)
            {
                DialogResult dr = MessageBox.Show("是否確認退出軟件,退出點擊是(Y),不退出點擊否(N)?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        Environment.Exit(0);
                    }
                    catch (Exception)
                    {

                    }

                }
            }
        }

        private void lblMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Transparent;
        }

        private void lblClose_MouseMove(object sender, MouseEventArgs e)
        {
            lblClose.BackColor = Color.Red;
        }

        private void txtImgFile_DoubleClick(object sender, EventArgs e)
        {

            openfile(txtImgFile);

        }


        private void openfile(TextBox textbox)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textbox.Text = open.FileName;
               // DispImg(textbox.Text.Trim());
            }



        }

        private void btnCreateRoi_Click(object sender, EventArgs e)
        {
            HDevelopExport HD = new HDevelopExport();
            HD.RunHalcon(hWindowControl1.HalconWindow);
            
            
           
            
        }


        //private void DispImg(string imgpath)
        //{
        //    HObject ho_Image;
        //    HTuple hv_Width = null, hv_Height = null;
        //    HOperatorSet.ReadImage(out ho_Image, imgpath);
        //    HOperatorSet.GetImageSize(ho_Image, out hv_Height, out hv_Height);
        //    HOperatorSet.SetPart(hWindowControl1.HalconWindow, 0, 0, hv_Height , hv_Width );
        //    HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
        //    ho_Image.Dispose();

        //}






    }
}
