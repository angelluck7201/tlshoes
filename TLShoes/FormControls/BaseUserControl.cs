using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls
{
    public class BaseUserControl : UserControl
    {
        public const string FormButton = "panelButtons";
        public const string FormData = "navBarData";
        public List<Control> FormControls = new List<Control>();

        public void Init(object data = null)
        {
            FormControls = CRUD.GetAllChild(this);
            InitAction();
            if (data != null)
            {
                InitFormData(data);
            }
        }

        public virtual bool SaveData()
        {
            return true;
        }

        public void InitAction()
        {
            var saveButton = FormControls.FirstOrDefault(s => s.Name == "btnSave");
            if (saveButton != null)
            {
                saveButton.Click += new EventHandler(btnSave_Click);
            }
            var saveContinueButton = FormControls.FirstOrDefault(s => s.Name == "btnSaveContinue");
            if (saveContinueButton != null)
            {
                saveContinueButton.Click += new EventHandler(btnSaveContinue_Click);
            }

            var cancelButton = FormControls.FirstOrDefault(s => s.Name == "btnCancel");
            if (cancelButton != null)
            {
                cancelButton.Click += new EventHandler(btnCancel_Click);
            }
        }

        public void InitFormData(object data)
        {
            if (data != null)
            {
                foreach (Control control in FormControls)
                {
                    if (control.Name == "Id")
                    {
                        var defaultData = CRUD.ReflectionGet(data, control.Name);
                        if (defaultData != null)
                        {
                            CRUD.SetControlValue(control, defaultData);
                        }
                    }
                    else if (control.Name == "AuthorId")
                    {
                        var defaultData = CRUD.ReflectionGet(data, control.Name);
                        if (defaultData != null)
                        {
                            var userInfo = SF.Get<UserAccountViewModel>().GetDetail((long)defaultData);
                            if (userInfo != null)
                            {
                                CRUD.SetControlValue(control, userInfo.TenNguoiDung);
                            }
                        }
                    }
                    else if (control.Name == "CreatedDate" ||
                            control.Name == "ModifiedDate")
                    {
                        var defaultData = CRUD.ReflectionGet(data, control.Name);
                        if (defaultData != null)
                        {
                            CRUD.SetControlValue(control, TimeHelper.TimestampToString((long)defaultData));
                        }
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

        public virtual void ClearData(string modelControl = "")
        {
            var clearControl = FormControls;

            if (!string.IsNullOrEmpty(modelControl))
            {
                clearControl = clearControl.Where(s => s.Name.Contains(modelControl)).ToList();
            }

            foreach (Control control in clearControl)
            {
                CRUD.ClearControlValue(control);
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
