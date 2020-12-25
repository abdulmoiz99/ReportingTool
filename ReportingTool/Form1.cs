using System;
using System.Windows.Forms;

namespace ReportingTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_MD5Check_Click(object sender, EventArgs e)
        {
            var openDlg = new OpenFileDialog();
            openDlg.Filter = "PDF(*.pdf)|*.pdf";
            openDlg.FilterIndex = 0;
            openDlg.RestoreDirectory = true;
            openDlg.Title = "OPEN FILE";
            string filePath = "";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                filePath = openDlg.FileName;
                MD5Check.CheckHashCode(filePath);
            }
        }
        private void btn_LoginReport_Click(object sender, EventArgs e)
        {
           // GenerateReports.LoginReport();
        }
        private void btn_AlarmReport_Click(object sender, EventArgs e)
        {
            //GenerateReports.AlarmReport();
        }
        //Batch Report Still Need Some Major Fixes
        private void bnt_BatchReport_Click(object sender, EventArgs e)
        {
            GenerateReports.BatchReport();
        }
        private void btn_OperationReport_Click(object sender, EventArgs e)
        {
            GenerateReports.OperationReport();
        }
        //Spacing Issue In Parameter Report
        private void bnt_ParameterReport_Click(object sender, EventArgs e)
        {
            GenerateReports.ParameterReport();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                mynotifyicon.Visible = true;
               // mynotifyicon.ShowBalloonTip(500);
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                mynotifyicon.Visible = false;
            }
        }
    }
}
