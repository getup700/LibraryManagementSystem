using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.UI.Winforms.Components.Dialogs
{
    public interface IDialogAware
    {
        void OnStartUp(IDialogParameter parameter);

        IDialogParameter OnShutDown();
    }
}
