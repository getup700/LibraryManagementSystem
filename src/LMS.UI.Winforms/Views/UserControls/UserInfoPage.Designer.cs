namespace LMS.UI.Winforms.Views.UserControls
{
    partial class UserInfoPage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            imageEdit1 = new DevExpress.XtraEditors.ImageEdit();
            flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
            flyoutPanelControl1 = new DevExpress.Utils.FlyoutPanelControl();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)imageEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)flyoutPanel1).BeginInit();
            flyoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)flyoutPanelControl1).BeginInit();
            SuspendLayout();
            // 
            // imageEdit1
            // 
            imageEdit1.Location = new Point(120, 112);
            imageEdit1.Name = "imageEdit1";
            imageEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            imageEdit1.Size = new Size(100, 20);
            imageEdit1.TabIndex = 0;
            // 
            // flyoutPanel1
            // 
            flyoutPanel1.Controls.Add(flyoutPanelControl1);
            flyoutPanel1.Location = new Point(46, 228);
            flyoutPanel1.Name = "flyoutPanel1";
            flyoutPanel1.Size = new Size(150, 150);
            flyoutPanel1.TabIndex = 1;
            // 
            // flyoutPanelControl1
            // 
            flyoutPanelControl1.Dock = DockStyle.Fill;
            flyoutPanelControl1.FlyoutPanel = flyoutPanel1;
            flyoutPanelControl1.Location = new Point(0, 0);
            flyoutPanelControl1.Name = "flyoutPanelControl1";
            flyoutPanelControl1.Size = new Size(150, 150);
            flyoutPanelControl1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Location = new Point(186, 138);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(200, 100);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(307, 82);
            label1.Name = "label1";
            label1.Size = new Size(63, 14);
            label1.TabIndex = 3;
            label1.Text = "USERINFO";
            // 
            // UserInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(imageEdit1);
            Controls.Add(flyoutPanel1);
            Name = "UserInfo";
            Size = new Size(430, 394);
            ((System.ComponentModel.ISupportInitialize)imageEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)flyoutPanel1).EndInit();
            flyoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)flyoutPanelControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.ImageEdit imageEdit1;
        private DevExpress.Utils.FlyoutPanel flyoutPanel1;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
    }
}
