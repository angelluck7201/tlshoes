using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Native;
using TLShoes.ViewModels;

namespace TLShoes.Common
{
    public static class CRUD
    {
        public static string GetUIModelName(string uiName)
        {
            var modelName = uiName.Split('_');
            if (modelName.Length > 1)
            {
                return modelName[1];
            }
            return string.Empty;
        }

        public static bool IsSaveData(string uiName, Type model)
        {
            var controlName = uiName.Split('_');
            if (controlName.Length > 1 && controlName[0] == model.Name)
            {
                return true;
            }
            return false;
        }

        public static void ReflectionSet(object data, string pro, object value)
        {
            PropertyInfo prop = data.GetType().GetProperty(pro, BindingFlags.Public | BindingFlags.Instance);
            if (null != prop && prop.CanWrite)
            {
                prop.SetValue(data, value, null);
            }
        }

        public static object ReflectionGet(object data, string fieldName)
        {
            var type = data.GetType();
            var prop = type.GetProperty(fieldName);
            if (prop != null)
            {
                return prop.GetValue(data, null);
            }
            return null;
        }

        public static object GetFormObject(Control parentForm)
        {
            var saveObject = Activator.CreateInstance(Main.currentModel);
            foreach (Control data in parentForm.Controls)
            {
                if (!IsSaveData(data.Name, Main.currentModel)) continue;
                object saveData = null;
                string saveName = GetUIModelName(data.Name);
                saveData = data.Text;
                if (saveData != null)
                {
                    ReflectionSet(saveObject, saveName, saveData);
                }
            }

            return saveObject;
        }

        public static T GetFormObject<T>(Control parentForm) where T : new()
        {
            var data = new T();
            var modelName = typeof(T);
            foreach (Control control in parentForm.Controls)
            {
                if (control.Name == "defaultInfo")
                {
                    var defaultInfo = control.Controls;
                    DecorateSaveData(data, defaultInfo["Id"].Text.IsEmpty());
                    continue;
                }

                if (!IsSaveData(control.Name, modelName)) continue;

                var saveName = GetUIModelName(control.Name);
                object fieldData = GetControlValue(control);

                if (fieldData != null)
                {
                    ReflectionSet(data, saveName, fieldData);
                }
            }

            return data;
        }

        public static object GetControlValue(Control control)
        {
            var controlType = control.GetType();
            object result = null;
            switch (controlType.Name)
            {
                case "ComboBox":
                    result = (long)(control as ComboBox).SelectedValue;
                    break;
                case "DateTimePicker":
                    result = TimeHelper.DateTimeToTimeStamp((control as DateTimePicker).Value);
                    break;
                default:
                    result = control.Text;
                    break;
            }
            return result;
        }

        public static void ClearControlValue(Control control)
        {
            var controlType = control.GetType();
            object result = null;
            switch (controlType.Name)
            {
                case "ComboBox":
                    (control as ComboBox).SelectedIndex = 0;
                    break;
                case "DateTimePicker":
                case "TextBox":
                case "RichTextBox":
                    control.Text = "";
                    break;
            }
        }

        public static void SetControlValue(Control control, object value)
        {
            var controlType = control.GetType();
            switch (controlType.Name)
            {
                case "ComboBox":
                    (control as ComboBox).SelectedValue = value;
                    break;
                case "DateTimePicker":
                    control.Text = TimeHelper.TimestampToString((long)value);
                    break;
                default:
                    control.Text = value.ToString();
                    break;
            }
        }


        public static void DecorateSaveData(object data, bool isNew = true)
        {
            var currentTime = TimeHelper.CurrentTimeStamp();
            ReflectionSet(data, "AuthorId", 1L);
            if (isNew)
            {
                ReflectionSet(data, "CreatedDate", currentTime);
            }
            ReflectionSet(data, "ModifiedDate", currentTime);
            ReflectionSet(data, "IsActived", true);
        }
    }
}
