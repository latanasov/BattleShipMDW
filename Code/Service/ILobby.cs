using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    public interface ILobbyCallback
    {
        [OperationContract(IsOneWay = true)]
        void receiveAvailablePlayers(List<string> AvailablePlayers);
        [OperationContract(IsOneWay = true)]
        void notifyPlayerInvitationResult(bool acceptOrDecline);//if true-accepted else declined
        [OperationContract(IsOneWay = true)]
        void notifyPlayerInvitation(string invitedFrom);
        [OperationContract(IsOneWay = true)]
        void receiveLoginResult(bool result);
    }

    [ServiceContract(Namespace = "MyLobbyContract", SessionMode = SessionMode.Required, CallbackContract = typeof(ILobbyCallback))]
    public interface ILobby
    {
        [OperationContract(IsOneWay = true)]
        void logPlayer(string name);
        [OperationContract(IsOneWay = true)]
        void invitePlayer(string invitedFrom, string InvitePlayer);
        [OperationContract(IsOneWay = true)]
        void acceptInvitationInvokeGame(string player1, string player2);
        [OperationContract(IsOneWay = true)]
        void declineInvitation(string invitedFrom);
        [OperationContract(IsOneWay = true)]
        void RandomGame(string playerName);
        [OperationContract(IsOneWay = true)]
        void logOut(string playerName);

        
    }
   
}
