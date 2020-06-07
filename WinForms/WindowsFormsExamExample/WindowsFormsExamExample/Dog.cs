using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WindowsFormsExamExample
{
    class Dog
    {
        public string NickName { get; set; }
        public string Kind { get; set; }
        public int YearOfBirthday { get; set; }
        public Dog()
        { }
        public Dog(string nickname,string kind,int yearofbirthday)
        {
            NickName = nickname;
            Kind = kind;
            YearOfBirthday = yearofbirthday;
        }
        public int AgeDog() => DateTime.Now.Year - YearOfBirthday;
    }
}
