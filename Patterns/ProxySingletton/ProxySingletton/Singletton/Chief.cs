using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxySingletton.Interfaces;

namespace ProxySingletton.Singletton
{
    class Chief :IPrizeOrder
    {
        private static IPrizeOrder chief;
        public string Name { get; private set; }
        private decimal bonusFund = 100000;
        private Chief(string name) => Name = name;
        public static IPrizeOrder GetChief()
        {
            if (chief == null)
                return chief = new Chief("Иванов Иван Иванович");
            return chief;

        }
        public string CreatePrizeOrder(string fName, decimal bonusPercentage)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{' ',40}Приказываю");
            builder.AppendLine("За добросовестный труд выписать внеочередную премию " + fName + " в размере " + ((bonusFund/100)*bonusPercentage) + " долларов");
            return builder.ToString();
        }
    }
}
