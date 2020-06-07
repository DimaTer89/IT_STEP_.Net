using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Epam
{
    class ClientCollection
    {
        Client[] clientArray;
        public ClientCollection(Client[] clientArray)
        {
            this.clientArray = clientArray;
        }
        void PaintUpTable()
        {
            Console.WriteLine($"╔══════════════════════════════╦═══════════╦═════════════╦════════════════╗");
            Console.WriteLine($"║{"Клиент",20}{" ",10}║{"Тип клиента"}║{"Энергия(кВат)",10}║{"Сумма к оплате",16}║");
        }
        void PaintDownTable()
        {
            Console.WriteLine($"╚══════════════════════════════╩═══════════╩═════════════╩════════════════╝");
        }
        public void ShowData()
        {
            PaintUpTable();
            foreach (Client item in clientArray)
            {
                Console.WriteLine($"╠══════════════════════════════╬═══════════╬═════════════╬════════════════╣");
                Console.WriteLine(item);
            }
            PaintDownTable();
        }
        public void SortByEnergeCount()
        {
            Array.Sort(clientArray);
            ShowData();
        }
        public void SortByValuePayment()
        {
            Array.Sort(clientArray, new ValuePayment());
            ShowData();
        }
        public void SortByClientType()
        {
            Array.Sort(clientArray, new ClientTypeSort());
            ShowData();
        }
        public decimal TotalSumPaymentEnergy()
        {
           return clientArray.Sum(client => client.EnergySum());
        }
        public decimal AmountOfBenefits()
        {
            return (clientArray.Sum(client => client.EnergyConsumed) * clientArray[0].Rate.Bet - TotalSumPaymentEnergy());
        }
    }
}
