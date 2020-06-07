using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankServiceProject
{
   
   // [ServiceContract(SessionMode=SessionMode.Allowed)]// служба создаст
                            //сессию, если входящая привязка поддерживает сессии (по умолчанию)
   [ServiceContract(SessionMode = SessionMode.Required)]// служба требует
//создания сессии; если входящая привязка не поддер-
//живает сессии – будет сгенерирована исключительная ситуация
  //  [ServiceContract(SessionMode = SessionMode.NotAllowed)]// служба не допускает использования привязки, 
        //инициализирующей создание сессии
    public interface IBankService
    {
        [OperationContract]
        void ToDeposit(decimal sum);
        [OperationContract]
        decimal GetBalance();
      //дополнительные возможности управления поведением сессии
        //[OperationContract(IsOneWay = true,IsInitiating = true, IsTerminating = false)]
//        void Init();//этот метод создает (или начинает) сессию.
////Это будет только в том случае, когда такой метод вызывается первым. 
//        [OperationContract(IsInitiating = false,IsTerminating = true)]
//        bool Finish();//начинает асинхронное завершение текущей сессии после окончания своего выполнения
    }

}
