namespace ReportingTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_LoginReport = new System.Windows.Forms.Button();
            this.btn_MD5Check = new System.Windows.Forms.Button();
            this.btn_AlarmReport = new System.Windows.Forms.Button();
            this.bnt_BatchReport = new System.Windows.Forms.Button();
            this.btn_OperationReport = new System.Windows.Forms.Button();
            this.bnt_ParameterReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_LoginReport
            // 
            this.btn_LoginReport.Location = new System.Drawing.Point(32, 30);
            this.btn_LoginReport.Margin = new System.Windows.Forms.Padding(4);
            this.btn_LoginReport.Name = "btn_LoginReport";
            this.btn_LoginReport.Size = new System.Drawing.Size(350, 35);
            this.btn_LoginReport.TabIndex = 0;
            this.btn_LoginReport.Text = "Login Report";
            this.btn_LoginReport.UseVisualStyleBackColor = true;
            this.btn_LoginReport.Click += new System.EventHandler(this.btn_LoginReport_Click);
            // 
            // btn_MD5Check
            // 
            this.btn_MD5Check.Location = new System.Drawing.Point(32, 245);
            this.btn_MD5Check.Margin = new System.Windows.Forms.Padding(4);
            this.btn_MD5Check.Name = "btn_MD5Check";
            this.btn_MD5Check.Size = new System.Drawing.Size(350, 35);
            this.btn_MD5Check.TabIndex = 1;
            this.btn_MD5Check.Text = "MD5 Check";
            this.btn_MD5Check.UseVisualStyleBackColor = true;
            this.btn_MD5Check.Click += new System.EventHandler(this.btn_MD5Check_Click);
            // 
            // btn_AlarmReport
            // 
            this.btn_AlarmReport.Location = new System.Drawing.Point(32, 73);
            this.btn_AlarmReport.Margin = new System.Windows.Forms.Padding(4);
            this.btn_AlarmReport.Name = "btn_AlarmReport";
            this.btn_AlarmReport.Size = new System.Drawing.Size(350, 35);
            this.btn_AlarmReport.TabIndex = 2;
            this.btn_AlarmReport.Text = "Alarm Report";
            this.btn_AlarmReport.UseVisualStyleBackColor = true;
            this.btn_AlarmReport.Click += new System.EventHandler(this.btn_AlarmReport_Click);
            // 
            // bnt_BatchReport
            // 
            this.bnt_BatchReport.Location = new System.Drawing.Point(32, 116);
            this.bnt_BatchReport.Margin = new System.Windows.Forms.Padding(4);
            this.bnt_BatchReport.Name = "bnt_BatchReport";
            this.bnt_BatchReport.Size = new System.Drawing.Size(350, 35);
            this.bnt_BatchReport.TabIndex = 3;
            this.bnt_BatchReport.Text = "Batch Report";
            this.bnt_BatchReport.UseVisualStyleBackColor = true;
            this.bnt_BatchReport.Click += new System.EventHandler(this.bnt_BatchReport_Click);
            // 
            // btn_OperationReport
            // 
            this.btn_OperationReport.Location = new System.Drawing.Point(32, 159);
            this.btn_OperationReport.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OperationReport.Name = "btn_OperationReport";
            this.btn_OperationReport.Size = new System.Drawing.Size(350, 35);
            this.btn_OperationReport.TabIndex = 4;
            this.btn_OperationReport.Text = "Operation Report";
            this.btn_OperationReport.UseVisualStyleBackColor = true;
            this.btn_OperationReport.Click += new System.EventHandler(this.btn_OperationReport_Click);
            // 
            // bnt_ParameterReport
            // 
            this.bnt_ParameterReport.Location = new System.Drawing.Point(32, 202);
            this.bnt_ParameterReport.Margin = new System.Windows.Forms.Padding(4);
            this.bnt_ParameterReport.Name = "bnt_ParameterReport";
            this.bnt_ParameterReport.Size = new System.Drawing.Size(350, 35);
            this.bnt_ParameterReport.TabIndex = 5;
            this.bnt_ParameterReport.Text = "Parameter Report";
            this.bnt_ParameterReport.UseVisualStyleBackColor = true;
            this.bnt_ParameterReport.Click += new System.EventHandler(this.bnt_ParameterReport_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 330);
            this.Controls.Add(this.bnt_ParameterReport);
            this.Controls.Add(this.btn_OperationReport);
            this.Controls.Add(this.bnt_BatchReport);
            this.Controls.Add(this.btn_AlarmReport);
            this.Controls.Add(this.btn_MD5Check);
            this.Controls.Add(this.btn_LoginReport);
            this.Font = new System.Drawing.Font("Century Gothic", 10.01739F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportingTool";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_LoginReport;
        private System.Windows.Forms.Button btn_MD5Check;
        private System.Windows.Forms.Button btn_AlarmReport;
        private System.Windows.Forms.Button bnt_BatchReport;
        private System.Windows.Forms.Button btn_OperationReport;
        private System.Windows.Forms.Button bnt_ParameterReport;
    }
}

