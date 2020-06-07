using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChatService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ChatServiceFunction : IChatService
    {
        //public static int count = 0;
        static List<ConnectedUser> users = new List<ConnectedUser>();
        ConnectedUser currentUser;
        class ConnectedUser
        {
            public string Login { get; set; }
            public ICallBackClient CallBackClient { get; set; }
            //public ConnectedUser(string login,ICallBackClient callBackClient)
            //{
            //    this.login = login;
            //    this.callBackClient = callBackClient;
            //}
        }
        public List<string> GetUserList()
        {
            throw new NotImplementedException();
        }

        public void Join(string login)
        {
            throw new NotImplementedException();
        }

        public void Leave()
        {
            throw new NotImplementedException();
        }

        public bool Registration(string login, string password)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string text)
        {
            throw new NotImplementedException();
        }

        public bool Validate(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
