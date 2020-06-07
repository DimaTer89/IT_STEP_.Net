using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxySingletton.Interfaces;
using ProxySingletton.Singletton;

namespace ProxySingletton.Proxy
{
    class DeputyHead : IPrizeOrder
    {
        IPrizeOrder chief;
        public string Name { get; private set; }
        public DeputyHead(string name) => Name = name;
        public string CreatePrizeOrder(string fname, decimal bonusPrecenge)
        {
            chief = Chief.GetChief();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{' ',25}Директор : " + chief.Name);
            builder.AppendLine($"{' ',40}Приказ");
            builder.AppendLine($"{' ',3}О назначении премии работнику фирмы <<Какая-то фирма>>");
            builder.AppendLine($"{' ',15}№ 12-54{' ',10}от{' ',10}" + DateTime.Now.ToShortDateString());
            builder.AppendLine(chief.CreatePrizeOrder(fname, bonusPrecenge));
            builder.AppendLine("Заместитель начальника : " + Name);
            builder.AppendLine("Подпись : ");
            return builder.ToString();
        }
    }
}
