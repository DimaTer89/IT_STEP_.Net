using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankServiceProject
{
   //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
  //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class BankService : IBankService
    {
       static int id = 0; //для нумерации
                            //создаваемых счетов
        public decimal Balance {get;set;} //баланс счета
        //создание нового счета
        public BankService()
        {
            ++id;
            Console.WriteLine("Создан счет № " +id);
            //Console.WriteLine("Идентификатор сессии "+OperationContext.Current.SessionId);
        }
        //перевод денег на созданный счет
        
//[OperationBehavior (TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void ToDeposit(decimal sum)
        {
            Balance += sum;
            if (sum < 0)
                throw new Exception("Как нехорошо получилось...");
        }
        //вывод текущего баланса счета
        public decimal GetBalance()
        {
            return Balance;
        }
    }
}
