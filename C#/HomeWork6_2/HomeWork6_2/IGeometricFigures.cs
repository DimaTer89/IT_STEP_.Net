using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Интерфейс должен определять следующие элементы: свойство, возвращающее  площадь фигуры, метод вывода информации, и наследовать интерфейс IComparable для сравнения фигур по типу.
namespace HomeWork6_2
{
    interface IGeometricFigures:IComparable
    {
        double FigureArea { get; }
        void Print();
    }
}
