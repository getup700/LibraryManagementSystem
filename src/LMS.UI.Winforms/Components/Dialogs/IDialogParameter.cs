using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.UI.Winforms.Components.Dialogs
{
    public interface IDialogParameter
    {
        void Add(string key, object value);

        T Get<T>(string key);
    }
}
