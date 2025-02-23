using LMS.Dal.Entities;
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
    public partial class PermissionPage : UserControl
    {
        private PermissionDao _permissionDao;
        public PermissionPage(PermissionDao permissionDao)
        {
            _permissionDao = permissionDao;
            InitializeComponent();
            this.gridControl1.DataSource = _permissionDao.GetAll();
        }
    }
}
