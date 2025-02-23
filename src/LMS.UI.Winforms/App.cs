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
        //    Name = "读",
        //    Description = "可以阅读书籍"
        //};
        //var p2 = new Permission()
        //{
        //    Id = Guid.NewGuid(),
        //    Name = "借阅",
        //    Description = "可以借阅书籍"
        //};
        //var p3 = new Permission()
        //{
        //    Id = Guid.NewGuid(),
        //    Name = "登录",
        //    Description = "可以登录电子图书馆"
        //};
        //var p4 = new Permission()
        //{
        //    Id = Guid.NewGuid(),
        //    Name = "修改",
        //    Description = "可以修改用户权限"
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