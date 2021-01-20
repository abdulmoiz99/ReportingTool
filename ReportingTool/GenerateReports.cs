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
        public static string SaveReportPath = @"D:\Pika";                                                                                                                                                               // private static SqlConnection con = new SqlConnection(@"Data Source=AVF-108_ADMIN\SQLEXPRESS;Initial Catalog=ReportingTool;Integrated Security=True;Pooling=False");// ReadCS().ToString()); 

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
                string reportID = SQL.ScalarQuery("select IsNull(Report_Type,0) as ReportType from Hand_Shake where SN = " + ID + "");

                switch (reportID)
                {
                    case "1":
                        LoginReport(ID);
                        break;
                    case "2":
                        AlarmReport(ID);
                        break;
                    case "3":
                        BatchReport(ID);
                        break;
                    case "4":
                        OperationReport(ID);
                        break;
                    case "5":
                        ParameterReport(ID);
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
            Console.WriteLine(DateTime.Now + " - Invalid Report ID");
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
                Console.WriteLine(DateTime.Now + " - Login Report Generated");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(DateTime.Now + " -Unable To Generate Login Report");

            }
        }
        public static void AlarmReport(int ID)
        {
            SQL.NonScalarQuery("update Hand_Shake set Generation_Code = 1 , Feedback_Code = 1 where sn  = " + ID + "");

            try
            {
                string SqlQuery;

                if (GetSearchCondition(ID) == "1") // for time
                {
                    SqlQuery = "select * from Alarm where StartTime between (select Start_Time from hand_shake where SN =  " + ID + ") and (select End_Time from hand_shake where SN =  " + ID + ")";
                }
                else // for batch no
                {
                    SqlQuery = "select * from Alarm where Batch_No = (select batch_No from Hand_Shake where SN = " + ID + ")";
                }
                if (SQL.Con.State != ConnectionState.Open) SQL.Con.Open();
                ReportDocument myReport = new ReportDocument();
                string reportPath = (Application.StartupPath + @"\Reports\AlarmReport.rpt");
                var ds = new DataSet();

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
                Console.WriteLine(DateTime.Now + " - Alarm Report Generated");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(DateTime.Now + " -Unable To Generate Alarm Report");

            }
        }
        public static void OperationReport(int ID)
        {
            SQL.NonScalarQuery("update Hand_Shake set Generation_Code = 1 , Feedback_Code = 1 where sn  = " + ID + "");

            try
            {
                string SqlQuery;

                if (GetSearchCondition(ID) == "1") // for time
                {
                    SqlQuery = "select * from Operation where Time between (select Start_Time from hand_shake where SN =  " + ID + ") and (select End_Time from hand_shake where SN =  " + ID + ")";
                }
                else // for batch no
                {
                    SqlQuery = "select * from Operation where Batch_No = (select batch_No from Hand_Shake where SN = " + ID + ")";
                }
                if (SQL.Con.State != ConnectionState.Open) SQL.Con.Open();
                ReportDocument myReport = new ReportDocument();
                string reportPath = (Application.StartupPath + @"\Reports\OperationReport.rpt");
                var ds = new DataSet();

                var adapter = new SqlDataAdapter(SqlQuery, SQL.Con);
                adapter.Fill(ds, "Operation");
                myReport.Load(reportPath);
                myReport.SetDataSource(ds);
                myReport.SetParameterValue("username", GetUsername(ID));
                myReport.SetParameterValue("ReportSN", GetReportSN(ID, "Operation"));
                myReport.SetParameterValue("startTime", GetStartTime(ID));
                myReport.SetParameterValue("endTime", GetEndTime(ID));
                myReport.SetParameterValue("operator", GetOperator(ID));
                myReport.SetParameterValue("supervisor", GetSupervisor(ID));
                myReport.SetParameterValue("Title", GetTittle(ID));


                string fileName = GetFileName("OperationReport");
                string filepath = SaveReportPath + fileName;
                if (filepath != string.Empty)
                {
                    myReport.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    UpdateMD5Code(ID, MD5Check.GetMD5HashCode(filepath));
                }
                Console.WriteLine(DateTime.Now + " - Operation Report Generated");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(DateTime.Now + " -Unable To Generate Operation Report");

            }
        }
        public static void ParameterReport(int ID)
        {
            SQL.NonScalarQuery("update Hand_Shake set Generation_Code = 1 , Feedback_Code = 1 where sn  = " + ID + "");

            try
            {


                if (SQL.Con.State != ConnectionState.Open) SQL.Con.Open();
                ReportDocument myReport = new ReportDocument();
                string reportPath = (Application.StartupPath + @"\Reports\ParameterReport.rpt");
                var ds = new DataSet();
                String SqlQuery = GetParamterQuery(ID);
                var adapter = new SqlDataAdapter(SqlQuery, SQL.Con);
                adapter.Fill(ds, "Parameter");
                myReport.Load(reportPath);
                myReport.SetDataSource(ds);
                myReport.SetParameterValue("username", GetUsername(ID));
                myReport.SetParameterValue("ReportSN", GetReportSN(ID, "Parameter"));
                myReport.SetParameterValue("startTime", GetStartTime(ID));
                myReport.SetParameterValue("endTime", GetEndTime(ID));
                myReport.SetParameterValue("operator", GetOperator(ID));
                myReport.SetParameterValue("supervisor", GetSupervisor(ID));
                myReport.SetParameterValue("Title", GetTittle(ID));
                myReport.SetParameterValue("RecipeStart", GetRecipeStart(ID));
                myReport.SetParameterValue("RecipeEnd", GetRecipeEnd(ID));

                string fileName = GetFileName("ParameterReport");// @"\Login_" + DateTime.Now.ToFileTime() + ".pdf";
                string filepath = SaveReportPath + fileName;// @"\LoginReport.pdf";
                if (filepath != string.Empty)
                {
                    myReport.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    UpdateMD5Code(ID, MD5Check.GetMD5HashCode(filepath));
                }
                Console.WriteLine(DateTime.Now + " - Parameter Report Generated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(DateTime.Now + " -Unable To Generate Parameter Report");

            }
        }
        public static string GetParamterQuery(int ID)
        {
            string recepieStart = SQL.ScalarQuery("select IsNull(Recipe_No_Start,0) from Hand_Shake where SN  = " + ID + "");
            string recepieEnd = SQL.ScalarQuery("select IsNull(Recipe_No_End,0) from Hand_Shake where SN  = " + ID + "");
            if (recepieStart != "0" && recepieEnd == "0")
            {
                return "select * from Parameter where Recepie_No = " + recepieStart + "";
            }
            if (recepieStart == "0" && recepieEnd != "0")
            {
                return "select * from Parameter where Recepie_No = " + recepieEnd + "";

            }
            if (recepieStart != "0" && recepieEnd != "0")
            {
                return "select * from Parameter WHERE Recepie_No BETWEEN " + recepieStart + " AND " + recepieEnd + ";";
            }
            return "select * Parameter where Recepie_No  = -1";

        }
        public static string GetRecipeStart(int ID)
        {
            return SQL.ScalarQuery("select IsNull(Recipe_No_Start,'-') from Hand_Shake where SN  = " + ID + "");
        }
        public static string GetRecipeEnd(int ID)
        {
            return SQL.ScalarQuery("select IsNull(Recipe_No_End,'-') from Hand_Shake where SN  = " + ID + "");
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
        private static string GetSearchCondition(int ID)
        {
            return SQL.ScalarQuery("select ISNull(search_condition,1) from Hand_Shake where SN = " + ID + "");
        }
        public static void BatchReport(int ID)
        {
            SQL.NonScalarQuery("update Hand_Shake set Generation_Code = 1 , Feedback_Code = 1 where sn  = " + ID + "");

            try
            {
                string BatchNo = Batch.GetBatchNo(ID);
                string SqlQuery = "select * from Production_View where Batch_No = (select batch_No from Hand_Shake where SN = " + ID + ")";

                if (SQL.Con.State != ConnectionState.Open) SQL.Con.Open();
                ReportDocument myReport = new ReportDocument();
                string reportPath = (Application.StartupPath + @"\Reports\New Folder\BatchReport.rpt");
                myReport.Load(reportPath);
                var ds = new DataSet();


                SqlQuery = "select * from ProductionReport_View where Batch_No = (select batch_No from Hand_Shake where SN = " + ID + ")";
                var adapter = new SqlDataAdapter(SqlQuery, SQL.Con);
                adapter.Fill(ds, "ProductionReport_View");
                myReport.SetDataSource(ds);





                //FOR ALARM REPORT
                SqlQuery = "select * from Alarm where Batch_No = (select batch_No from Hand_Shake where SN = " + ID + ")";
                var Alarmds = new DataSet();
                var AlarmAdapter = new SqlDataAdapter(SqlQuery, SQL.Con);
                AlarmAdapter.Fill(Alarmds, "Alarm");
                myReport.Subreports[0].SetDataSource(Alarmds);


                //FOR OPERATION REPORT
                SqlQuery = "select * from Operation where Batch_No = (select batch_No from Hand_Shake where SN = " + ID + ")";
                var Operationds = new DataSet();
                var OperationAdapter = new SqlDataAdapter(SqlQuery, SQL.Con);
                OperationAdapter.Fill(Operationds, "Operation");
                myReport.Subreports[1].SetDataSource(Operationds);

                //FOR PARAMETER REPORT
                SqlQuery = Batch.GetParameterQuery(BatchNo);// "select * from Parameter";// where Recepie_No BETWEEN (select MIN(Recipe_No) from Production_View) AND  (select MAX(Recipe_No) from Production_View)";
                var Parameterds = new DataSet();
                var ParameterAdapter = new SqlDataAdapter(SqlQuery, SQL.Con);
                ParameterAdapter.Fill(Parameterds, "Parameter");
                myReport.Subreports[2].SetDataSource(Parameterds);


                //FOR PRODUCT REPORT
                SqlQuery = "select * from ProductionReport_View where Batch_No = (select batch_No from Hand_Shake where SN = " + ID + ")";
                var Productionadapter = new SqlDataAdapter(SqlQuery, SQL.Con);
                Productionadapter.Fill(ds, "ProductionReport_View");
                myReport.Subreports[3].SetDataSource(ds);

                //PARAMETER FOR MAIN REPORT
                myReport.SetParameterValue("Title", GetTittle(ID));
                myReport.SetParameterValue("Username", GetUsername(ID));
                myReport.SetParameterValue("ReportSN", GetReportSN(ID, "Batch"));
                myReport.SetParameterValue("RecipeNo", Batch.GetRecipeNo());
                myReport.SetParameterValue("ProductName", Batch.GetProductName());
                myReport.SetParameterValue("BatchNo", BatchNo);
                myReport.SetParameterValue("StartTime", GetStartTime(ID));
                myReport.SetParameterValue("EndTime", GetEndTime(ID));




                myReport.SetParameterValue("TotalRecord", Batch.GetTotalRecord(BatchNo));
                myReport.SetParameterValue("GoodCount", Batch.GetGoodCount(BatchNo));
                myReport.SetParameterValue("DefectCount", Batch.GetDefectCount(BatchNo));

                myReport.SetParameterValue("NoBottleCount", Batch.GetNoBottleSum(BatchNo));
                myReport.SetParameterValue("WrongBottleCount", Batch.GetWrongBottleSum(BatchNo));
                myReport.SetParameterValue("NoFillCount", Batch.GetNoFillSum(BatchNo));
                myReport.SetParameterValue("OverWeightCount", Batch.GetOverWeightSum(BatchNo));
                myReport.SetParameterValue("UnderWeightCount", Batch.GetUnderWeightSum(BatchNo));
                myReport.SetParameterValue("NoPlugCount", Batch.GetNoPlugSum(BatchNo));
                myReport.SetParameterValue("NoCapCount", Batch.GetNoCapSum(BatchNo));
                myReport.SetParameterValue("NoSealCount", Batch.GetNoSealSum(BatchNo));

                // MAX AVG MIN SD PARAMETERS
                myReport.SetParameterValue("NetWeightMax", Batch.GetNetWeightMax(BatchNo) + " g");
                myReport.SetParameterValue("NetWeightAverage", Batch.GetNetWeightAverage(BatchNo) + " g");
                myReport.SetParameterValue("NetWeightMin", Batch.GetNetWeightMin(BatchNo) + " g");
                myReport.SetParameterValue("NetWeightSD", Batch.GetNetWeightSD(BatchNo) + " g");

                myReport.SetParameterValue("GrossWeightMax", Batch.GetGrossWeightMax(BatchNo) + " g");
                myReport.SetParameterValue("GrossWeightMin", Batch.GetGrossWeightMin(BatchNo) + " g");
                myReport.SetParameterValue("GrossWeightAverage", Batch.GetGrossWeightAverage(BatchNo) + " g");
                myReport.SetParameterValue("GrossWeightSD", Batch.GetGrossWeightSD(BatchNo) + " g");

                myReport.SetParameterValue("FillingWeightMax", Batch.GetFillingWeightMax(BatchNo) + " g");
                myReport.SetParameterValue("FillingWeightAveage", Batch.GetFillingWeightAverage(BatchNo) + " g");
                myReport.SetParameterValue("FillingWeightMin", Batch.GetFillingWeightMin(BatchNo) + " g");
                myReport.SetParameterValue("FillingWeightSD", Batch.GetFillingWeightSD(BatchNo) + " g");

                myReport.SetParameterValue("FillingTimeMax", Batch.GetFillingTimeMax(BatchNo));
                myReport.SetParameterValue("FillingTimeAverage", Batch.GetFillingTimeMin(BatchNo));
                myReport.SetParameterValue("FillingTimeMin", Batch.GetFillingTimeMin(BatchNo));
                myReport.SetParameterValue("FillingTimeSD", Batch.GetFillingTimeSD(BatchNo));

                myReport.SetParameterValue("OperatorName", GetOperator(ID));
                myReport.SetParameterValue("SupervisorName", GetSupervisor(ID));



                //FOR SUB REPORT (Product Report)
                myReport.SetParameterValue("NetHi", Batch.GetNetHi(BatchNo));
                myReport.SetParameterValue("NetTarget", Batch.GetNetTarget(BatchNo));
                myReport.SetParameterValue("NetLo", Batch.GetNetLo(BatchNo));

                myReport.SetParameterValue("FillingHi", Batch.GetFillingHi(BatchNo));
                myReport.SetParameterValue("FillingTarget", Batch.GetFillingTarget(BatchNo));
                myReport.SetParameterValue("FillingLo", Batch.GetFillingLo(BatchNo));


                string fileName = GetFileName("BatchReport");
                string filepath = SaveReportPath + fileName;
                if (filepath != string.Empty)
                {
                    myReport.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    UpdateMD5Code(ID, MD5Check.GetMD5HashCode(filepath));
                }
                Console.WriteLine(DateTime.Now + " - Batch Report Generated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(DateTime.Now + " -Unable To Generate Batch Report");
            }
        }


    }
}
