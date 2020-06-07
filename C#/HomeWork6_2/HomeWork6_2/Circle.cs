using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Класс кругов должен содержать следующие элементы: поля - радиус, цвет фигуры,   конструктор, реализованные элементы интерфейса. 
namespace HomeWork6_2
{
    class Circle:IGeometricFigures
    {
        public Figures figura;
        double radius;
        string color;
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value > 0)
                    radius = value;
                else
                    throw new Exception("Отрицательный радиус!!!");
            }
        }

        public double FigureArea => Math.PI * Radius * Radius;
        public Circle(double radius,string color)
        {
            Radius = radius;
            this.color = color;
            figura = Figures.Circle;
        }

        public void Print()
        {
            string str = "Окружность";
            Console.WriteLine($"╠══════════════╬════════════════════╬═══════════════════════════╣\n║{str,14}║{FigureArea,20:f2}║Цвет : {color,20}║");
        }

        public int CompareTo(object obj)
        {
            IGeometricFigures geometric = obj as IGeometricFigures;
            Type type1 = this.GetType();
            Type type2 = geometric.GetType();
            if (this == null && geometric == null)
                return 0;
            if (this == null)
                return -1;
            if (geometric == null)
                return 1;
            return (type1.Name.CompareTo(type2.Name));
        }
    }
}
