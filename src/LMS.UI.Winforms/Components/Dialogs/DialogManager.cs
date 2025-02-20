using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LMS.UI.Winforms.Components.Dialogs
{
    public class DialogManager(IServiceProvider serviceProvider) : IDialogManager
    {
        private Dictionary<string, Func<Form>> DialogServices { get; set; } = [];

        public IDialogManager RegisterDialog<View>(string token) where View : Form
        {
            DialogServices.Add(token, () => serviceProvider.GetService<View>());
            return this;
        }

        public Form CreateDialog(string name)
        {
            if (DialogServices.TryGetValue(name, out var dialog))
            {
                return dialog.Invoke();
            }
            return null;
        }

    }
}
