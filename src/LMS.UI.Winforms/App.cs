using DevExpress.Mvvm.POCO;
using DevExpress.RichEdit.Export;
using LMS.Dal;
using LMS.Dal.Entities;
using LMS.Presentation.Winform.Views;
using LMS.UI.Winforms.Components.Dialogs;
using LMS.UI.Winforms.Controllers;
using LMS.UI.Winforms.Views;
using LMS.UI.Winforms.Views.UserControls;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Zack.Commons;

namespace LMS.UI.Winforms;

internal class App : AppBase
{
    [STAThread]
    static void Main()
    {
        var app = new App();
        app.Run(nameof(MainView));

        //var permissionDao = ServiceProvider.GetService<PermissionDao>();
        //var p1 = new Permission()
        //{
        //    Id = Guid.NewGuid(),
        //    Name = "��",
        //    Description = "�����Ķ��鼮"
        //};
        //var p2 = new Permission()
        //{
        //    Id = Guid.NewGuid(),
        //    Name = "����",
        //    Description = "���Խ����鼮"
        //};
        //var p3 = new Permission()
        //{
        //    Id = Guid.NewGuid(),
        //    Name = "��¼",
        //    Description = "���Ե�¼����ͼ���"
        //};
        //var p4 = new Permission()
        //{
        //    Id = Guid.NewGuid(),
        //    Name = "�޸�",
        //    Description = "�����޸��û�Ȩ��"
        //};
        //permissionDao.Create(p1);
        //permissionDao.Create(p2);
        //permissionDao.Create(p3);
        //permissionDao.Create(p4);

    }

    internal override void RegisterServices(IServiceCollection services)
    {
        services.AddTransient<LoginView>();
        services.AddSingleton<MainView>();
        services.AddSingleton<UserInfoPage>();
        services.AddSingleton<SettingsPage>();
        services.AddSingleton<RoleManagerPage>();
        services.AddSingleton<PermissionPage>();

        services.AddSingleton<RolePermissionController>();

    }

    internal override void RegisterViews(IDialogManager dialogManager)
    {
        dialogManager.RegisterDialog<MainView>(nameof(MainView));
        dialogManager.RegisterDialog<LoginView>(nameof(LoginView));

    }
}