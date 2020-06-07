using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Класс студентов должен содержать дополнительные поля-оценки по математике, физике и истории, конструктор с параметрами, метод  для получения среднего балла за сессию. 
 * Переопределить метод Info в классе «Студент» так, чтобы он возвращал максимальную оценку.*/
namespace HomeWork6_3
{
    class Student:Human
    {
        const int kol = 3;
        int[] math;
        int[] physics;
        int[] history;
        int[][] grades;
        public Student(string surname,int yearOfBirth,string status,int[] gradeMath,int[] gradePhysics,int[] gradeHistory):base(surname,yearOfBirth,status)
        {
            if (testGrade(gradeMath) && testGrade(gradePhysics) && testGrade(gradeHistory))
            {
                math = gradeMath;
                physics = gradePhysics;
                history = gradeHistory;
                int[][] tmp = new int[kol][];
                tmp[0] = math;
                tmp[1] = physics;
                tmp[2] = history;
                grades = tmp;
            }
            else
                throw new Exception("Не верные оценки");
        }
        public int Age
        {
            get
            {
                return base.Info();
            }
        }
        public override int Info()
        {
            int max = grades[0][0];
            for(int i=0;i<grades.Length;i++)
            {
               for(int j=0;j<grades[i].Length;j++)
               {
                    if (grades[i][j] > max)
                        max = grades[i][j];
               }
            }
            return max;
        }
        public double GPA()
        {
            
            double sum = 0;
            int count = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                for (int j = 0; j < grades[i].Length; j++)
                {
                    sum += grades[i][j];
                    count++;
                }
                
            }
            return ((double)sum/count);
        }
        public override string ToString()
        {
            StringBuilder[] str = new StringBuilder[3];
            str[0] = new StringBuilder();
            str[1] = new StringBuilder();
            str[2] = new StringBuilder();
            for(int i=0;i<grades.Length;i++)
            {
                for(int j=0;j<grades[i].Length;j++)
                {
                    str[i].Append($"{grades[i][j],3}");
                }
            }
            return ($"╠═════════════════╬══════════════════════╬══════════════════╬═════════════════════════════════════════╣\n║{" ",17}║{" ",22}║{" ",18}║Оценки(мат):{str[0],29}║\n║{" ",17}║{" ",22}║{" ",18}║Оценки(физ):{str[1],29}║\n║{surname,17}║{base.Info(),22}║{status,18}║Оценки(история):{str[2],25}║\n║{" ",17}║{" ",22}║{" ",18}║Максимальная оценка :{Info(),20}║\n║{" ",17}║{" ",22}║{" ",18}║Средний балл за сессию :{GPA(),17:f2}║");
        }
        bool testGrade(int[] grade)
        {
            for(int i=0;i<grade.Length;i++)
            {
                if (grade[i] < 1||grade[i]>10)
                    return false;
            }
            return true;
        }

    }
}

