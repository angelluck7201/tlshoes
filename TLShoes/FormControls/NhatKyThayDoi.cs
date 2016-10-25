using System;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.FormControls;
using TLShoes.ViewModels;

namespace TLShoes.Form
{
    public partial class NhatKyThayDoi : BaseUserControl
    {
        private string _modelName;
        private long _modelId;
        private Action _callBack;
        public NhatKyThayDoi()
        {
            InitializeComponent();
            Init();
        }

        public NhatKyThayDoi(string modelName, long modelId, Action callback)
        {
            InitializeComponent();
            Init();

            _modelName = modelName;
            _modelId = modelId;
            _callBack = callback;
        }

        public override void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(_modelName) && _modelId > 0)
            {
                var nhatKyThayDoi = new TLShoes.NhatKyThayDoi
                {
                    GhiChu = GhiChu.Text,
                    ModelName = _modelName,
                    ItemId = _modelId
                };
                CRUD.DecorateSaveData(nhatKyThayDoi);
                SF.Get<NhatKyThayDoiViewModel>().Save(nhatKyThayDoi);
            }

            if (_callBack != null)
            {
                _callBack();
            }

            // Close popup 
            if (ParentForm != null)
            {
                ParentForm.Close();
            }
        }
    }
}
