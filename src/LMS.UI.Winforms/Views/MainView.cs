using DevExpress.XtraBars.FluentDesignSystem;
using DevExpress.XtraBars.Navigation;
using LMS.UI.Winforms.Views;
using LMS.UI.Winforms.Views.UserControls;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.UI.Winforms
{
    public partial class MainView : FluentDesignForm
    {
        public MainView()
        {
            InitializeComponent();
            accordionControl1.AllowItemSelection = true;
            accordionControl1.SelectedElement = accordionControlElement1;
            accordionControl1.SelectedElementChanged += AccordionControl1_SelectedElementChanged;
        }


        private void AccordionControl1_SelectedElementChanged(object sender, SelectedElementChangedEventArgs e)
        {
            var name = e.Element.Text;
            LoadPage(name);
        }

        private void LoadPage(string key)
        {
            UserControl userControl = null;
            switch (key)
            {
                case "个人信息":
                    userControl = App.ServiceProvider.GetRequiredService<UserInfoPage>();
                    break;
                case "设置":
                    userControl = App.ServiceProvider.GetRequiredService<SettingsPage>();
                    break;
                case "角色管理":
                    userControl = App.ServiceProvider.GetRequiredService<RoleManagerPage>();
                    break;
                case "权限管理":
                    userControl = App.ServiceProvider.GetRequiredService<PermissionPage>();
                    break;
                default:
                    break;
            }
            fluentDesignFormContainer1.Controls.Clear();
            fluentDesignFormContainer1.Controls.Add(userControl);
        }
    }

}
