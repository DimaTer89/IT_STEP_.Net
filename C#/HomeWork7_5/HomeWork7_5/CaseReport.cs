using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7_5
{
    struct CaseReport:IComparable
    {
        public string surname;
        public string dateOfBirthday;
        public string receiptDate;
        public Diagnoz bolezn;
        public CaseReport(string surname,string dateOfBirthday,string receiptDate,Diagnoz diagnoz)
        {
            this.surname = surname;
            this.dateOfBirthday = dateOfBirthday;
            this.receiptDate = receiptDate;
            bolezn = diagnoz;
        }
        public int Age()
        {
            DateTime date = DateTime.Parse(dateOfBirthday);
            return (DateTime.Now.Year - date.Year);
        }

        public int CompareTo(object obj)
        {
            CaseReport tmp = (CaseReport)obj;
            return (this.DayInHospital().CompareTo(tmp.DayInHospital()));
        }

        public int DayInHospital()
        {
            DateTime date = DateTime.Parse(receiptDate);
            TimeSpan ts = DateTime.Now - date;
            return (ts.Days);
        }
        public void Show(int i,ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.End)
            {
                Console.WriteLine("╠═══╬════════════════╬═══════════════════════╬════════════════╣");
                Console.WriteLine($"║{i,3}║{surname,16}║{receiptDate,23}║{dateOfBirthday,16}║");
            }
            if(key.Key==ConsoleKey.Home)
            {
                Console.WriteLine("╠═══╬════════════════╬═══════════╣");
                Console.WriteLine($"║{i,3}║{surname,16}║{Age(),11}║");
            }
            if(key.Key==ConsoleKey.Insert)
            {
                Console.WriteLine("╠═══╬════════════════╬════════════════════╬═════════╣");
                Console.WriteLine($"║{i,3}║{surname,16}║{DayInHospital(),20}║{Age(),9}║");
            }
        }
    }
}
