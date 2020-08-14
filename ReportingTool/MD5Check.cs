using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportingTool
{
    class MD5Check
    {
        /// <summary>
        /// getting hashcode
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string GetMD5HashCode(string filename)
        {
            string hashCode = "";
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    hashCode =  BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    SaveHashCode(hashCode);
                }
            }
            return hashCode;
        }
        /// <summary>
        /// saving the FileHashCodeInCSVFile 
        /// the csv file will be later updated to the database table 
        /// </summary>
        /// <param name="hashCode"></param>
        private static void SaveHashCode(string hashCode)
        {
            using (StreamWriter sw = File.AppendText(Application.StartupPath +@"\MD5Code.csv"))
            {
                sw.WriteLine(hashCode);
            }
        }
        /// <summary>
        /// check if the HashCode Exisit in the database or not 
        /// </summary>
        public static void CheckHashCode(string filename)
        {
            bool contains = false;
            string hashCode = "";
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    hashCode = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
            string[] lines = File.ReadAllLines(Application.StartupPath + @"\MD5Code.csv");
            foreach (var item in lines)
            {
                if (item.Equals(hashCode))
                {
                    contains = true;
                    break;
                }
                else contains = false;
            }
            if (contains==true)
            {
             MessageBox.Show("Hash Code Exist");

            }
            else MessageBox.Show("Hash Code Doest Not Exist");

        }

    }
}
