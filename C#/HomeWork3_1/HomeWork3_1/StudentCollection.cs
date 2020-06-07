using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*  +Ввод с клавиатуры данных  о студентах в массив объектов класса Student.
	+Вывод списка всех студентов с указанием среднего балла каждого студента в порядке возрастания среднего балла.
	Определение количества студентов, получивших больше двух оценок 10 в массиве.
	Вывод списка двоечников в заданной группе (если таких студентов нет, вывести соответствующее сообщение).
*/
namespace HomeWork3_1
{
    class StudentCollection
    {
        Student[] student;
        public int Count => student.Length;
        public StudentCollection()
        {
            student = null;
        }
        public StudentCollection(params Student[] student)
        {
            this.student = student;
        }
        public Student this[int i]
        {
            get
            {
                return student[i];
            }
            set
            {
                student[i] = value;
            }
        }
       
        public void Losers_list()
        {
            int count;
            bool flag = false;
            for(int i=0;i<student.Length;i++)
            {
                count = 0;
                for(int j=0;j<student[i].Count_Asses;j++)
                {
                    if (student[i].Assessements[j] == 2 || student[i].Assessements[j] == 3)
                        count++;
                }
                if (((double)(100 / student[i].Count_Asses) * count) > 50)
                {
                    flag = true;
                    student[i].ShowStudent();
                }
            }
            if(!flag)
                Console.WriteLine("В группе двоечники отсутствуют");
        }
        public void Sort()
        {
            Array.Sort(student, Compare);
        }
        public int Compare(Student student1, Student student2)
        {
            if (student1.Middle_Bal < student2.Middle_Bal)
                return -1;
            else if (student1.Middle_Bal == student2.Middle_Bal)
                return 0;
            else
                return 1;
        }

        public int More_10
        {
            get
            {
                int count;
                int kol_stud = 0;
                for (int i = 0; i < Count; i++)
                {
                    count = 0;
                    for (int j = 0; j < student[i].Count_Asses; j++)
                    {
                        if (student[i].Assessements[j] == 10)
                            count++;
                    }
                    if (count > 2)
                        kol_stud++;
                }
                return kol_stud;
            }
        }
    }
}
