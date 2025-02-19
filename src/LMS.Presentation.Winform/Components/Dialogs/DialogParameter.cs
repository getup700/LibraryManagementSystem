/**********************************************************

 Author: 十五
 CreateTime: 2022/4/7 21:49:03
 
 Copyright(c): FUJIAN PROVINCIAL INSTITUTE OF ARCHITECTURAL DESIGN AND RESEARCH CO.,LTD.
 Description: 
 
*******************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Presentation.Winform.Components.Dialogs
{
    public class DialogParameter : IDialogParameter
    {
        private Dictionary<string, object> Parameters { get; set; } = [];

        public void Add(string key, object value)
        {
            Parameters.Add(key, value);
        }

        public T Get<T>(string key)
        {
            Parameters.TryGetValue(key, out var value);
            if (value is T val)
            {
                return val;
            }
            return default;
        }
    }
}
