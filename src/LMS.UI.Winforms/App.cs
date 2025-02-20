using DevExpress.Mvvm.POCO;
using DevExpress.RichEdit.Export;
using LMS.Dal;
using LMS.Presentation.Winform.Views;
using LMS.UI.Winforms.Components.Dialogs;
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
        //var app = new App();
        //app.Run(nameof(MainView));
        //var access = new UserDao();
        //var user = access.GetAll();
        //foreach (var item in user)
        //{
        //   Debug.WriteLine(item.Id);
        //}
    }

    internal override void RegisterServices(IServiceCollection services)
    {
        services.AddTransient<LoginView>();
        services.AddSingleton<MainView>();
        services.AddSingleton<UserInfoPage>();
        services.AddSingleton<SettingsPage>();

    }

    internal override void RegisterViews(IDialogManager dialogManager)
    {
        dialogManager.RegisterDialog<MainView>(nameof(MainView));
        dialogManager.RegisterDialog<LoginView>(nameof(LoginView));

    }
}