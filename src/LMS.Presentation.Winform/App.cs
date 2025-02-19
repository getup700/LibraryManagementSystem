using Identity.Presentation.Winform.Controllers;
using Identity.Presentation.Winform.Views;
using LMS.Presentation.Winform.Components.Dialogs;
using Microsoft.Extensions.DependencyInjection;
using Zack.Commons;

namespace LMS.Presentation.Winform
{
    internal class App : AppBase
    {
        [STAThread]
        static void Main()
        {
            var app = new App();
            app.Run(nameof(UserListView));

        }

        internal override void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<UserController>();
            services.AddTransient<UserListView>();
            services.AddTransient<UserDetailView>();
            services.AddTransient<LoginView>();
        }

        internal override void RegisterViews(IDialogManager dialogManager)
        {
            dialogManager.RegisterDialog<UserListView>(nameof(UserListView));
            dialogManager.RegisterDialog<UserDetailView>(nameof(UserDetailView));
            dialogManager.RegisterDialog<LoginView>(nameof(LoginView));

        }
    }
}