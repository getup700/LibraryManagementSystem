using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Zack.Commons;

namespace LMS.Bll
{
    internal class ModuleInitialer : IModuleInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddSingleton<PermissionBll>();
            services.AddSingleton<RoleBll>();
        }
    }
}
