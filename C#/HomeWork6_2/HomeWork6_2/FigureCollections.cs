using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Создать класс-контейнер для фигур, содержащий поле-массив фигур (ссылок интерфейсного типа),
конструктор, методы для сортировки по площади и по типу фигуры, а также реализующий интерфейс IEnumerable.*/
namespace HomeWork6_2
{
    class FigureCollections : IEnumerable
    {
        IGeometricFigures[] geometricFigures;
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < geometricFigures.Length; i++)
                yield return geometricFigures[i];
        }
        public FigureCollections(params IGeometricFigures[] geometric)
        {
            geometricFigures = geometric;
        }
        public void SortByType()
        {
            Array.Sort(geometricFigures);
        }
        public void SortBySquare()
        {
            Array.Sort(geometricFigures, new ClassSortBySquare());
        }
    }
}
