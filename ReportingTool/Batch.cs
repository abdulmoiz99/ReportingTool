using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingTool
{
    static class Batch
    {
        public static string GetRecipeNo()
        {
            return SQL.ScalarQuery("select 0");
        }
        public static string GetProductName()
        {
            return SQL.ScalarQuery("select 0");
        }
        public static string GetBatchNo(int ID)
        {
            return SQL.ScalarQuery("select batch_No from Hand_Shake where SN = " + ID + "");
        }
        public static string GetTotalRecord(string BatchNo)
        {
            return SQL.ScalarQuery("select Count(*) as TotalRecord from Production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetGoodCount(string BatchNo)
        {
            return SQL.ScalarQuery("select Count(*) as GoodCount from Production where No_Fill = '1' and No_Plug ='1' and No_Cap ='1'and No_Seal ='1' and Batch_No = '" + BatchNo + "'");
        }
        public static string GetDefectCount(string BatchNo)
        {
            return SQL.ScalarQuery("select  (select Count(*) as TotalRecord from Production where Batch_No = '" + BatchNo + "') - (select COUNT(*) as GoodCount from Production where No_Fill = '1' and No_Plug ='1' and No_Cap ='1'and No_Seal ='1' and Batch_No = '" + BatchNo + "') as DefectCount");
        }
        public static string GetNoBottleSum(string BatchNo)
        {
            return SQL.ScalarQuery("select SUM(convert (int,No_Bottle)) from production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetWrongBottleSum(string BatchNo)
        {
            return SQL.ScalarQuery("select SUM(convert (int,Wrong_Bottle)) from production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetNoFillSum(string BatchNo)
        {
            return SQL.ScalarQuery("select SUM(convert (int,No_Fill)) from production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetOverWeightSum(string BatchNo)
        {
            return SQL.ScalarQuery("select SUM(convert (int,Over_Weight)) from production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetUnderWeightSum(string BatchNo)
        {
            return SQL.ScalarQuery("select SUM(convert (int,Under_Weight)) from production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetNoPlugSum(string BatchNo)
        {
            return SQL.ScalarQuery("select SUM(convert (int,No_Plug)) from production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetNoCapSum(string BatchNo)
        {
            return SQL.ScalarQuery("select SUM(convert (int,No_Cap)) from production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetNoSealSum(string BatchNo)
        {
            return SQL.ScalarQuery("select SUM(convert (int,No_Seal)) from production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetNetWeightMax(string BatchNo)
        {
            return SQL.ScalarQuery("select IsNull(MAX(Net_Weight),0) from Production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetNetWeightAverage(string BatchNo)
        {
            return SQL.ScalarQuery("select IsNull(ROUND(AVG(Net_Weight),3),0) from Production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetNetWeightMin(string BatchNo)
        {
            return SQL.ScalarQuery("select IsNull(MIN(Net_Weight),0) from Production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetNetWeightSD(string BatchNo)
        {
            return SQL.ScalarQuery("select 0");
        }
        public static string GetGrossWeightMax(string BatchNo)
        {
            return SQL.ScalarQuery("select IsNull(MAX(Gross_Weight),0) from Production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetGrossWeightAverage(string BatchNo)
        {
            return SQL.ScalarQuery("select IsNull(ROUND(AVG(Gross_Weight),3),0) from Production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetGrossWeightMin(string BatchNo)
        {
            return SQL.ScalarQuery("select IsNull(MIN(Gross_Weight),0) from Production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetGrossWeightSD(string BatchNo)
        {
            return SQL.ScalarQuery("select 0");
        }
        public static string GetFillingWeightMax(string BatchNo)
        {
            return SQL.ScalarQuery("select IsNull(MAX(Filling_Weight),0) from Production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetFillingWeightAverage(string BatchNo)
        {
            return SQL.ScalarQuery("select IsNull(ROUND(AVG(Filling_Weight),3),0) from Production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetFillingWeightMin(string BatchNo)
        {
            return SQL.ScalarQuery("select IsNull(MIN(Filling_Weight),0) from Production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetFillingWeightSD(string BatchNo)
        {
            return SQL.ScalarQuery("select 0");
        }
        public static string GetFillingTimeMax(string BatchNo)
        {
            return SQL.ScalarQuery("select IsNull(MAX(TIme),0) from ProductionReport_View where Batch_No = '" + BatchNo + "'");
        }

        public static string GetFillingTimeAverage(string BatchNo)
        {
            return SQL.ScalarQuery("select IsNull(ROUND(AVG(TIme),3),0) from ProductionReport_View where Batch_No = '" + BatchNo + "'");
        }
        public static string GetFillingTimeMin(string BatchNo)
        {
            return SQL.ScalarQuery("select IsNull(MIN(TIme),0) from ProductionReport_View where Batch_No = '" + BatchNo + "'");
        }
        public static string GetFillingTimeSD(string BatchNo)
        {
            return SQL.ScalarQuery("select 0");
        }
        public static string GetNetHi(string BatchNo)
        {
            return SQL.ScalarQuery("select Net_hi_Limit from production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetNetTarget(string BatchNo)
        {
            return SQL.ScalarQuery("select Net_Target_Weight from production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetNetLo(string BatchNo)
        {
            return SQL.ScalarQuery("select Net_Lo_Limit from production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetFillingHi(string BatchNo)
        {
            return SQL.ScalarQuery("select Fill_Hi_Limit from production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetFillingTarget(string BatchNo)
        {
            return SQL.ScalarQuery("select Fill_Target_Weight from production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetFillingLo(string BatchNo)
        {
            return SQL.ScalarQuery("select Fill_Lo_Limit from production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetRecipeNo(string BatchNo)
        {
            return SQL.ScalarQuery("select Recipe_No from production where Batch_No = '" + BatchNo + "'");
        }
        public static string GetParameterQuery(string BatchNo)
        {
            return "select * from Parameter where Recepie_No = '" + GetRecipeNo(BatchNo) + "'";
        }
    }
}