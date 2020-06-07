using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//класс Врач, содержащий следующие поля: фамилия, время приема, номер кабинета.
namespace HomeWork8_3
{
    class Doctor
    {
        public event EventHandler newNumberCabinet;
        string surname;
        string timeOfReceipt;
        int numberOfCabinet;
        public Doctor(string surname,string timeofReceipt,int numberCabinet)
        {
            Surname = surname;
            TimeOfReceipt = timeofReceipt;
            NumberOfCabinet = numberCabinet;
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
        public string TimeOfReceipt
        {
            get
            {
                return timeOfReceipt;
            }
            set
            {
                timeOfReceipt = value;
            }
        }
        public int NumberOfCabinet
        {
            get
            {
                return numberOfCabinet;
            }
            set
            {
                if (value > 0)
                {
                    numberOfCabinet = value;
                    newNumberCabinet?.Invoke(this, new EventArgs());
                }
                else
                    throw new Exception("Не удачный номер кабинета");
            }
        }
        public override string ToString()
        {
            return ($"Врач : {Surname} кабинет №{NumberOfCabinet}");
        }
    }
}
