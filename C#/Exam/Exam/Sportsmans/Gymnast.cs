using System;
/*Класс гимнастов должен содержать дополнительные поля оценки за упражнения на кольцах, на брусьях, за опорный прыжок,
 * конструктор с параметрами, реализацию метода для определения лучшего результата соревнований, операции < и  > для сравнения гимнастов по результатам.*/
namespace Exam.Sportsmans
{
    [Serializable]
    public class Gymnast : Sportsman
    {
        double ringExercises;
        double exercisesOnUnevenBars;
        double vault;
        public Gymnast()
        {

        }
        public Gymnast(string surname,int age,string kindOfSport,double ringExercises,double exercisesOnUnevenBars,double vault):base(surname,age,kindOfSport)
        {
            RingExercises = ringExercises;
            ExercisesOnUnevenBars = exercisesOnUnevenBars;
            Vault = vault;
        }
        public double RingExercises
        {
            get => ringExercises;
            set
            {
                if (value > 0)
                    ringExercises = value;
                else
                    throw new Exception("Отрицательная оценка за упражнения на кольцах");
            }
        }
        public double ExercisesOnUnevenBars
        {
            get => exercisesOnUnevenBars;
            set
            {
                if (value > 0)
                    exercisesOnUnevenBars = value;
                else
                    throw new Exception("Отрицательная оценка за упражнения на брусьях");
            }
        }
        public double Vault
        {
            get => vault;
            set
            {
                if (value > 0)
                    vault = value;
                else
                    throw new Exception("Отрицательная оценка за опорный прыжок");
            }
        }
        public static Gymnast operator +(Gymnast gymnast1,Gymnast gymnast)
        {
            gymnast1 = new Gymnast(gymnast.Surname, gymnast.Age, gymnast.KindOfSport, gymnast.RingExercises, gymnast.ExercisesOnUnevenBars, gymnast.Vault);
            return gymnast1; 
        }
        public static bool operator <(Gymnast gymnast1,Gymnast gymnast2)
        {
            return gymnast1.BestResult() < gymnast2.BestResult();
        }
        public static bool operator >(Gymnast gymnast1, Gymnast gymnast2)
        {
            return gymnast1.BestResult() > gymnast2.BestResult();
        }
        public override double BestResult()
        {
            if (ringExercises > exercisesOnUnevenBars && ringExercises > vault)
                return ringExercises;
            if (exercisesOnUnevenBars > ringExercises && exercisesOnUnevenBars > vault)
                return exercisesOnUnevenBars;
            else 
                return vault;
        }
        public override string ToString()
        {
            return (base.ToString() + $"{BestResult(),4}{" баллов"}{" ",11}║");
        }
    }
}
