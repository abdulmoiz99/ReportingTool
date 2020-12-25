using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ReportingTool
{
    class SQL
    {

        private static SqlConnection con = new SqlConnection(@"Data Source=.\ABDUL;Initial Catalog=ReportingToolDummyDatabase;Integrated Security=True;Pooling=False");// ReadCS().ToString()); 
                                                                                                                                                                       // private static SqlConnection con = new SqlConnection(@"Data Source=AVF-108_ADMIN\SQLEXPRESS;Initial Catalog=ReportingTool;Integrated Security=True;Pooling=False");// ReadCS().ToString()); 

        public static bool IsServerConnected(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
        public static SqlConnection Con
        {
            get
            { return con; }
        }
        public static string ReadCS()
        {
            var lines = "";
            string Path = Application.StartupPath + @"\SQL.dat";
            // string Path = @"C:\Users\moiza\source\repos\SchoolManagementSoftware\SchoolManagementSoftware\bin\Debug\Conn\SQL.txt";
            if (!File.Exists(Path))
            {
                MessageBox.Show("Unable To Find Connection File ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (var streamReader = new StreamReader(Path))
                {
                    try
                    {
                        lines = streamReader.ReadLine();
                    }
                    catch (FileNotFoundException ex)
                    {
                        MessageBox.Show(ex.Message, "SQL");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "SQl");
                    }
                }
            }

            return lines;
        }
        public static string ScalarQuery(string Query)
        {
            String Result = string.Empty;
            try
            {
                if (Con.State != ConnectionState.Open) Con.Open();
                var cmd = new SqlCommand(Query, Con);
                Result = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Scalar Query" + ex.Message);
            }
            finally
            {
                Con.Close();
            }
            return Result;
        }
        public static void NonScalarQuery(String Query)
        {
            try
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
                Con.Open();
                var cmd = new SqlCommand(Query, Con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL" + ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

    }
}
