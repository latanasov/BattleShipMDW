using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class CBattleship : IBattleship, IBattleshipCallback, IChat, IChatCallback,ILobby,ILobbyCallback
    {
        private static List<Player> PlayerList = new List<Player>();//players who are available for a game
        private static List<Player> PlayerListInGame = new List<Player>();//For players currently in a game to use the p2p chat
        private static List<Player> matchPlayers = new List<Player>();//to match 2 random players
        private static List<Session> SessionList = new List<Session>();
        private  List<string> playerNames = new List<string>();
        private int playersWillingToPlay = 0;
        
        private IBattleshipCallback ToCallBack;
        private IChatCallback ToCallbackChat;
        private ILobbyCallback ToCallbackLobby;

        //BATTLESHIP REGION
        #region
        //BATTLESHIP CONTRACT FUNCTIONS
        public void RegisterBattleshipClient(string playerName)
        {
            IBattleshipCallback currentCallBack = OperationContext.Current.GetCallbackChannel<IBattleshipCallback>();

            foreach (Player myplayer in PlayerList)
            {
                if(myplayer.Name==playerName)
                {
                    myplayer.CallbackBattleship=currentCallBack;
                }
            }

        }

        public void ReadyForBattle()
        {
            IBattleshipCallback currentCallBack = OperationContext.Current.GetCallbackChannel<IBattleshipCallback>();
            foreach (Session mySes in SessionList)
            {
                if (mySes.P1.CallbackBattleship == currentCallBack)
                {
                    mySes.P1.readyForBattle = true;
                    ToCallBack = mySes.P2.CallbackBattleship;
                    EnemyReady();
                    if (mySes.P1.readyForBattle == true && mySes.P2.readyForBattle == true)
                    {
                        ToCallBack = mySes.P1.CallbackBattleship;
                        StartGame(0);
                        ToCallBack = mySes.P2.CallbackBattleship;
                        StartGame(1);
                    }
                }
                else if (mySes.P2.CallbackBattleship == currentCallBack)
                {
                    mySes.P2.readyForBattle = true;
                    ToCallBack = mySes.P1.CallbackBattleship;
                    EnemyReady();
                    if (mySes.P1.readyForBattle == true && mySes.P2.readyForBattle == true)
                    {
                        ToCallBack = mySes.P1.CallbackBattleship;
                        StartGame(0);
                        ToCallBack = mySes.P2.CallbackBattleship;
                        StartGame(1);
                    }
                }
            }
        }

        public void Shoot(System.Drawing.Point target)
        {
            IBattleshipCallback currentCallBack = OperationContext.Current.GetCallbackChannel<IBattleshipCallback>();
            foreach (Session mySes in SessionList)
            {
                if (mySes.P1.CallbackBattleship == currentCallBack)
                {
                    ToCallBack = mySes.P2.CallbackBattleship;
                    ReceiveHit(target);  //p1 sends hit to p2
                }
                else if (mySes.P2.CallbackBattleship == currentCallBack)
                {
                    ToCallBack = mySes.P1.CallbackBattleship;
                    ReceiveHit(target); //p2 sends hit to p1
                }
            }
        }

        public void SendHitResult(bool result)
        {
            IBattleshipCallback currentCallBack = OperationContext.Current.GetCallbackChannel<IBattleshipCallback>();
            foreach (Session mySes in SessionList)
            {
                if (mySes.P1.CallbackBattleship == currentCallBack)
                {
                    ToCallBack = mySes.P2.CallbackBattleship;
                    ReceiveHitResult(result);
                }
                else if (mySes.P2.CallbackBattleship == currentCallBack)
                {
                    ToCallBack = mySes.P1.CallbackBattleship;
                    ReceiveHitResult(result);
                }
            }
        }

        public void GameEnded()
        {
            //Only the player who lost the game calls this, so whever is called back will win the game
            IBattleshipCallback currentCallBack = OperationContext.Current.GetCallbackChannel<IBattleshipCallback>();
            foreach (Session mySes in SessionList)
            {
                if (mySes.P1.CallbackBattleship == currentCallBack)
                {
                    ToCallBack = mySes.P2.CallbackBattleship;
                    ReceiveGameEnd();
                }
                else if (mySes.P2.CallbackBattleship == currentCallBack)
                {
                    ToCallBack = mySes.P1.CallbackBattleship;
                    ReceiveGameEnd();
                }
            }
        }
    
        //BATTLESHIP CALLBACK
        public void StartGame(int StartingPosition)
        {
            ToCallBack.StartGame(StartingPosition); //starts game for each player. if starting position is 0, that person starts first, if 1 that will wait for next turn
        }
        public void EnemyReady()
        {
            ToCallBack.EnemyReady();
        }
        public void PlaceShips()
        {
            ToCallBack.PlaceShips();
        }
        public void ReceiveHit(System.Drawing.Point target)
        {
            ToCallBack.ReceiveHit(target); //sends hit to the player
        }
        public void ReceiveHitResult(bool result)
        {
            ToCallBack.ReceiveHitResult(result);
        }
        public void ReceiveGameEnd()
        {
            ToCallBack.ReceiveGameEnd();
        }
        #endregion

        //CHAT REGION
        #region
        //CHAT CONTRACT FUNCTIONS
        public void RegisterChatRoom(string playername)
        {
            foreach (Player myplayer in PlayerList)
            {
                if (myplayer.Name == playername)
                {
                    myplayer.CallbackChat = OperationContext.Current.GetCallbackChannel<IChatCallback>();
                }
            }
        }
        public void SendMessage(string message)
        {
            IChatCallback currentCallBack = OperationContext.Current.GetCallbackChannel<IChatCallback>();
            foreach (Session mySes in SessionList)
            {
                if (mySes.P1.CallbackChat == currentCallBack)
                {
                    ToCallbackChat = mySes.P2.CallbackChat;
                    ReceiveMessage(mySes.P1.Name+" says:"+message);  //p1 sends message to p2
                }
                if (mySes.P2.CallbackChat == currentCallBack)
                {
                    ToCallbackChat = mySes.P1.CallbackChat;
                    ReceiveMessage(mySes.P2.Name + " says:" + message);  //p2 sends message to p1
                }
            }
        }
        public void SendLobbyMessage(string message)
        {
            IChatCallback currentCallBack = OperationContext.Current.GetCallbackChannel<IChatCallback>();
            string SenderName = "";
            foreach (Player myplayer in PlayerList)
            {
                if (currentCallBack == myplayer.CallbackChat)
                {
                    SenderName = myplayer.Name;
                }
            }
            foreach (Player myplayer in PlayerList)
            {
                if (currentCallBack != myplayer.CallbackChat)
                {
                    ToCallbackChat = myplayer.CallbackChat;
                    ReceiveLobbyMessage(SenderName+ " says:" + message);
                }
            }
        }
//CHAT CALLBACK
        public void ReceiveMessage(string message)
        {
            ToCallbackChat.ReceiveMessage(message);
        }
        public void ReceiveLobbyMessage(string message)
        {
            ToCallbackChat.ReceiveLobbyMessage(message);
        }
        #endregion

        //LOBBY REGION
        #region
        //LOBBY FUNCTIONS
        /*A method to add a player to the lsit of available players*/
        public void logPlayer(string name)
        {
            ILobbyCallback currentCallBack = OperationContext.Current.GetCallbackChannel<ILobbyCallback>();

            int counter = 0;
            bool isNameFree = true;


            while (counter < PlayerList.Count)
            {
                /*check if the name is already in use*/
                if (PlayerList[counter].Name == name)
                {
                    isNameFree = false;
                }
                counter++;
            }

            if (isNameFree == false) 
            {
                ToCallbackLobby = currentCallBack;
                this.receiveLoginResult(false);
            }
            else
            {
                Player newPlayer = new Player();
                newPlayer.Name = name;
                newPlayer.CallbackLobby = OperationContext.Current.GetCallbackChannel<ILobbyCallback>();
                PlayerList.Add(newPlayer);

                List<string> tempList = new List<string>();
                int i = 0;
                while (i < PlayerList.Count)
                {
                    tempList.Add(PlayerList[i].Name);
                    i++;
                }
                
                ToCallbackLobby = newPlayer.CallbackLobby;
                this.receiveLoginResult(true);

                foreach (Player myplayer in PlayerList)
                {
                    ToCallbackLobby = myplayer.CallbackLobby;
                    this.receiveAvailablePlayers(tempList);
                }
                
            }
            
        }
        /*Match 2 players for a random game*/
        public void RandomGame(string playerName)
        {
            //OperationContext.Current.GetCallbackChannel<IBattleshipCallback>().notifyPlayerInvitation("John");
            int counter = 0;

            while (counter < PlayerList.Count)
            {
                if (PlayerList[counter].Name == playerName)
                {
                    matchPlayers.Add(PlayerList[counter]);
                    PlayerListInGame.Add(PlayerList[counter]);
                    PlayerList.RemoveAt(counter);
                }
                counter++;
            }
            playersWillingToPlay++;
            if ((matchPlayers.Count > 1))
            {
                Session newSession = new Session(matchPlayers[0], matchPlayers[1]);
                SessionList.Add(newSession);
                matchPlayers[0].currentSession = newSession;
                matchPlayers[1].currentSession = newSession;
                ToCallBack = newSession.P1.CallbackBattleship;
                PlaceShips();
                ToCallBack = newSession.P2.CallbackBattleship;
                PlaceShips();
                matchPlayers.RemoveRange(0, matchPlayers.Count);
            }

        }
        /*If a player accept a game invoke a new private game*/
        public void acceptInvitationInvokeGame(string player1, string player2)
        {
            int counter = 0;
            List<Player> privateGame = new List<Player>();

            int toremove_1 = 0;
            int toremove_2 = 0;
            while (counter < PlayerList.Count)
            {
                if (PlayerList[counter].Name == player1)
                {
                    privateGame.Add(PlayerList[counter]);
                    PlayerListInGame.Add(PlayerList[counter]);
                    toremove_1 = counter;
                }
                if (PlayerList[counter].Name == player2)
                {
                    privateGame.Add(PlayerList[counter]);
                    PlayerListInGame.Add(PlayerList[counter]);
                    toremove_2= counter;
                }
                counter++;
            }

            PlayerList.RemoveAt(toremove_1);
            PlayerList.RemoveAt(toremove_2);

            Session newSession = new Session(privateGame[0], privateGame[1]);
            SessionList.Add(newSession);
            privateGame[0].currentSession = newSession;
            privateGame[1].currentSession = newSession;
            ToCallBack = newSession.P1.CallbackBattleship;
            PlaceShips();
            ToCallBack = newSession.P2.CallbackBattleship;
            PlaceShips();
            privateGame.RemoveRange(0, matchPlayers.Count);

        }
        /***Decline invitation and notify other player***/
        public void declineInvitation(string invitedFrom)
        {
            int counter = 0;
            List<Player> privateGame = new List<Player>();

            while (counter < PlayerList.Count)
            {
                if (PlayerList[counter].Name == invitedFrom)
                {
                    PlayerList[counter].CallbackLobby.notifyPlayerInvitationResult(false);
                }

                counter++;
            }


        }
        public void invitePlayer(string invitedFrom, string InvitePlayer)
        {
            int counter = 0;
            while (counter < PlayerList.Count)
            {
                if (PlayerList[counter].Name == InvitePlayer)
                {

                    PlayerList[counter].CallbackLobby.notifyPlayerInvitation(invitedFrom);

                }
                counter++;
            }
        }
        /***Logout***/
        public void logOut(string playerName)
        {
            int counter = 0;


            while (counter < PlayerList.Count)
            {
                if (PlayerList[counter].Name == playerName)
                {

                    PlayerList.RemoveAt(counter);
                }
                counter++;
            }
            List<string> tempList = new List<string>();
            int i = 0;
            while (i < PlayerList.Count)
            {
                tempList.Add(PlayerList[i].Name);
                i++;
            }
            foreach (Player myplayer in PlayerList)
            {
                ToCallbackLobby = myplayer.CallbackLobby;
                this.receiveAvailablePlayers(tempList);
            }
        }
//LOBBY CALLBACK
        public void notifyPlayerInvitationResult(bool acceptOrDecline)
        {
            ToCallbackLobby.notifyPlayerInvitationResult(acceptOrDecline);
        }

        public void notifyPlayerInvitation(string invitedFrom)
        {
            ToCallbackLobby.notifyPlayerInvitation(invitedFrom);
        }

        public void receiveAvailablePlayers(List<string> AvailablePlayers)
        {
            ToCallbackLobby.receiveAvailablePlayers(AvailablePlayers);
        }
        
        public void receiveLoginResult(bool result)
        {
            ToCallbackLobby.receiveLoginResult(result);
        }
        #endregion


    }
}
