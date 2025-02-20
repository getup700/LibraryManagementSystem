using System.Windows.Forms.VisualStyles;

namespace LMS.UI.Winforms.Components.Dialogs
{
    public interface IDialogManager
    {
        Form CreateDialog(string token);

        IDialogManager RegisterDialog<View>(string token = null) where View : Form;

    }
}