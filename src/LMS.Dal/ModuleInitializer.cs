using LMS.Dal.Entities;
using LMS.Dal.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zack.Commons;

namespace LMS.Dal
{
    internal class ModuleInitializer : IModuleInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddSingleton<SqlConnection>(ConnUtil.GetBookConnection());
            services.AddSingleton<UserDao>();
            services.AddSingleton<RoleDao>();
            services.AddSingleton<PermissionDao>();
            services.AddSingleton<BookInstanceDao>();
            services.AddSingleton<BookCategoryDao>();
            services.AddSingleton<RolePermissionDao>();
        }
    }
}
