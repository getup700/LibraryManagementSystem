using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.UI.Winforms.Components.Dialogs
{
    internal class DialogMessenger : IDialogMessenger
    {
        public IDialogParameter Parameter { get; set; }

        public DialogResult DialogResult { get; set; }
    }
}
