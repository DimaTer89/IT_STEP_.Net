using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChatService
{
    [ServiceContract(CallbackContract =typeof(ICallBackClient))]
    public interface IChatService
    {
        [OperationContract]
        bool Registration(string login, string password);
        [OperationContract]
        bool Validate(string login,string password);
    }
    public interface ICallBackClient
    {

    }
    [DataContract]
    public class Message
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
    }
}
