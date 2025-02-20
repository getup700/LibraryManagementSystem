namespace LMS.UI.Winforms.Components.Dialogs
{
    public interface IDialogService
    {
        void ShowDialog(string name, IDialogParameter parameter, Action<IDialogMessenger> callback = null);
        void ShowFolderBrowserDialog(string title, Action<string> callback);
        void ShowOpenFileDialog(string title, string filter, Action<string> callback);
        void ShowSaveFileDialog(string title, string filter, Action<string> callback);
    }
}