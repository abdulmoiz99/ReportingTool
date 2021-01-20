using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportingTool
{
    public partial class frm_GenerateReport : Form
    {
        public frm_GenerateReport()
        {
            InitializeComponent();
        }
        private void CheckReport()
        {
            if (GenerateReports.CheckToGenerateReport())
            {
                //stop timer
                //Generate Report
                while (GenerateReports.CheckToGenerateReport())
                {
                    GenerateReports.Report();
                    listBox1.Refresh();
                    listBox1.Items.Add("Report Generated");
                }

            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckReport();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateReports.BatchReport(4);
            listBox1.Refresh();
            listBox1.Items.Add("Report Generated");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
