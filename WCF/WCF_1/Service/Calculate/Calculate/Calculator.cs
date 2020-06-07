using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Calculate
{
    public class Calculator : ICalculateContract,IDopContract,IPersonContract
    {
        public double Plus(double x, double y) => (x + y);

        public double SinXCosY(double x, double y) => (Math.Sin(x) + Math.Cos(y));

        public double Sqr(double x) => (x * x);

        public double TexX(double x) => (10 * x);

        public double WeightPlus(ref Person person, double x)
        {
            person.Weight+=x;
            return person.Weight;
        }
        public void HelloPerson(Person person, string hello)
        {
            Console.WriteLine(hello+person.Name);
            Thread.Sleep(2000);
        }
    }
}
