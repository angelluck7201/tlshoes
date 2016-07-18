using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLShoes.Common
{
    public class CommonClass
    {
        public class GopYItem
        {
            public string BoPhan { get; set; }
            public string GopY { get; set; }

            public GopYItem(string boPhan, string gopY)
            {
                BoPhan = boPhan;
                GopY = gopY;
            }

        }
    }
}
