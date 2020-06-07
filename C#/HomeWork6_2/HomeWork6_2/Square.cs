using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Класс квадратов должен содержать следующие элементы:поле-сторону квадрата, конструктор, реализованные элементы интерфейса, метод вычисления периметра. 
namespace HomeWork6_2
{
    class Square:IGeometricFigures
    {
        public Figures figura;
        const int kolSide = 4;
        double side;
        public double Side
        {
            get
            {
                return side;
            }
            set
            {
                if (value > 0)
                    side = value;
                else
                    throw new Exception("Сторона не должна быть отрицательной!!!");
            }
        }

        public double FigureArea =>Side*Side;

        public Square(double side)
        {
            Side = side;
            figura = Figures.Square;
        }
        private double Perimeter => Side * kolSide;
        public void Print()
        {
            string str = "Квадрат";
            Console.WriteLine($"╠══════════════╬════════════════════╬═══════════════════════════╣\n║{str,14}║{FigureArea,20:f2}║Периметр : {Perimeter,16:f2}║");
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
