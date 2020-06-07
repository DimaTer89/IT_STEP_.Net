using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//класс Пациент, содержащий поля для хранения фамилии, диагноза, даты и времени приема, номера кабинета.
namespace HomeWork8_3
{
    class Patient
    {
        string surname { get; set; }
        string diagnoz { get; set; }
        string date { get; set; }
        string time { get; set; }
        int cabinetNumber;
        public Patient(string name,string diagnoz,string date,string time,int numberCabinet)
        {
            Surname = name;
            Diagnoz = diagnoz;
            Date = date;
            Time = time;
            CabinetNumber = numberCabinet;
        }
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
            }
        }
        public string Diagnoz
        {
            get => diagnoz;
            set
            {
                diagnoz = value;
            }
        }
        public string Date
        {
            get => date;
            set
            {
                date = value;
            }
        }
        public string Time
        {
            get => time;
            set
            {
                time = value;
            }
        }
        public void ChangeCabinetNumber(object doc,EventArgs args)
        {
            if (doc != null)
                cabinetNumber = ((Doctor)doc).NumberOfCabinet;
        }
        public int CabinetNumber
        {
            get => cabinetNumber;
            set
            {
                if (value > 0)
                    cabinetNumber = value;
                else
                    throw new Exception("Не верный номер кабинета");
            }
        }
        public override string ToString()
        {
            return ($"╠════════════════╬══════════════════════╬════════════════╣\n║{Surname,16}║{Date,22}║{Diagnoz,16}║");
        }
    }
}
