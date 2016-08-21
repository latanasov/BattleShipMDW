using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    public enum GameStates
    {
        ConnectingToServer,
        WaitingOtherPlayer,
        AddingShips,
        WaitingOtherPlayerToAddShips,
        YourTurn,
        EnemyTurn,
        EndGame
    }
}
