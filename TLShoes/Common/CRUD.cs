﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using ComboBox = System.Windows.Forms.ComboBox;

namespace TLShoes.Common
{
    public static class CRUD
    {
        public static string GetUIFieldName(string uiName)
        {
            var modelName = uiName.Split('_');
            if (modelName.Length > 1)
            {
                return modelName[1];
            }
            return string.Empty;
        }

        public static string GetModelName<T>(T data)
        {
            var modelName = typeof(T).ToString();
            if (modelName.Contains("."))
            {
                return modelName.Split('.').Last();
            }
            return modelName;
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

                var targetType = IsNullableType(prop.PropertyType) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType;
                if (targetType != typeof (string))
                {
                    if (targetType == typeof(float))
                    {
                        value = Convert.ChangeType(PrimitiveConvert.StringToFloat(value), targetType);
                    }
                    else if (value.IsNumber())
                    {
                        value = Convert.ChangeType(PrimitiveConvert.StringToInt(value), targetType);
                    }
                }
                prop.SetValue(data, value, null);
            }
        }

        public static bool IsNumber(this object value)
        {
            if (value != null)
            {
                double tempNum;
                return double.TryParse(value.ToString(), out tempNum);
            }
            return false;
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
                string saveName = GetUIFieldName(data.Name);
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

        public static T GetFormObject<T>(List<Control> controls, T currentData = null) where T : class, new()
        {
            var data = currentData ?? new T();

            var modelName = typeof(T);
            foreach (Control control in controls)
            {
                var controlName = control.Name;

                if (controlName == "Id")
                {
                    ReflectionSet(data, "Id", PrimitiveConvert.StringToInt(control.Text));
                    DecorateSaveData(data);
                    continue;
                }

                if (!IsSaveData(controlName, modelName)) continue;

                object fieldData = GetControlValue(control);
                var saveName = GetUIFieldName(controlName);

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
                    if (comboboxData.IsNumber())
                    {
                        result = (long)comboboxData;
                    }
                    else
                    {
                        result = comboboxData.ToString();
                    }

                    break;
                case "DateTimePicker":
                    result = (control as DateTimePicker).Value;
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
                    if (pictureEdit != null)
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
                    var combobox = (control as ComboBox);
                    combobox.SelectedValue = value;
                    break;
                case "DateTimePicker":
                    control.Text = value.ToString();
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
                    var imageContainer = (control as PictureEdit);
                    FileHelper.SetImage(imageContainer, value.ToString());
                    break;
                default:
                    control.Text = value.ToString();
                    break;
            }
        }

        public static void BindingControl(Control control, object data, string fieldName)
        {
            var controlType = control.GetType();
            switch (controlType.Name)
            {
                case "ComboBox":
                    control.DataBindings.Add("SelectedValue", data, fieldName, true, DataSourceUpdateMode.OnPropertyChanged);
                    break;
;                case "RatingControl":
                    control.DataBindings.Add("Rating", data, fieldName);
                    break;
                case "PictureEdit":
                    var imageContainer = (control as PictureEdit);
                    var value = ReflectionGet(data, fieldName);
                    if (value != null)
                    {
                        FileHelper.SetImage(imageContainer, value.ToString());
                    }
                    break;
                default:
                    control.DataBindings.Add("Text", data, fieldName);
                    break;
            }
        }

        public static void DecorateSaveData(GiayTLEntities dbContext)
        {
            var changedEntities = dbContext.ChangeTracker.Entries().Where(s => s.State != EntityState.Unchanged);
            foreach (var changedEntity in changedEntities)
            {
                DecorateSaveData(changedEntity.Entity);
            }
        }

        public static void DecorateSaveData(object data)
        {
            var currentTime = TimeHelper.Current();
            ReflectionSet(data, "AuthorId", Authorization.LoginUser.Id);

            var createdDate = (DateTime)ReflectionGet(data, "CreatedDate");
            if (createdDate.Year == 1 )
            {
                ReflectionSet(data, "CreatedDate", currentTime);
            }
            ReflectionSet(data, "ModifiedDate", currentTime);
            ReflectionSet(data, "IsActived", true);
        }
    }
}
