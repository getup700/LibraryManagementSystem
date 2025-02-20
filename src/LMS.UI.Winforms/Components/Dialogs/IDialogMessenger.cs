namespace LMS.UI.Winforms.Components.Dialogs
{
    public interface IDialogMessenger
    {
        DialogResult DialogResult { get; set; }
        IDialogParameter Parameter { get; set; }
    }
}