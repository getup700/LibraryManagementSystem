namespace LMS.Presentation.Winform.Components.Dialogs
{
    public interface IDialogMessenger
    {
        DialogResult DialogResult { get; set; }
        IDialogParameter Parameter { get; set; }
    }
}