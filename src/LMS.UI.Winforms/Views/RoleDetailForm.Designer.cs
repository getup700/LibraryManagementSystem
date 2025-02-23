namespace LMS.UI.Winforms.Views
{
    partial class RoleDetailForm
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
            label1 = new Label();
            label2 = new Label();
            textBoxName = new TextBox();
            textBoxDescription = new TextBox();
            labelTitle = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            checkEditBorrow = new DevExpress.XtraEditors.CheckEdit();
            checkEditManagement = new DevExpress.XtraEditors.CheckEdit();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)checkEditBorrow.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkEditManagement.Properties).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(textBoxName, 1, 0);
            tableLayoutPanel1.Controls.Add(textBoxDescription, 1, 1);
            tableLayoutPanel1.Location = new Point(84, 115);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(200, 116);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(55, 14);
            label1.TabIndex = 0;
            label1.Text = "角色名称";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 58);
            label2.Name = "label2";
            label2.Size = new Size(55, 14);
            label2.TabIndex = 1;
            label2.Text = "详细描述";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(103, 2);
            textBoxName.Margin = new Padding(3, 2, 3, 2);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(94, 22);
            textBoxName.TabIndex = 3;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(103, 60);
            textBoxDescription.Margin = new Padding(3, 2, 3, 2);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(94, 22);
            textBoxDescription.TabIndex = 4;
            // 
            // labelTitle
            // 
            labelTitle.Dock = DockStyle.Top;
            labelTitle.Font = new Font("微软雅黑", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTitle.Location = new Point(0, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(385, 70);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "角色信息";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(307, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 2;
            btnOK.Text = "确定";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(226, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnOK);
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(0, 331);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(385, 40);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(checkEditBorrow);
            flowLayoutPanel3.Controls.Add(checkEditManagement);
            flowLayoutPanel3.FlowDirection = FlowDirection.BottomUp;
            flowLayoutPanel3.Location = new Point(0, 236);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(385, 37);
            flowLayoutPanel3.TabIndex = 6;
            // 
            // checkEditBorrow
            // 
            checkEditBorrow.Location = new Point(3, 14);
            checkEditBorrow.Name = "checkEditBorrow";
            checkEditBorrow.Properties.Caption = "借阅";
            checkEditBorrow.Size = new Size(82, 20);
            checkEditBorrow.TabIndex = 0;
            // 
            // checkEditManagement
            // 
            checkEditManagement.Location = new Point(91, 14);
            checkEditManagement.Name = "checkEditManagement";
            checkEditManagement.Properties.Caption = "管理";
            checkEditManagement.Size = new Size(75, 20);
            checkEditManagement.TabIndex = 1;
            // 
            // RoleDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 371);
            Controls.Add(labelTitle);
            Controls.Add(flowLayoutPanel3);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "RoleDetailForm";
            Text = "角色信息";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)checkEditBorrow.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkEditManagement.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private TextBox textBoxName;
        private TextBox textBoxDescription;
        private Label labelTitle;
        private Button btnOK;
        private Button btnCancel;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel3;
        private DevExpress.XtraEditors.CheckEdit checkEditBorrow;
        private DevExpress.XtraEditors.CheckEdit checkEditManagement;
    }
}