using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Дополнительно создать класс , реализующий интерфейс IComparer. Использовать объект класса для сортировки списка людей по алфавиту.
namespace HomeWork6_3
{
    class ClassSortByAlfavit : IComparer
    {
        public int Compare(object x, object y)
        {
            Human human1 = x as Human;
            Human human2 = y as Human;
            return ((human1 == null && human2 == null) ? 0 : (human1 == null) ? -1 : (human2 == null) ? 1 : (human1.Surname.CompareTo(human2.Surname)));
        }
    }
}
