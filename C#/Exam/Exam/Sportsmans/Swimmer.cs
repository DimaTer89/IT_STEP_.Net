using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Класс пловцов должен содержать дополнительное поле-массив с результатами заплывов, 
  реализацию метода для определения лучшего результата соревнований, конструктор с параметрами,
  метод с переменным числом параметров, возвращающий средний результат за указанные заплывы (например, srednee(1,3) – средний результат за 1-й и 3-й заплывы, srednee(1) – время в 1-м заплыве и т.д.).*/
namespace Exam.Sportsmans
{
    [Serializable]
    public class Swimmer : Sportsman
    {
        double[] swimResult;
        public Swimmer()
        {

        }
        public Swimmer(string surname,int age,string kindOfSport,double[] swimResult):base(surname,age,kindOfSport)
        {
            SwimResult = swimResult;
        }
        public double[] SwimResult
        {
            get => swimResult;
            set
            {
                if (value.Any(list => list < 0))
                    throw new Exception("В результатах спортсмена отрицательный результат");
                else
                    swimResult = value;
            }
        }
        public double AverageResult(params int[] count)
        {
            double sum = 0;
            for (int i = 0; i < count.Length; i++)
            {
                sum += swimResult[count[i] - 1];
            }
            return sum/count.Length;
        }
        public override double BestResult()
        {
            return (swimResult.Min(list => list));
        }
        public override string ToString()
        {
            return (base.ToString()+$"{BestResult(),4}{" сек."}{"",13}║");
        }
    }
}
