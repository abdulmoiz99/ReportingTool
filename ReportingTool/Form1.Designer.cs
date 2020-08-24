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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(32, 116);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(350, 35);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(32, 159);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(350, 35);
            this.button3.TabIndex = 4;
            this.button3.Text = "Login Report";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(32, 202);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(350, 35);
            this.button4.TabIndex = 5;
            this.button4.Text = "Login Report";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 330);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

