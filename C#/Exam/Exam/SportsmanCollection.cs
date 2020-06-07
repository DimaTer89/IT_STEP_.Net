using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
/*Создать класс-коллекцию (generic) с необходимой функциональностью.
* Создать в этом классе метод для поиска информации по заданному критерию (критерий  передавать через параметр-делегат: стандартный или созданный, результат – объект этого класса).
* Предусмотреть метод для сериализации объекта класса в двоичном формате (параметры – имя файла, форматер). Перегрузить этот метод для сериализации объекта класса в формате XML.*/
namespace Exam
{
    class SportsmanCollection<T>
    {
        List<T> sportCollection=new List<T>();
        public SportsmanCollection(List<T> sportList)
        {
            sportCollection = sportList;
        }
        public List<T> SportsMens => sportCollection;
        public void ShowSportsMans() => sportCollection.ForEach(list => Console.WriteLine(list));
        public SportsmanCollection<T> Find(Predicate<T> func)
        {
            List<T> temp = new List<T>();
            for(int i=0;i<sportCollection.Count;i++)
            {
                if(func(sportCollection[i]))
                    temp.Add(sportCollection[i]);
            }
            return new SportsmanCollection<T>(temp);
        }
        public void Sort(IComparer<T> comparer)
        {
            sportCollection.Sort(comparer);
        }
        public void Serialization(BinaryFormatter formatter,string path="SportsManList.dat")
        {
            using (FileStream file = File.Create(path))
            {
                formatter.Serialize(file, sportCollection);
            }
            Console.WriteLine("Сериализация в бинарном формате прошла успешно");
        }
        public void Serialization(XmlSerializer xmlFormatter, string path = "SportsManList.xml")
        {
            using (FileStream file = File.Create(path))
            {
                xmlFormatter.Serialize(file, sportCollection);
            }
            Console.WriteLine("Сериализация в xml-формате прошла успешно");
        }
        public void DeSeriliazition(XmlSerializer xmlFormatter,string path="SportsManlist.xml")
        {
            List<Sportsman> list = new List<Sportsman>();
            using (FileStream file = File.OpenRead(path))
            {
                list=(List<Sportsman>)xmlFormatter.Deserialize(file);
            }
            list.ForEach(lis => Console.WriteLine(lis));
        }
    }
}
