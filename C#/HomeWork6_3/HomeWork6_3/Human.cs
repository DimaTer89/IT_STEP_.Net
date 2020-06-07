using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Класс «человек» должен содержать следующие элементы: поле-фамилия, поле-год рождения,
 * поле статус (студент, преподаватель, бизнесмен и т.д.), конструктор с параметрами, конструктор без параметров, метод вывода информации об объекте,
 * виртуальный методом Info возвращающим  возраст. Использовать метод Info в методе вывода информации.
 * Реализовать в классе «Человек» интерфейс IComparable для сравнения людей по возрасту. 
 * */

namespace HomeWork6_3
{
    class Human : IComparable
    {
        protected string surname;
        protected int yearOfBirth;
        protected string status;
        public Human()
        {
            surname = "Иванов";
            yearOfBirth = 1990;
            status = "Бизнесмен";
        }
        public Human(string surname,int yearOfBirth,string status)
        {
            this.surname = surname;
            this.yearOfBirth = yearOfBirth;
            this.status = status;
        }
        public string Surname => surname;
        public virtual int Info()
        {
            return (DateTime.Now.Year - yearOfBirth);
        }
        public override string ToString()
        {
            return ($"╠═════════════════╬══════════════════════╬══════════════════╬═════════════════════════════════════════╣\n║{surname,17}║{Info(),22}║{status,18}║{" ",41}║");
        }
        public int CompareTo(object obj)
        {
            if(this is Student&&obj is Student)
            {
                Human tmp = obj as Human;
                return ((this == null && tmp == null) ? 0 : (this == null) ? -1 : (tmp == null) ? 1 : (((Student)this).Age.CompareTo(((Student)tmp).Age)));
            }
            if(this is Student)
            {
                Human tmp = obj as Human;
                return ((this == null && tmp == null) ? 0 : (this == null) ? -1 : (tmp == null) ? 1 : (((Student)this).Age.CompareTo(tmp.Info())));
            }
            if(obj is Student)
            {
                Human tmp = obj as Human;
                return ((this == null && tmp == null) ? 0 : (this == null) ? -1 : (tmp == null) ? 1 : (this.Info().CompareTo(((Student)tmp).Age)));
            }
            else
            {
                Human tmp = obj as Human;
                return ((this == null && tmp == null) ? 0 : (this == null) ? -1 : (tmp == null) ? 1 : (this.Info().CompareTo(tmp.Info())));
            }
        }
    }
}
