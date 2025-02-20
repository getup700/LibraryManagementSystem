namespace LMS.Presentation.Winform.Views
{
    partial class LoginView
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
            tableLayoutPanel1 = new TableLayoutPanel();
            textEditCount = new DevExpress.XtraEditors.TextEdit();
            label1 = new Label();
            label2 = new Label();
            btnLogin = new DevExpress.XtraEditors.SimpleButton();
            textEditPassword = new DevExpress.XtraEditors.TextEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textEditCount.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditPassword.Properties).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(textEditCount, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(textEditPassword, 1, 1);
            tableLayoutPanel1.Location = new Point(92, 55);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(200, 84);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // textEditCount
            // 
            textEditCount.Location = new Point(103, 3);
            textEditCount.Name = "textEditCount";
            textEditCount.Size = new Size(94, 20);
            textEditCount.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(31, 14);
            label1.TabIndex = 1;
            label1.Text = "账号";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 42);
            label2.Name = "label2";
            label2.Size = new Size(31, 14);
            label2.TabIndex = 2;
            label2.Text = "密码";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(142, 176);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(87, 23);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "登录";
            // 
            // textEditPassword
            // 
            textEditPassword.Location = new Point(103, 45);
            textEditPassword.Name = "textEditPassword";
            textEditPassword.Size = new Size(94, 20);
            textEditPassword.TabIndex = 3;
            // 
            // labelControl1
            // 
            labelControl1.Location = new Point(159, 23);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(72, 14);
            labelControl1.TabIndex = 3;
            labelControl1.Text = "图书管理系统";
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 235);
            Controls.Add(labelControl1);
            Controls.Add(btnLogin);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LoginView";
            Text = "STARK";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textEditCount.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditPassword.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.TextEdit textEditCount;
        private Label label1;
        private Label label2;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.TextEdit textEditPassword;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}