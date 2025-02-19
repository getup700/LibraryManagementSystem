using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Presentation.Winform.Components.Dialogs
{
    public interface IDialogAware
    {
        void OnStartUp(IDialogParameter parameter);

        IDialogParameter OnShutDown();
    }
}
