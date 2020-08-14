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
      
        public static void LoginReport(int ID)
        {
            try
            {
                //if (SQL.Con.State == ConnectionState.Open)
                //{
                //    SQL.Con.Close();
                //}
                //SQL.Con.Open();
                // Cursor = Cursors.WaitCursor;
                ReportDocument myReport = new ReportDocument();
                string reportPath = (Application.StartupPath + @"\LoginReport.rpt");
                //var ds = new DataSet();
                //String SqlQuery = "select * from TvuRptDetails where ID  = " + ID + "";
                //var adapter = new SqlDataAdapter(SqlQuery, SQL.Con);
                // adapter.Fill(ds, "TvuRptDetails");
                myReport.Load(reportPath);
                string filepath = getFilePath(); ;
                if (filepath!=string.Empty)
                {  
                    // myReport.SetDataSource(ds);
                    myReport.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    MD5Check.GetMD5HashCode(filepath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // SQL.Con.Close();
             //   Cursor = Cursors.Default;
            }
        }


    }
}
