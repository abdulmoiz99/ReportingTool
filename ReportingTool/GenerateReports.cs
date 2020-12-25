using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;


namespace ReportingTool
{

    class GenerateReports
    {
        private static readonly Random random = new Random();
        //private static SqlConnection con = new SqlConnection(@"Data Source=.\ABDUL;Initial Catalog=ReportingToolDummyDatabase;Integrated Security=True;Pooling=False");// ReadCS().ToString()); 
        public static string SaveReportPath = @"D:\Abdul";                                                                                                                                                               // private static SqlConnection con = new SqlConnection(@"Data Source=AVF-108_ADMIN\SQLEXPRESS;Initial Catalog=ReportingTool;Integrated Security=True;Pooling=False");// ReadCS().ToString()); 

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
        public static bool CheckToGenerateReport()
        {
            int count = 0;
            if (int.TryParse(SQL.ScalarQuery("select Count(*) from Hand_Shake where Generation_Code = 0"), out count))
            {
                if (count > 0) return true;
            }
            return false;
        }
        public static void Report()
        {
            int ID = 0;
            if (int.TryParse(SQL.ScalarQuery("select Top 1 SN from Hand_Shake where Generation_Code = 0"), out ID))
            {
                string reportID = SQL.ScalarQuery("select IsNull(Report_Type,0) as ReprtType from Hand_Shake where SN = " + ID + "");

                switch (reportID)
                {
                    case "1":
                        LoginReport(ID);
                        break;
                    case "2":
                        AlarmReport(ID);
                        break;
                    case "3":
                        BatchReport();
                        break;
                    case "4":
                        OperationReport();
                        break;
                    case "5":
                        ParameterReport();
                        break;
                    default:
                        InvalidReport(ID);
                        break;
                }
            }
        }
        private static void InvalidReport(int ID)
        {
            SQL.NonScalarQuery("update Hand_Shake set Generation_Code = 1 , Feedback_Code = 2 where SN  = " + ID + "");

        }
        public static void LoginReport(int ID)
        {
            SQL.NonScalarQuery("update Hand_Shake set Generation_Code = 1 , Feedback_Code = 1 where sn  = " + ID + "");

            try
            {


                if (SQL.Con.State != ConnectionState.Open) SQL.Con.Open();
                ReportDocument myReport = new ReportDocument();
                string reportPath = (Application.StartupPath + @"\Reports\LoginReport.rpt");
                var ds = new DataSet();
                String SqlQuery = "select * from Login where Time between (select Start_Time from hand_shake where SN =  " + ID + ") and (select End_Time from hand_shake where SN =  " + ID + ")";
                var adapter = new SqlDataAdapter(SqlQuery, SQL.Con);
                adapter.Fill(ds, "Login");
                myReport.Load(reportPath);
                myReport.SetDataSource(ds);
                myReport.SetParameterValue("username", GetUsername(ID));
                myReport.SetParameterValue("ReportSN", GetReportSN(ID, "Login"));
                myReport.SetParameterValue("startTime", GetStartTime(ID));
                myReport.SetParameterValue("endTime", GetEndTime(ID));
                myReport.SetParameterValue("operator", GetOperator(ID));
                myReport.SetParameterValue("supervisor", GetSupervisor(ID));
                myReport.SetParameterValue("Title", GetTittle(ID));


                string fileName = GetFileName("LoginReport");// @"\Login_" + DateTime.Now.ToFileTime() + ".pdf";
                string filepath = SaveReportPath + fileName;// @"\LoginReport.pdf";
                if (filepath != string.Empty)
                {
                    myReport.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    UpdateMD5Code(ID, MD5Check.GetMD5HashCode(filepath));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void AlarmReport(int ID)
        {
            SQL.NonScalarQuery("update Hand_Shake set Generation_Code = 1 , Feedback_Code = 1 where sn  = " + ID + "");

            try
            {


                if (SQL.Con.State != ConnectionState.Open) SQL.Con.Open();
                ReportDocument myReport = new ReportDocument();
                string reportPath = (Application.StartupPath + @"\Reports\AlarmReport.rpt");
                var ds = new DataSet();
                String SqlQuery = "select * from Alarm where StartTime between (select Start_Time from hand_shake where SN =  " + ID + ") and (select End_Time from hand_shake where SN =  " + ID + ")";
                var adapter = new SqlDataAdapter(SqlQuery, SQL.Con);
                adapter.Fill(ds, "Alarm");
                myReport.Load(reportPath);
                myReport.SetDataSource(ds);
                myReport.SetParameterValue("username", GetUsername(ID));
                myReport.SetParameterValue("ReportSN", GetReportSN(ID, "Alarm"));
                myReport.SetParameterValue("startTime", GetStartTime(ID));
                myReport.SetParameterValue("endTime", GetEndTime(ID));
                myReport.SetParameterValue("operator", GetOperator(ID));
                myReport.SetParameterValue("supervisor", GetSupervisor(ID));
                myReport.SetParameterValue("Title", GetTittle(ID));


                string fileName = GetFileName("AlarmReport");
                string filepath = SaveReportPath + fileName;
                if (filepath != string.Empty)
                {
                    myReport.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    UpdateMD5Code(ID, MD5Check.GetMD5HashCode(filepath));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void UpdateMD5Code(int ID, string HASHCODE)
        {
            SQL.NonScalarQuery("update Hand_Shake set MD5_Code = '" + HASHCODE + "' where sn = " + ID + "");
        }
        public static string GetReportSN(int ID, string SN_Name)
        {
            string ReportSN = SN_Name + " - " + random.Next(0, 1000);
            SQL.NonScalarQuery("update Hand_Shake set Report_SN = '" + ReportSN + "' where sn = " + ID + "");
            return ReportSN;
        }
        public static string GetUsername(int ID)
        {
            return SQL.ScalarQuery("select ISNull(username,0) from Hand_Shake where SN = " + ID + "");
        }
        public static string GetStartTime(int ID)
        {
            return SQL.ScalarQuery("select ISNull(Start_Time,0) from Hand_Shake where SN = " + ID + "");
        }
        public static string GetEndTime(int ID)
        {
            return SQL.ScalarQuery("select ISNull(End_Time,0) from Hand_Shake where SN = " + ID + "");
        }
        public static string GetOperator(int ID)
        {
            return SQL.ScalarQuery("select ISNull(Operator_Name,0) from Hand_Shake where SN = " + ID + "");
        }
        public static string GetSupervisor(int ID)
        {
            return SQL.ScalarQuery("select ISNull(Supervisor_Name,0) from Hand_Shake where SN = " + ID + "");
        }
        public static string GetTittle(int ID)
        {
            return SQL.ScalarQuery("select ISNull(Title,0) from Hand_Shake where SN = " + ID + "");
        }
        private static string GetFileName(string ReportName)
        {
            string fileName = @"\" + ReportName + ".pdf";
            int count = 1;
            while (true)
            {
                if (File.Exists(SaveReportPath + fileName))
                {
                    fileName = @"\" + ReportName + "_" + count + ".pdf";
                    count++;
                }
                else break;
            }
            return fileName;
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
