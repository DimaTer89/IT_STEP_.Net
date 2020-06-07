using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Разработать класс, описывающий некоторый физический материал.
Поля: имя, плотность.
Методы: getters/setters;
ToString( ) – значения полей объекта в csv формат (например, steel;7850). 
Разработать класс, описывающий однородный предмет, состоящий из одного материала.
Поля: имя, материал (объект класса, описанного выше), объём.
Методы: 
	getters/setters;
	GetMass( ) – вычисление массы предмета (= плотность * объём);
ToString( ) – объект в строку в csv формате (wire;steel;7850;0.03;235.5). 
В методе Main:
1 Создать объект Стальной_Провод из стали в объёме 0.03м3.
2 Вывести объект на консоль с использованием ToString( ).
3 Изменить материал провода на медь (плотность = 8500) и вывести на консоль его новую массу.
*/
namespace physical_material
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();
            subject.setMater("Сталь", 7850); 
            subject.Name="Провод";
            subject.Volume = 0.03;
            Console.WriteLine(subject);
            subject.setMater("Медь", 8500);
            Console.WriteLine(subject);
            Console.ReadKey();
        }
    }
}
