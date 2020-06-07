using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    static class ListExtention
    {
        public static string GetString(this List<string> list)
        {
            StringBuilder s = new StringBuilder();
            list.ForEach(u => { s.Append(u).Append(";"); });
            list.Add(s.ToString());
            return s.ToString();
        }
    }
}
