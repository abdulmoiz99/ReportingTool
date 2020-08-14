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
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.btn_MD5Check.Location = new System.Drawing.Point(32, 73);
            this.btn_MD5Check.Margin = new System.Windows.Forms.Padding(4);
            this.btn_MD5Check.Name = "btn_MD5Check";
            this.btn_MD5Check.Size = new System.Drawing.Size(350, 35);
            this.btn_MD5Check.TabIndex = 1;
            this.btn_MD5Check.Text = "MD5 Check";
            this.btn_MD5Check.UseVisualStyleBackColor = true;
            this.btn_MD5Check.Click += new System.EventHandler(this.btn_MD5Check_Click);
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(32, 125);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(350, 27);
            this.textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 174);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_MD5Check);
            this.Controls.Add(this.btn_LoginReport);
            this.Font = new System.Drawing.Font("Century Gothic", 10.01739F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportingTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_LoginReport;
        private System.Windows.Forms.Button btn_MD5Check;
        private System.Windows.Forms.TextBox textBox1;
    }
}

