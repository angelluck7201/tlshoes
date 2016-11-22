using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using ComboBox = System.Windows.Forms.ComboBox;

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
                var fieldType = prop.PropertyType;

                if (fieldType == typeof(string))
                {
                    prop.SetValue(data, value, null);
                }
                else
                {
                    var targetType = IsNullableType(prop.PropertyType) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType;
                    if (targetType == typeof(float))
                    {
                        value = Convert.ChangeType(PrimitiveConvert.StringToFloat(value), targetType);
                    }
                    else
                    {
                        value = Convert.ChangeType(PrimitiveConvert.StringToInt(value), targetType);
                    }
                    prop.SetValue(data, value, null);
                }
            }
        }

        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
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

        public static List<Control> GetAllChild(Control parenControl)
        {
            var result = new List<Control>();
            foreach (Control control in parenControl.Controls)
            {
                result.Add(control);
                if (control.HasChildren)
                {
                    result.AddRange(GetAllChild(control));
                }
            }

            result.RemoveAll(s => string.IsNullOrEmpty(s.Name));
            return result;
        }

        public static T GetFormObject<T>(List<Control> controls) where T : new()
        {
            var data = new T();
            var modelName = typeof(T);
            foreach (Control control in controls)
            {
                var controlName = control.Name;

                if (controlName == "Id")
                {
                    ReflectionSet(data, "Id", PrimitiveConvert.StringToInt(control.Text));
                    DecorateSaveData(data, control.Text.IsEmpty());
                    continue;
                }

                if (!IsSaveData(controlName, modelName)) continue;

                object fieldData = GetControlValue(control);
                var saveName = GetUIModelName(controlName);

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
                    var comboboxData = (control as ComboBox).SelectedValue;
                    if (comboboxData is Enum)
                    {
                        result = comboboxData.ToString();
                    }
                    else
                    {
                        result = (long)comboboxData;
                    }

                    break;
                case "DateTimePicker":
                    result = TimeHelper.DateTimeToTimeStamp((control as DateTimePicker).Value);
                    break;
                case "RatingControl":
                    result = (int)(control as RatingControl).Rating;
                    break;
                case "ImageEdit":
                    var imageEdit = control as ImageEdit;
                    if (imageEdit != null && imageEdit.Image != null)
                    {
                        result = FileHelper.ImageSave(imageEdit.Image, imageEdit.Tag);
                    }
                    break;
                case "PictureEdit":
                    var pictureEdit = control as PictureEdit;
                    if (pictureEdit != null && pictureEdit.Image != null)
                    {
                        result = FileHelper.ImageSave(pictureEdit.Image, pictureEdit.Tag);
                    }
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
                    //                    (control as ComboBox).SelectedIndex = 0;
                    break;
                case "RatingControl":
                    (control as RatingControl).Rating = 0;
                    break;
                case "ImageEdit":
                    (control as ImageEdit).Image = null;
                    break;
                case "PictureEdit":
                    (control as PictureEdit).Image = null;
                    break;
                case "DateTimePicker":
                case "TextBox":
                case "RichTextBox":
                case "TextEdit":
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
                case "RatingControl":
                    (control as RatingControl).Rating = decimal.Parse(value.ToString());
                    break;
                //case "ImageEdit":
                //    var imagePath = value.ToString();
                //    if (File.Exists(imagePath))
                //    {
                //        var imageContainer = (control as ImageEdit);
                //        FileHelper.SetImage(imageContainer, imagePath);
                //    }
                //    break;
                case "PictureEdit":
                    var picturePath = value.ToString();
                    if (File.Exists(picturePath))
                    {
                        var imageContainer = (control as PictureEdit);
                        FileHelper.SetImage(imageContainer, picturePath);
                    }
                    break;
                default:
                    control.Text = value.ToString();
                    break;
            }
        }

        public static void DecorateSaveData(object data, bool isNew = true)
        {
            var currentTime = TimeHelper.CurrentTimeStamp();
            ReflectionSet(data, "AuthorId", Authorization.LoginUser.Id);
            if (isNew)
            {
                ReflectionSet(data, "CreatedDate", currentTime);
            }
            ReflectionSet(data, "ModifiedDate", currentTime);
            ReflectionSet(data, "IsActived", true);
        }
    }
}
