using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
/*Для  решения задачи создать класс Rabotnik содержащий следующие элементы:
 * закрытые поля фамилия,
 * название фирмы, 
 * зарплата за полугодие (массив), 
 * дата рождения,
 * метод для определения средней зарплаты,
 * свойство для определения возраста.*/
namespace WindowsFormsDZ_3._2
{
    public class Rabotnik
    {
        string surname;
        string labelFirm;
        string dateBirthDay;
        decimal[] salary;
        static string datePattern = @"\b(([0][1-9]|[1,2][0-9]|[3][0-1])[./-]?([0][1-9]|[1][0-2])[./-]?)\d\d(\d\d)\b";
        Regex dateRegex = new Regex(datePattern);
        public Rabotnik()
        {
            Surname = "";
            LabelFilm = "";
            DateOfBirthday = "";
            Salary1="";
        }
        public Rabotnik(string surname,string labelFilm,string dateOfBirthday,params decimal[] salary)
        {
            Surname = surname;
            LabelFilm = labelFilm;
            DateOfBirthday = dateOfBirthday;
            Salary = salary;
        }
        public string Surname
        {
            get => surname;
            set => surname = value;
        }
        public string LabelFilm
        {
            get => labelFirm;
            set => labelFirm = value;
        }
        public decimal[] Salary
        {
            get => salary;
            set => salary = value;
        }
        public string DateOfBirthday
        {
            get => dateBirthDay;
            set
            {
                try
                {
                    if (dateRegex.IsMatch(value))
                        dateBirthDay = value;
                    else
                        dateBirthDay = "";
                }
                catch { }
            }
        }
        public string Salary1
        {
            get
            {
                StringBuilder tmp = new StringBuilder();
                for (int i = 0; i < salary.Length; i++)
                {
                    if (i < salary.Length - 1)
                        tmp.Append(salary[i] + " ");
                    else
                        tmp.Append(salary[i]);
                }
                return tmp.ToString();
            }
            set
            {
                string[] str = value.Split(' ');
                try
                {
                    salary = new decimal[str.Length];
                    for (int i = 0; i < str.Length; i++)
                    {
                        salary[i] = Convert.ToDecimal(str[i]);
                    }
                }
                catch {  }
            }
        }
        public decimal MiddleSalary() => Salary.Average();
        public override string ToString()
        {
            StringBuilder tmp = new StringBuilder();
            for (int i = 0; i < salary.Length; i++)
            {
                if (i < salary.Length - 1)
                    tmp.Append(salary[i] + " ");
                else
                    tmp.Append(salary[i]);
            }
            return (Surname + ";" + LabelFilm + ";" + DateOfBirthday + ";" + tmp.ToString());
        }
       public int Age()
        {

            if (dateBirthDay != "" && dateRegex.IsMatch(dateBirthDay))
                return DateTime.Now.Year - Convert.ToDateTime(dateBirthDay).Year;
            else if (DateOfBirthday == "")
                return 999;
            else
                return 0;
       }
    }
}
