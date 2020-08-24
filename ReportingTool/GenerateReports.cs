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
    class GenerateReports
    {
        private static string getFilePath()
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "PDF(*.pdf)|*.pdf";
            saveDlg.FilterIndex = 0;
            saveDlg.RestoreDirectory = true;
            saveDlg.Title = "SAVE FILE";
            string filePath = "";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                filePath = saveDlg.FileName;
            }
            return filePath;
        }
      
        public static void LoginReport()
        {
            try
            {
                ReportDocument myReport = new ReportDocument();
                string reportPath = (Application.StartupPath + @"\Reports\LoginReport.rpt");
                myReport.Load(reportPath);
                string filepath = getFilePath(); ;
                if (filepath!=string.Empty)
                {  
                    myReport.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    MD5Check.GetMD5HashCode(filepath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void AlarmReport()
        {
            try
            {
                ReportDocument myReport = new ReportDocument();
                string reportPath = (Application.StartupPath + @"\Reports\AlarmReport.rpt");
                myReport.Load(reportPath);
                string filepath = getFilePath(); ;
                if (filepath != string.Empty)
                {
                    myReport.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    MD5Check.GetMD5HashCode(filepath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void BatchReport()
        {
            try
            {
                ReportDocument myReport = new ReportDocument();
                string reportPath = (Application.StartupPath + @"\Reports\BatchReport.rpt");
                myReport.Load(reportPath);
                string filepath = getFilePath(); ;
                if (filepath != string.Empty)
                {
                    myReport.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    MD5Check.GetMD5HashCode(filepath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void OperationReport()
        {
            try
            {
                ReportDocument myReport = new ReportDocument();
                string reportPath = (Application.StartupPath + @"\Reports\OperationReport.rpt");
                myReport.Load(reportPath);
                string filepath = getFilePath(); ;
                if (filepath != string.Empty)
                {
                    myReport.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    MD5Check.GetMD5HashCode(filepath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void ParameterReport()
        {
            try
            {
                ReportDocument myReport = new ReportDocument();
                string reportPath = (Application.StartupPath + @"\Reports\ParameterReport.rpt");
                myReport.Load(reportPath);
                string filepath = getFilePath(); ;
                if (filepath != string.Empty)
                {
                    myReport.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    MD5Check.GetMD5HashCode(filepath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
