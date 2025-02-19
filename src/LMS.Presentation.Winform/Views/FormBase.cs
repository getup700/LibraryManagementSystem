using LMS.Presentation.Winform.Components.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Presentation.Winform.Views
{
    public class FormBase : Form, IDialogAware
    {
        public FormBase()
        {
            StartPosition = FormStartPosition.CenterScreen; // 窗体居中
            FormBorderStyle = FormBorderStyle.FixedDialog;  // 禁止调整大小
            MaximizeBox = false;  // 禁止最大化
            Load += BaseForm_Load;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            InitializeCommonUI();
        }

        protected virtual void InitializeCommonUI()
        {
            // 这里可以初始化通用 UI，比如添加日志按钮、状态栏等
        }

        protected void ShowMessage(string message)
        {
            MessageBox.Show(message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public virtual void OnStartUp(IDialogParameter parameter)
        {

        }

        public virtual IDialogParameter OnShutDown()
        {
            return null;
        }
    }
}
