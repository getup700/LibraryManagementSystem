using LMS.UI.Winforms.Components.Dialogs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zack.Commons;

namespace LMS.UI.Winforms
{
    public abstract class AppBase
    {
        private Mutex _mutex;

        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// 入口方法，提供模板方法模式，子类可重写 Initialize 和 Cleanup
        /// </summary>
        public void Run(string token)
        {
            if (!EnsureSingleInstance())
            {
                MessageBox.Show("程序已在运行中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ApplicationConfiguration.Initialize();

                var services = new ServiceCollection();

                //注册对话框服务
                services.AddSingleton<IDialogManager, DialogManager>();
                services.AddSingleton<IDialogService, DialogService>();

                //注册模块服务
                var assemblies = ReflectionHelper.GetAllReferencedAssemblies();
                services.RunModuleInitializers(assemblies);

                //注册业务服务
                RegisterServices(services);

                //构建容器
                ServiceProvider = services.BuildServiceProvider();

                //注册窗口管理器
                var dialogManager = ServiceProvider.GetService<IDialogManager>();
                RegisterViews(dialogManager);

                //运行主窗口
                var view = dialogManager.CreateDialog(token);
                if (view != null)
                {
                    Application.Run(view);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            finally
            {
                Cleanup();
            }
        }

        /// <summary>
        /// 注册业务相关服务
        /// </summary>
        /// <param name="services"></param>
        internal abstract void RegisterServices(IServiceCollection services);

        /// <summary>
        /// 注册窗口
        /// </summary>
        /// <param name="services"></param>
        internal abstract void RegisterViews(IDialogManager dialogManager);

        /// <summary>
        /// 确保程序只运行一个实例
        /// </summary>
        private bool EnsureSingleInstance()
        {
            var mutexName = "unifiedUserC"; // 应用唯一标识
            _mutex = new Mutex(true, mutexName, out var isNewInstance);
            return isNewInstance;
        }

        /// <summary>
        /// 统一异常处理（可改为写入日志）
        /// </summary>
        private static void HandleException(Exception ex)
        {
            MessageBox.Show($"发生错误：{ex.Message}\n{ex.StackTrace}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 允许子类重写的初始化方法
        /// </summary>
        protected virtual void Initialize()
        {
            // 例如：加载配置、初始化日志
        }

        /// <summary>
        /// 允许子类重写的清理方法
        /// </summary>
        protected virtual void Cleanup()
        {
            // 例如：释放资源
            _mutex.ReleaseMutex();
        }
    }
}
