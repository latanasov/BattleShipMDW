using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    public interface IChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string message);
        [OperationContract(IsOneWay = true)]
        void ReceiveLobbyMessage(string message);
    }

    [ServiceContract(Namespace = "MyChatContract", SessionMode = SessionMode.Required, CallbackContract = typeof(IChatCallback))]
    public interface IChat
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string message);
        [OperationContract(IsOneWay = true)]
        void RegisterChatRoom(string playername);
        [OperationContract(IsOneWay = true)]
        void SendLobbyMessage(string message);
    }
}
