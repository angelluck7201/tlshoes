using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraSpreadsheet;
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
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spreadsheetControl1;
        private GiayTLEntities _dbContext;

        public GiayTLEntities DbContext
        {
            get
            {
                if (_dbContext == null)
                    _dbContext = new GiayTLEntities();
                return _dbContext;
            }
        }

        public void Init()
        {
            FormControls = CRUD.GetAllChild(this);
            InitAction();
        }

        public void Init<T>(T data = null) where T: class
        {
            Init();
            if (data != null)
            {
                InitFormData(data);
            }
        }

        public void BindingData<T>(T data)
        {
            if (FormControls == null || FormControls.Count == 0)
            {
                FormControls = CRUD.GetAllChild(this);
            }
            var modelName = CRUD.GetModelName(data);
            foreach (var formControl in FormControls)
            {
                var splitControl = formControl.Name.Split('_');
                if (splitControl.Length != 2 || splitControl[0] != modelName) continue;
                // Clear previous binding to prevent duplicate binding
                formControl.DataBindings.Clear();
                CRUD.BindingControl(formControl, data, splitControl[1]);
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

        public void InitFormData<T>(T data)
        {
            var modelName = CRUD.GetModelName(data);

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
                        var splitControl = control.Name.Split('_');
                        if (splitControl.Length != 2 || splitControl[0] != modelName) continue;
                        CRUD.BindingControl(control, data, splitControl[1]);
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
                if (selectedValue == null && combobox.Items.Count > 0)
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
            //var saveDialog = new SaveFileDialog();
            //saveDialog.Filter = Define.EXPORT_EXTENSION;
            //if (saveDialog.ShowDialog() == DialogResult.OK)
            //{
                ThreadHelper.LoadForm(() =>
                {
                    var templatePath = FileHelper.GetExportTemplate(template);

                    //Start Excel and get Application object.
                    var excel = new Application();
                    //Get a new workbook.
                    var workBook = excel.Workbooks.Open(templatePath);
                    var workSheet = (_Worksheet)workBook.ActiveSheet;

                    //excel.Visible = true;
                 
                    try
                    {
                        action(workBook, workSheet);
                        workBook.Save();

                        spreadsheetControl1 = new SpreadsheetControl();
                        spreadsheetControl1.LoadDocument(templatePath);
                        spreadsheetControl1.ShowPrintPreview();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Define.MESSAGE_EXPORT_FAIL_TITLE, Define.MESSAGE_EXPORT_FAIL_TITLE);
                    }
                    finally
                    {
                        workBook.Close();
                        excel.Quit();

                        // Delete temfile 
                        FileHelper.DeleteFile(templatePath);
                    }
                });


                var parentForm = this.ParentForm;
                if (parentForm != null) parentForm.Close();
            //}
        }

        private void InitializeComponent()
        {
            this.spreadsheetControl1 = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.SuspendLayout();
            // 
            // spreadsheetControl1
            // 
            this.spreadsheetControl1.Location = new System.Drawing.Point(34, 26);
            this.spreadsheetControl1.Name = "spreadsheetControl1";
            this.spreadsheetControl1.Size = new System.Drawing.Size(400, 200);
            this.spreadsheetControl1.TabIndex = 0;
            this.spreadsheetControl1.Text = "spreadsheetControl1";
            this.spreadsheetControl1.Visible = false;
            // 
            // BaseUserControl
            // 
            this.Controls.Add(this.spreadsheetControl1);
            this.Name = "BaseUserControl";
            this.ResumeLayout(false);

        }
    }
}
