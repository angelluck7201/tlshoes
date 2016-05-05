using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLShoes.ViewModels
{
    public class SF
    {
        static Dictionary<string, object> dictionary = new Dictionary<string, object>(); 
        public static T Get<T>() where T: new ()
        {
            var modelName = typeof (T).ToString();
            if (!dictionary.ContainsKey(modelName))
            {
                dictionary.Add(modelName, new T());
            }
            return (T)dictionary[modelName];
        }
    }
}
