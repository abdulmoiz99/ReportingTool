using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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
            GenerateReports.LoginReport();
        }

        private void btn_AlarmReport_Click(object sender, EventArgs e)
        {
            GenerateReports.AlarmReport();

        }
    }
}
