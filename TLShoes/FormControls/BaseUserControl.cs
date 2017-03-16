using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraSplashScreen;
using Microsoft.Office.Interop.Excel;
using TLShoes.Common;
using TLShoes.ViewModels;
using Action = System.Action;
using Application = Microsoft.Office.Interop.Excel.Application;

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
            foreach (var control in FormControls)
            {
                if (control.Name == "btnSave")
                {
                    if (Authorization.CheckAuthorization(Main.currentModel.Name, Define.Authorization.WRITE))
                    {
                        control.Click += new EventHandler(btnSave_Click);
                        control.Visible = true;
                    }
                    else
                    {
                        control.Visible = false;
                    }
                }
                else if (control.Name == "btnSaveContinue")
                {
                    if (Authorization.CheckAuthorization(Main.currentModel.Name, Define.Authorization.WRITE))
                    {
                        control.Click += new EventHandler(btnSaveContinue_Click);
                        control.Visible = true;
                    }
                    else
                    {
                        control.Visible = false;
                    }
                }
                else if (control.Name == "btnCancel")
                {
                    control.Click += new EventHandler(btnCancel_Click);
                }
                else if (control.GetType().Name == "ImageEdit" || control.GetType().Name == "PictureEdit")
                {
                    control.DoubleClick += new EventHandler(FileHelper.ShowImagePopup);
                }

                var controlType = control.GetType();
                if (controlType.Name == "ComboBox")
                {
                    var combobox = control as ComboBox;
                    combobox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
                    combobox.Leave += Combobox_Leave;
                }
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
                            CRUD.SetControlValue(control, defaultData);
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

        public virtual void Combobox_Leave(object sender, EventArgs e)
        {
            var combobox = sender as ComboBox;
            if (combobox != null)
            {
                var selectedValue = combobox.SelectedValue;
                if (selectedValue == null)
                {
                    combobox.SelectedIndex = 0;
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
                var parentForm = this.ParentForm;
                ObserverControl.PulishAction(Define.ActionType.SAVE);
                if (parentForm != null) parentForm.Close();
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
            var parentForm = this.ParentForm;
            if (parentForm != null) parentForm.Close();
        }

        public virtual void ShowCustomForm(UserControl customControl, string formTitle)
        {
            var defaultForm = new DefaultForm();

            defaultForm.Height = customControl.Height + 50;
            defaultForm.Width = customControl.Width + 15;
            defaultForm.Text = formTitle;
            defaultForm.Controls.Add(customControl);
            customControl.Dock = DockStyle.Fill;

            defaultForm.CustomShow(ParentForm);
        }

        public void SetComboboxDataSource(ComboBox comboBox, object dataSource, string display, string key = "Id")
        {
            comboBox.DisplayMember = display;
            comboBox.ValueMember = key;
            comboBox.DataSource = new BindingSource(dataSource, null);
        }

        public void SetComboboxDataSource(ComboBox comboBox, object dictDataSource)
        {
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
            var convertedDict = dictDataSource as Dictionary<string, string>;
            comboBox.DataSource = new BindingSource(convertedDict, null);
        }

        public void SetRepositoryItem(RepositoryItemLookUpEdit item, object dataSource, string display, string value = "Id")
        {
            item.NullText = "";
            item.Properties.DataSource = dataSource;
            item.PopulateColumns();
            item.ShowHeader = false;
            foreach (LookUpColumnInfo column in item.Columns)
            {
                column.Visible = false;
            }
            item.Columns[display].Visible = true;
            item.Properties.DisplayMember = display;
            item.Properties.ValueMember = value;
            item.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        }

        public void Export(string template, Action<Workbook, _Worksheet> action)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = Define.EXPORT_EXTENSION;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ThreadHelper.LoadForm(() =>
                {
                    var templatePath = FileHelper.GetExportTemplate(template);

                    //Start Excel and get Application object.
                    var excel = new Application();

                    //Get a new workbook.
                    var workBook = excel.Workbooks.Open(templatePath);
                    var workSheet = (_Worksheet)workBook.ActiveSheet;

                    try
                    {
                        action(workBook, workSheet);
                        workBook.SaveAs(saveDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Define.MESSAGE_EXPORT_FAIL_TITLE, Define.MESSAGE_EXPORT_FAIL_TITLE);
                        SplashScreenManager.CloseDefaultWaitForm();
                    }
                    finally
                    {
                        workBook.Close();
                    }

                });

                var confirmDialog = MessageBox.Show(Define.MESSAGE_EXPORT_SUCCESS_TEXT, Define.MESSAGE_EXPORT_SUCCESS_TITLE, MessageBoxButtons.YesNo);
                if (confirmDialog == DialogResult.Yes)
                {
                    Process.Start(saveDialog.FileName);
                }

                var parentForm = this.ParentForm;
                if (parentForm != null) parentForm.Close();
            }
        }
    }
}
