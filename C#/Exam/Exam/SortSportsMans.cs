using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class SortSportsMans : IComparer<Sportsman>
    {
        public int Compare(Sportsman x, Sportsman y)
        {
            return (x == null && y == null ? 0 : x == null ? 1 : y == null ? -1 : x.Age.CompareTo(y.Age));
        }
    }
}
