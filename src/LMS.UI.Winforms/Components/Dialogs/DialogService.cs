using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS.UI.Winforms.Components.Dialogs
{
    internal class DialogService : IDialogService
    {
        private readonly IDialogManager dialogManager;

        public DialogService(IDialogManager dialogManager)
        {
            this.dialogManager = dialogManager;
        }

        public void ShowDialog(string name, IDialogParameter parameter, Action<IDialogMessenger> callback = null)
        {
            var view = dialogManager.CreateDialog(name);
            IDialogMessenger dialogMessenger = new DialogMessenger();
            var dialog = (IDialogAware)view;
            dialog.OnStartUp(parameter);
            var result = view.ShowDialog();
            dialogMessenger.DialogResult = result;
            dialogMessenger.Parameter = dialog.OnShutDown();

            callback?.Invoke(dialogMessenger);
        }

        public void ShowFolderBrowserDialog(string title, Action<string> callback)
        {
            var dialog = new FolderBrowserDialog()
            {
                ShowNewFolderButton = true,
                RootFolder = Environment.SpecialFolder.Desktop,
                Description = title
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                callback.Invoke(dialog.SelectedPath);
            }
        }

        public void ShowOpenFileDialog(string title, string filter, Action<string> callback)
        {
            var dialog = new OpenFileDialog()
            {
                Filter = filter,
                Multiselect = false,
                Title = title,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                CheckFileExists = true,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                callback.Invoke(dialog.FileName);
            }
        }

        public void ShowSaveFileDialog(string title, string filter, Action<string> callback)
        {
            var dialog = new SaveFileDialog()
            {
                Filter = filter,
                Title = title,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                CheckPathExists = true,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                callback.Invoke(dialog.FileName);
            }
        }
    }
}
