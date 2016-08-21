using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class Player
    {
        private string name;
        private IBattleshipCallback callbackBattleship;
        private IChatCallback callbackChat;
        private ILobbyCallback callbackLobby;
        private Boolean ReadyForBattle = false;
        private Session CurrentSession;


        public IChatCallback CallbackChat
        {
            get { return callbackChat; }
            set { callbackChat = value; }
        }
        public ILobbyCallback CallbackLobby
        {
            get { return callbackLobby; }
            set { callbackLobby = value; }
        }
        public Boolean readyForBattle
        {
            get { return ReadyForBattle; }
            set { ReadyForBattle = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public IBattleshipCallback CallbackBattleship
        {
            get { return callbackBattleship; }
            set { callbackBattleship = value; }
        }
        public Session currentSession
        {
            get { return CurrentSession; }
            set { CurrentSession = value; }
        }
    }
}
