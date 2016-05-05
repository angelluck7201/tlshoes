using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLShoes
{
    public class FormFactory<T> where T: new()
    {
        static Dictionary<string, T> ControlDict = new Dictionary<string, T>();

        public static T Get()
        {
            var controlName = typeof (T).Name;
            if (!ControlDict.ContainsKey(controlName))
            {
                ControlDict.Add(controlName, new T());
            }
            return ControlDict[controlName];
        }
    }
}
