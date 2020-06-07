using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Класс Student должен содержать закрытые поля: фамилия, номер группы, успеваемость (массив оценок) и все необходимые для решения задачи свойства и методы.
/*Написать приложение, выполняющее следующие функции:
	Ввод с клавиатуры данных  о студентах в массив объектов класса Student.
	Вывод списка всех студентов с указанием среднего балла каждого студента в порядке возрастания среднего балла.
	Определение количества студентов, получивших больше двух оценок 10 в массиве.
	Вывод списка двоечников в заданной группе (если таких студентов нет, вывести соответствующее сообщение).
*/
namespace HomeWork3_1
{
    class Student
    {
        string surname;
        string number_of_group;
        int[] assessments;
        public Student()
        {
            surname = null;
            number_of_group = null;
            assessments = null;
        }
        public Student(string surname,string number_of_group,params int[] assessments)
        {
            this.surname = surname;
            this.number_of_group = number_of_group;
            this.assessments = assessments;
        }
        public int Count_Asses => assessments.Length;
        public double Middle_Bal
        {
            get
            {
                double sum = 0;
                foreach (int item in assessments)
                {
                    sum += item;
                    
                }
                return (sum / assessments.Length);
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public string Number_of_group
        {
            get
            {
                return number_of_group;
            }
            set
            {
                number_of_group = value;
            }
        }
        public int[] Assessements
        {
            get
            {
                return assessments;
            }
            set
            {
                assessments = value;
            }
        }
        public void ShowStudent()
        {
            Console.WriteLine("Фамилия : " + surname);
            Console.WriteLine("Группа : " + number_of_group);
            Console.Write("Оценки : ");
            if (assessments != null)
            {
                for (int i = 0; i < assessments.Length; i++)
                {
                    Console.Write(assessments[i] + "  ");
                }
            }
            Console.WriteLine();
        }
    }
}
