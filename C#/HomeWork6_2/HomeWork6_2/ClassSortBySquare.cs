using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_2
{
    class ClassSortBySquare : IComparer
    {
        public int Compare(object x, object y)
        {
            IGeometricFigures figura1 = x as IGeometricFigures;
            IGeometricFigures figura2 = y as IGeometricFigures;
            return ((figura1 == null && figura2 == null) ? 0 : (figura1 == null) ? -1 : (figura2 == null) ? -1 : figura1.FigureArea.CompareTo(figura2.FigureArea));
        }
    }
}
