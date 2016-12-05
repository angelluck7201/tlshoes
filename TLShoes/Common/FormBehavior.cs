using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLShoes.ViewModels;

namespace TLShoes.Common
{
    public static class FormBehavior
    {

        private static Dictionary<System.Windows.Forms.Form, System.Windows.Forms.Form> ShowingForms = new Dictionary<System.Windows.Forms.Form, System.Windows.Forms.Form>();

        public static void CustomShow(this System.Windows.Forms.Form formControl, System.Windows.Forms.Form parenForm)
        {
            if (ShowingForms.ContainsKey(parenForm))
            {
                ShowingForms[parenForm] = formControl;
            }
            else
            {
                ShowingForms.Add(parenForm, formControl);
            }

            parenForm.Enabled = false;
            formControl.Show();
            formControl.Focus();
        }

        public static void Close(System.Windows.Forms.Form formControl)
        {
            var parentForms = ShowingForms.Where(s => s.Value == formControl).ToList();
            foreach (var keyValuePair in parentForms)
            {
                keyValuePair.Key.Enabled = true;
                ShowingForms.Remove(keyValuePair.Key);
            }
        }

        public static bool IsMainFormEnable()
        {
            return FormFactory<Main>.Get().Enabled;
        }
    }


}
