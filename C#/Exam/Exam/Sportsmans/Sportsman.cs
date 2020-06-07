using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Класс «Спортсмен» должен быть абстрактным и содержать следующие элементы: поле-фамилия,
 * поле - возраст, поле вид спорта (гимнастика, бокс, плавание и т.д.), 
 * конструктор с параметрами, свойства для чтения полей класса, абстрактный метод для определения лучшего результата соревнований.*/
namespace Exam
{
    [Serializable]
    public abstract class Sportsman
    {
        string surname;
        int age;
        string kindOfSport;
        public Sportsman()
        {

        }
        public Sportsman(string surname, int age, string kindOfSport)
        {
            this.surname=surname;
            Age = age;
            this.kindOfSport = kindOfSport;
        }
        public string Surname
        {
            get => surname;
            set => surname = value;
        }
        public int Age
        {
            get => age;
            set
            {
                if (value > 0)
                    age = value;
                else
                    throw new Exception("Отрицательный возраст");
            }
        }
        public string KindOfSport
        {
            get => kindOfSport;
            set => kindOfSport = value;
        }
        abstract public double BestResult();
        public override string ToString()
        {
            return ($"╠═══════════════╬═════════════╬════════════════════╬══════════════════════╣\n║{Surname,15}║{Age,13}║{KindOfSport,20}║");
        }
    }
}
