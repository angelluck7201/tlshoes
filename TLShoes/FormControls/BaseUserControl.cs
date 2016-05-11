using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLShoes.Common;

namespace TLShoes.FormControls
{
    public class BaseUserControl : UserControl
    {
        public virtual bool SaveData()
        {
            return true;
        }

        public void InitFormData(object data)
        {
            if (data != null)
            {
                foreach (Control control in this.Controls)
                {
                    if (control.Name == "defaultInfo")
                    {
                        foreach (Control defaultControl in control.Controls)
                        {
                            var defaultData = CRUD.ReflectionGet(data, defaultControl.Name);
                            if (defaultData != null)
                            {
                                CRUD.SetControlValue(defaultControl, defaultData);
                            }
                        }
                        continue;
                    }
                    else
                    {
                        var fieldName = CRUD.GetUIModelName(control.Name);
                        if (string.IsNullOrEmpty(fieldName)) continue;

                        var modelData = CRUD.ReflectionGet(data, fieldName);
                        if (modelData != null)
                        {
                            CRUD.SetControlValue(control, modelData);
                        }
                    }
                }
            }
        }

        public virtual void ClearData()
        {
            foreach (Control control in this.Controls)
            {
                if (control.Controls.Count > 0)
                {
                    foreach (var o in control.Controls)
                    {
                        CRUD.ClearControlValue((Control)o);
                    }
                }
                else
                {
                    CRUD.ClearControlValue(control);
                }
            }
        }

        public virtual void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                this.ParentForm.Close();
            }
        }

        public virtual void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                ClearData();
            }
        }

        public virtual void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
