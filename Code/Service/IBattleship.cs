using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;

namespace Service
{
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
        [ServiceContract]
        public interface IBattleshipCallback
        {
            [OperationContract(IsOneWay = true)]
            void StartGame(int StartingPosition);
            [OperationContract(IsOneWay = true)]
            void PlaceShips();
            [OperationContract(IsOneWay = true)]
            void ReceiveHit(Point target);
            [OperationContract(IsOneWay = true)]
            void ReceiveHitResult(Boolean result);
            [OperationContract(IsOneWay = true)]
            void EnemyReady();
            [OperationContract(IsOneWay = true)]
            void ReceiveGameEnd();

        }

        [ServiceContract(Namespace = "MyBattleshipContract", SessionMode = SessionMode.Required, CallbackContract = typeof(IBattleshipCallback))]    
        public interface IBattleship
        {
            [OperationContract(IsOneWay = true)]
            void RegisterBattleshipClient(string playerName);

            [OperationContract(IsOneWay = true)]
            void Shoot(Point target); //shoots target, returns true if hit, false if not

            [OperationContract(IsOneWay = true)]
            void ReadyForBattle();

            [OperationContract(IsOneWay = true)]
            void SendHitResult(Boolean result);

            [OperationContract(IsOneWay = true)]
            void GameEnded();

        }
}
