using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLShoes
{
    public abstract class BaseForm: UserControl
    {
        public abstract void ReloadData();
    }
}
