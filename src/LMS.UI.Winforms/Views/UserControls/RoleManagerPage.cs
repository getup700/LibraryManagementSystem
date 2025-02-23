using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using LMS.Bll;
using LMS.Dal;
using LMS.Dal.Entities;
using LMS.UI.Winforms.Components.Dialogs;
using LMS.UI.Winforms.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS.UI.Winforms.Views.UserControls
{
    public partial class RoleManagerPage : UserControl
    {
        RolePermissionController _controller;
        PermissionBll _permissionBll;
        IDialogService _dialogService;

        BindingList<Role> Models { get; set; } = [];

        public RoleManagerPage(RolePermissionController controller, PermissionBll permissionBll, IDialogService dialogService)
        {
            _controller = controller;
            _permissionBll = permissionBll;
            _dialogService = dialogService;
            InitializeComponent();
            InitialPage();
        }

        private void InitialPage()
        {
            var roleNameColumn = gridView1.Columns.AddField("RoleName");
            roleNameColumn.Caption = "角色名称";
            foreach (var item in _permissionBll.GetAll())
            {
                var column = gridView1.Columns.AddField(item.Name);
                column.Caption = item.Name;

            }
            ReflashData();

            gridView1.CustomColumnDisplayText += gridView1_CustomColumnDisplayText;
        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "RoleName")
            {
                //Role role = gridView1.GetRow(e.) as Role;
                //if (role != null)
                //{
                //    bool hasPermission = role.Permissions.Exists(p => p.Name == e.Column.FieldName);
                //    e.DisplayText = hasPermission ? "是" : "否";
                //}
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var para = new DialogParameter();
            para.Add("data", new Role());
            _dialogService.ShowDialog("RoleDetailForm", para, x =>
            {
                var data = x.Parameter.Get<Role>("data");
                _controller.Create(data.Name, data.Description, data.Permissions);
            });

            ReflashData();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show("请选中一条数据后执行", "Information");
                return;
            }
            var selectedIndex = gridView1.GetSelectedRows();
            var selectedModels = Models.Where(x => selectedIndex.Contains(Models.IndexOf(x)));
            foreach (var model in selectedModels)
            {
                _controller.Delete(model);
            }
            ReflashData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show("请选中一条数据后执行", "Information");
                return;
            }
            var selectedIndex = gridView1.GetSelectedRows().First();
            var selectedModel = Models.First(x => Models.IndexOf(x) == selectedIndex);
        
            var para =new DialogParameter();
            para.Add("data", selectedModel);
            _dialogService.ShowDialog("RoleDetailForm", para, x =>
            {
                var data = x.Parameter.Get<Role>("data");
                _controller.Delete(data);
            });
            ReflashData();
        }

        private void ReflashData()
        {
            var model = _controller.GetAll();
            Models.Clear();
            model.ToList().ForEach(x => Models.Add(x));

            this.gridControl1.DataSource = Models;
        }

    }
}
