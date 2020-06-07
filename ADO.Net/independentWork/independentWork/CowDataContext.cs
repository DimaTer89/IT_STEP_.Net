using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace independentWork
{
    public class CowDataContext:DataContext
    {
        public Table<Cow> Cows { get; set; }
        public CowDataContext(string connectString):base(connectString)
        {
            Cows = GetTable<Cow>();
        }
    }
}
