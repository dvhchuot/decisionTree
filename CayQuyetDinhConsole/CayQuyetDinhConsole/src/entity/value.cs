using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayQuyetDinhConsole.src.entity
{
    class value
    {
        public List<string> values { get; set; }
        public string toString()
        {
            string s="";
            for(int i=0;i < values.Count; i++)
            {
                if (i == 0) s += values[i];
                else s+=","+values[i];
            }
            return s;
        }

    }
}
