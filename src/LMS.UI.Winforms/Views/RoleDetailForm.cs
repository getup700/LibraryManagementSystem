using DevExpress.XtraEditors;
using LMS.Dal.Entities;
using LMS.UI.Winforms.Components.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS.UI.Winforms.Views
{
    public partial class RoleDetailForm : XtraForm, IDialogAware
    {
        public Role Model { get; set; }

        List<Permission> Permissions { get; set; }

        public RoleDetailForm()
        {
            InitializeComponent();
            this.Load += RoleDetailForm_Load;
        }

        private void RoleDetailForm_Load(object? sender, EventArgs e)
        {
            this.textBoxName.DataBindings.Add("Text", Model, nameof(Model.Name));
            this.textBoxDescription.DataBindings.Add("Description", Model, nameof(Model.Description));
            if (Model.Permissions != null)
            {
                this.checkEditBorrow.Checked = Model.Permissions.Any(x => x.Name == "借阅");
                this.checkEditManagement.Checked = Model.Permissions.Any(x => x.Name == "修改");
            }
        }

        public void OnStartUp(IDialogParameter parameter)
        {
            Model = parameter.Get<Role>("data");
        }

        public IDialogParameter OnShutDown()
        {
            var para = new DialogParameter();
            para.Add("data", Model);
            return para;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
