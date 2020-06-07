using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Описать класс Пациент, содержащий поля для хранения фамилии, диагноза, даты и времени приема, номера кабинета.
Описать класс Врач, содержащий следующие поля: фамилия, время приема, номер кабинета.
	Создает два объекта класса Врач.
	Создает четыре объекта класса Пациент: два лечатся у одного врача, два у другого. Каждый пациент  должен быть «зарегистрирован» в «своем» объекте класса  Врач.
*/
namespace HomeWork8_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Doctor[] doctor =
            {
                new Doctor("Петухов В.В.",DateTime.Now.ToLongTimeString(),2),
                new Doctor("Петренко А.С.",DateTime.Now.ToLongTimeString(),12)
            };
            Patient[] patient =
            {
                new Patient("Иванов","Грипп","29.12.09",doctor[0].TimeOfReceipt,doctor[0].NumberOfCabinet),
                new Patient("Петров","Пневмония","3.08.09",doctor[0].TimeOfReceipt,doctor[0].NumberOfCabinet),
                new Patient("Дибров","перелом","12.03.09",doctor[1].TimeOfReceipt,doctor[1].NumberOfCabinet),
                new Patient("Семёнов","Растяжение","20.04.09",doctor[1].TimeOfReceipt,doctor[1].NumberOfCabinet),
            };
            doctor[0].newNumberCabinet += patient[0].ChangeCabinetNumber;
            doctor[0].newNumberCabinet += patient[1].ChangeCabinetNumber;
            doctor[1].newNumberCabinet += patient[2].ChangeCabinetNumber;
            doctor[1].newNumberCabinet += patient[3].ChangeCabinetNumber;
            Console.WriteLine(doctor[0]);
            Tablica();
            Console.WriteLine(patient[0]);
            Console.WriteLine(patient[1]);
            downTablica();
            Console.WriteLine(doctor[1]);
            Tablica();
            Console.WriteLine(patient[2]);
            Console.WriteLine(patient[3]);
            downTablica();
            Console.Write("Введите фамили врача : ");
            string surnameDoctor = Console.ReadLine();
            bool flag = false;
            int indexOf=0;
            for(int i=0;i<doctor.Length;i++)
            {
                if (doctor[i].Surname.CompareTo(surnameDoctor) == 0)
                {
                    indexOf = i;
                    flag = true;
                }
            }
            if(flag)
            {
                doctor[indexOf].NumberOfCabinet = 15;
                Console.WriteLine("Изменения прошли успешно");
                RegistrationList(doctor, patient);
            }
            else
            {
                Console.WriteLine("Изменения не возможны, так как врача с фамилией "+surnameDoctor+" в больнице не числится");
                RegistrationList(doctor, patient);
            }
            Console.ReadKey();
        }
        static void Tablica()
        {
            Console.WriteLine("╔════════════════╦══════════════════════╦════════════════╗");
            Console.WriteLine("║     Фамилия    ║      Дата приёма     ║     Диагноз    ║");
        }
        static void downTablica()
        {
            Console.WriteLine("╚════════════════╩══════════════════════╩════════════════╝");
        }
        static void RegistrationList(Doctor[] doctor,Patient[] patient)
        {
            Console.WriteLine("╔════════════════╦════════════════════╦════════════════╦═══════════════╦═════════════════╦════════════╗");
            Console.WriteLine("║     Фамилия    ║   Номер кабинета   ║   Дата приёма  ║  Время приёма ║  Фамилия врача  ║   Диагноз  ║");
            int i = 0;
            int j = 0;
            for(i=0;i<doctor.Length;i++)
            {
                for(int l=0;l<patient.Length/2;l++)
                {
                    Console.WriteLine("╠════════════════╬════════════════════╬════════════════╬═══════════════╬═════════════════╬════════════╣");
                    Console.WriteLine($"║{patient[j].Surname,16}║{patient[j].CabinetNumber,20}║{patient[j].Date,16}║{patient[j].Time,15}║{doctor[i].Surname,17}║{patient[j].Diagnoz,12}║");
                    j++;
                }
            }
            Console.WriteLine("╚════════════════╩════════════════════╩════════════════╩═══════════════╩═════════════════╩════════════╝");
        }
    }
}
