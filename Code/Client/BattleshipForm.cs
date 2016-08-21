using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace Client
{
    public partial class frmBattleship : Form
    {
        //CONTRACTS
        #region
        [ServiceContract]
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
        [ServiceContract]
        public interface IChat
        {
            [OperationContract(IsOneWay = true)]
            void RegisterChatRoom(string playername);
            [OperationContract(IsOneWay = true)]
            void SendMessage(string message);
        }
        [ServiceContract]
        public interface ILobby
        {
            void logPlayer(string name);
            [OperationContract(IsOneWay = true)]
            void invitePlayer(string invitedFrom, string InvitePlayer);
            [OperationContract(IsOneWay = true)]
            void acceptInvitationInvokeGame(string player1, string player2);
            [OperationContract(IsOneWay = true)]
            void declineInvitation(string invitedFrom);
            [OperationContract(IsOneWay = true)]
            void RandomGame(string playerName);
        }
        #endregion
        //VARIABLES
        #region
        private MyBattleshipService.BattleshipClient BattleshipProxy;
        private MyBattleshipService.IBattleshipCallback callbackBattleship;

        private MyLobbyService.LobbyClient LobbyProxy;
        private MyLobbyService.ILobbyCallback callbackLobby;
       
        private MyChatService.ChatClient ChatProxy;
        private MyChatService.IChatCallback callbackChat;

        

        private GameBoard AllyBoard;
        private GameBoard EnemyBoard;
        private ShipTypes ChosenShipType;
        private GameStates currentGameState;
        private Point LastShotCoordinates;
        public String playername;
        private string direction = "horizontal";
        private string PBdirection = "h";
        private bool CarrierPlaced = false;
        private bool BattleshipPlaced = false;
        private bool DestroyerPlaced = false;
        private bool SmallshipPlaced = false;
        private bool TinyshipPlaced = false;
        #endregion
        public frmBattleship()
        {
            InitializeComponent();

            AllyBoard = new GameBoard();
            EnemyBoard = new GameBoard();
            panelAlly.Enabled = false;
            panelEnemy.Enabled = false;
            panelAlly.Visible = false;
            panelEnemy.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label_EnemyState.Visible = false;
            label_YourState.Visible = false;
            btnRotate.Visible = false;
            btnLogout.Visible = false;
            btnReady.Visible = false;
            pictureBoxSmallShip.Visible = false;
            pictureBoxSmallShipR.Visible = false;
            pictureBoxTinyShip.Visible = false;
            pictureBoxTinyShipR.Visible = false;
            pictureBoxDestroyer.Visible = false;
            pictureBoxDestroyerR.Visible = false;
            pictureBoxBattleship.Visible = false;
            pictureBoxBattleshipR.Visible = false;
            pictureBoxCarrier.Visible = false;
            pictureBoxCarrierR.Visible = false;
            btnSendText.Visible = false;
            invitePlayer.Enabled = false;
            btnSend.Enabled = false;
            randomGameButton.Enabled = false;

            textBoxSendText.Visible = false;
            richTextBoxChatWindow.Visible = false;
            
            //setup connection for battleship
            callbackBattleship = new BattleshipCallback(this);
            InstanceContext context = new InstanceContext(callbackBattleship);
            BattleshipProxy = new MyBattleshipService.BattleshipClient(context);
            //setup connection for chat
            callbackChat = new ChatCallback(this);
            InstanceContext context2 = new InstanceContext(callbackChat);
            ChatProxy = new MyChatService.ChatClient(context2);
            //setup connection for lobby
            callbackLobby = new LobbyCallBack(this);
            InstanceContext context3 = new InstanceContext(callbackLobby);

            LobbyProxy = new MyLobbyService.LobbyClient(context3);

        }
        //FUNCTIONS
        #region
        private void RefreshGameState()
        {
            if (currentGameState == GameStates.AddingShips)
            {
                ChangeStateToAddingShips();
            }
            if (currentGameState == GameStates.EnemyTurn)
            {
                btnReady.Visible = false;
                this.label_YourState.Text = "Waiting for enemy to shoot";
                this.label_EnemyState.Text = "Enemy will shoot";
            }
            if (currentGameState == GameStates.YourTurn)
            {
                btnReady.Visible = false;
                this.label_YourState.Text = "Shoot your target at enemy sea!";
                this.label_EnemyState.Text = "Waiting for your shoot";
            }
            if (currentGameState == GameStates.EndGame)
            {
                this.panelAlly.Enabled = false;
                this.panelEnemy.Enabled = false;
            }
        }
        private void ChangeStateToAddingShips()
        {
            panelAlly.Enabled = true;
            panelEnemy.Enabled = true;
            panelAlly.Visible = true;
            panelEnemy.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label_EnemyState.Visible = true;
            btnRotate.Visible = true;
            btnReady.Visible = true;
            btnSendText.Visible = true;
            textBoxSendText.Visible = true;
            richTextBoxChatWindow.Visible = true;

            label_EnemyState.Text = "Your enemy is placing ships";
            label_YourState.Text = "Please place your ships and press ready!";
            currentGameState = GameStates.AddingShips;
            panelEnemy.Enabled = true;
            panelAlly.Enabled = true;
            pictureBoxSmallShip.Visible = true;
            pictureBoxSmallShipR.Visible = false;
            pictureBoxTinyShip.Visible = true;
            pictureBoxTinyShipR.Visible = false;
            pictureBoxDestroyer.Visible = true;
            pictureBoxDestroyerR.Visible = false;
            pictureBoxBattleship.Visible = true;
            pictureBoxBattleshipR.Visible = false;
            pictureBoxCarrier.Visible = true;
            pictureBoxCarrierR.Visible = false;
            ChosenShipType = ShipTypes.None;
            MessageBox.Show("Your enemy is connected!Now place your ships!");
        }
        private void AddShip(int i,int j)
        {
            if (ChosenShipType == ShipTypes.SmallShip)
            {
                if (direction == "horizontal")
                {
                    if (j + 1 < 10)
                    {
                        if (AllyBoard.CellList[i, j + 1].cellHasShip == false)
                        {
                            AllyBoard.shipList.Add(new SmallShip(AllyBoard.CellList[i, j], AllyBoard.CellList[i, j + 1], direction));
                            AllyBoard.CellList[i, j].cellHasShip = true;
                            AllyBoard.CellList[i, j + 1].cellHasShip = true;
                            ChosenShipType = ShipTypes.None;
                            pictureBoxSmallShip.Visible = false;
                            pictureBoxSmallShip.Enabled = false;
                            pictureBoxSmallShipR.Visible = false;
                            pictureBoxSmallShipR.Enabled = false;
                            Refresh();
                            SmallshipPlaced = true;
                        }
                        else
                            MessageBox.Show("You cannot place the ship in this cell");
                    }
                    else
                        MessageBox.Show("You cannot place the ship in this cell");
                }
                else if (direction == "vertical")
                {
                    if (i + 1 < 10)
                    {
                        if (AllyBoard.CellList[i + 1, j].cellHasShip == false)
                        {
                            AllyBoard.shipList.Add(new SmallShip(AllyBoard.CellList[i, j], AllyBoard.CellList[i + 1, j], direction));
                            AllyBoard.CellList[i + 1, j].cellHasShip = true;
                            AllyBoard.CellList[i, j].cellHasShip = true;
                            ChosenShipType = ShipTypes.None;
                            pictureBoxSmallShip.Visible = false;
                            pictureBoxSmallShip.Enabled = false;
                            pictureBoxSmallShipR.Visible = false;
                            pictureBoxSmallShipR.Enabled = false;
                            Refresh();
                            SmallshipPlaced = true;
                        }
                        else
                            MessageBox.Show("You cannot place the ship in this cell");
                    }
                    else
                        MessageBox.Show("You cannot place the ship in this cell");
                }
            }
            else if (ChosenShipType == ShipTypes.TinyShip)
            {
                if (direction == "horizontal")
                {
                    AllyBoard.shipList.Add(new TinyShip(AllyBoard.CellList[i, j], direction));
                    AllyBoard.CellList[i, j].cellHasShip = true;
                    pictureBoxTinyShip.Visible = false;
                    pictureBoxTinyShip.Enabled = false;
                    pictureBoxTinyShipR.Visible = false;
                    pictureBoxTinyShipR.Enabled = false;
                    ChosenShipType = ShipTypes.None;
                    Refresh();
                    TinyshipPlaced = true;
                }
                else if (direction == "vertical")
                {
                    AllyBoard.shipList.Add(new TinyShip(AllyBoard.CellList[i, j], direction));
                    AllyBoard.CellList[i, j].cellHasShip = true;
                    pictureBoxTinyShip.Visible = false;
                    pictureBoxTinyShip.Enabled = false;
                    pictureBoxTinyShipR.Visible = false;
                    pictureBoxTinyShipR.Enabled = false;
                    ChosenShipType = ShipTypes.None;
                    Refresh();
                    TinyshipPlaced = true;
                }
            }
            else if (ChosenShipType == ShipTypes.Destroyer)
            {
                if (direction == "horizontal")
                {
                    if (j + 2 < 10)
                    {
                        if (AllyBoard.CellList[i, j + 1].cellHasShip == false && AllyBoard.CellList[i, j + 2].cellHasShip == false)
                        {
                            AllyBoard.shipList.Add(new Destroyer(AllyBoard.CellList[i, j], AllyBoard.CellList[i, j + 1], AllyBoard.CellList[i, j + 2], direction));
                            AllyBoard.CellList[i, j].cellHasShip = true;
                            AllyBoard.CellList[i, j + 1].cellHasShip = true;
                            AllyBoard.CellList[i, j + 2].cellHasShip = true;
                            pictureBoxDestroyer.Visible = false;
                            pictureBoxDestroyer.Enabled = false;
                            pictureBoxDestroyerR.Visible = false;
                            pictureBoxDestroyerR.Enabled = false;
                            ChosenShipType = ShipTypes.None;
                            Refresh();
                            DestroyerPlaced = true;
                        }
                        else
                            MessageBox.Show("You cannot place the ship in this cell");
                    }
                    else
                        MessageBox.Show("You cannot place the ship in this cell");
                }
                else if (direction == "vertical")
                {
                    if (i + 2 < 10)
                    {
                        if (AllyBoard.CellList[i + 1, j].cellHasShip == false && AllyBoard.CellList[i + 2, j].cellHasShip == false)
                        {
                            AllyBoard.shipList.Add(new Destroyer(AllyBoard.CellList[i, j], AllyBoard.CellList[i + 1, j], AllyBoard.CellList[i + 2, j], direction));
                            AllyBoard.CellList[i, j].cellHasShip = true;
                            AllyBoard.CellList[i + 1, j].cellHasShip = true;
                            AllyBoard.CellList[i + 2, j].cellHasShip = true;
                            pictureBoxDestroyer.Visible = false;
                            pictureBoxDestroyer.Enabled = false;
                            pictureBoxDestroyerR.Visible = false;
                            pictureBoxDestroyerR.Enabled = false;
                            ChosenShipType = ShipTypes.None;
                            Refresh();
                            DestroyerPlaced = true;
                        }
                        else
                            MessageBox.Show("You cannot place the ship in this cell");
                    }
                    else
                        MessageBox.Show("You cannot place the ship in this cell");
                }
            }
            else if (ChosenShipType == ShipTypes.Battleship)
            {
                if (direction == "horizontal")
                {
                    if (j + 3 < 10)
                    {

                        if (AllyBoard.CellList[i, j + 1].cellHasShip == false && AllyBoard.CellList[i, j + 2].cellHasShip == false && AllyBoard.CellList[i, j + 3].cellHasShip == false)
                        {
                            AllyBoard.shipList.Add(new Battleship(AllyBoard.CellList[i, j], AllyBoard.CellList[i, j + 1], AllyBoard.CellList[i, j + 2], AllyBoard.CellList[i, j + 3], direction));
                            AllyBoard.CellList[i, j].cellHasShip = true;
                            AllyBoard.CellList[i, j + 1].cellHasShip = true;
                            AllyBoard.CellList[i, j + 2].cellHasShip = true;
                            AllyBoard.CellList[i, j + 3].cellHasShip = true;
                            pictureBoxBattleship.Visible = false;
                            pictureBoxBattleship.Enabled = false;
                            pictureBoxBattleshipR.Visible = false;
                            pictureBoxBattleshipR.Enabled = false;
                            ChosenShipType = ShipTypes.None;
                            Refresh();
                            BattleshipPlaced = true;
                        }
                        else
                            MessageBox.Show("You cannot place the ship in this cell");
                    }
                    else
                        MessageBox.Show("You cannot place the ship in this cell");
                }
                else if (direction == "vertical")
                {
                    if (i + 3 < 10)
                    {
                        if (AllyBoard.CellList[i + 1, j].cellHasShip == false && AllyBoard.CellList[i + 2, j].cellHasShip == false && AllyBoard.CellList[i + 3, j].cellHasShip == false)
                        {
                            AllyBoard.shipList.Add(new Battleship(AllyBoard.CellList[i, j], AllyBoard.CellList[i + 1, j], AllyBoard.CellList[i + 2, j], AllyBoard.CellList[i + 3, j], direction));
                            AllyBoard.CellList[i, j].cellHasShip = true;
                            AllyBoard.CellList[i + 1, j].cellHasShip = true;
                            AllyBoard.CellList[i + 2, j].cellHasShip = true;
                            AllyBoard.CellList[i + 3, j].cellHasShip = true;
                            ChosenShipType = ShipTypes.None;
                            pictureBoxBattleship.Visible = false;
                            pictureBoxBattleship.Enabled = false;
                            pictureBoxBattleshipR.Visible = false;
                            pictureBoxBattleshipR.Enabled = false;
                            Refresh();
                            BattleshipPlaced = true;
                        }
                        else
                            MessageBox.Show("You cannot place the ship in this cell");
                    }
                    else
                        MessageBox.Show("You cannot place the ship in this cell");
                }
            }
            else if (ChosenShipType == ShipTypes.Carrier)
            {
                if (direction == "horizontal")
                {
                    if (j + 4 < 10)
                    {

                        if (AllyBoard.CellList[i, j + 1].cellHasShip == false && AllyBoard.CellList[i, j + 2].cellHasShip == false && AllyBoard.CellList[i, j + 3].cellHasShip == false && AllyBoard.CellList[i, j + 4].cellHasShip == false)
                        {
                            AllyBoard.shipList.Add(new Carrier(AllyBoard.CellList[i, j], AllyBoard.CellList[i, j + 1], AllyBoard.CellList[i, j + 2], AllyBoard.CellList[i, j + 3], AllyBoard.CellList[i, j + 4], direction));
                            AllyBoard.CellList[i, j].cellHasShip = true;
                            AllyBoard.CellList[i, j + 1].cellHasShip = true;
                            AllyBoard.CellList[i, j + 2].cellHasShip = true;
                            AllyBoard.CellList[i, j + 3].cellHasShip = true;
                            AllyBoard.CellList[i, j + 4].cellHasShip = true;
                            pictureBoxCarrier.Visible = false;
                            pictureBoxCarrier.Enabled = false;
                            pictureBoxCarrierR.Visible = false;
                            pictureBoxCarrierR.Enabled = false;
                            ChosenShipType = ShipTypes.None;
                            Refresh();
                            CarrierPlaced = true;
                        }
                        else
                            MessageBox.Show("You cannot place the ship in this cell");
                    }
                    else
                        MessageBox.Show("You cannot place the ship in this cell");
                }
                else if (direction == "vertical")
                {
                    if (i + 4 < 10)
                    {
                        if (AllyBoard.CellList[i + 1, j].cellHasShip == false && AllyBoard.CellList[i + 2, j].cellHasShip == false && AllyBoard.CellList[i + 3, j].cellHasShip == false && AllyBoard.CellList[i + 4, j].cellHasShip == false)
                        {
                            AllyBoard.shipList.Add(new Carrier(AllyBoard.CellList[i, j], AllyBoard.CellList[i + 1, j], AllyBoard.CellList[i + 2, j], AllyBoard.CellList[i + 3, j], AllyBoard.CellList[i + 4, j], direction));
                            AllyBoard.CellList[i, j].cellHasShip = true;
                            AllyBoard.CellList[i + 1, j].cellHasShip = true;
                            AllyBoard.CellList[i + 2, j].cellHasShip = true;
                            AllyBoard.CellList[i + 3, j].cellHasShip = true;
                            AllyBoard.CellList[i + 4, j].cellHasShip = true;
                            ChosenShipType = ShipTypes.None;
                            pictureBoxCarrier.Visible = false;
                            pictureBoxCarrier.Enabled = false;
                            pictureBoxCarrierR.Visible = false;
                            pictureBoxCarrierR.Enabled = false;
                            Refresh();
                            CarrierPlaced = true;
                        }
                        else
                            MessageBox.Show("You cannot place the ship in this cell");
                    }
                    else
                        MessageBox.Show("You cannot place the ship in this cell");
                }
            }
            
        }
        private bool CheckHit(Point target)
        {
            //first it finds the cell
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (target.X > AllyBoard.CellList[i, j].Position.X && target.X < AllyBoard.CellList[i, j].Position.X + Cell.CellSize)
                    {
                        if (target.Y > AllyBoard.CellList[i, j].Position.Y && target.Y < AllyBoard.CellList[i, j].Position.Y + Cell.CellSize)
                        {
                            //then it checks if there is a ship at cell
                            if (AllyBoard.CellList[i, j].cellHasShip == true)
                            {
                                AllyBoard.CellList[i, j].cellImage = Properties.Resources.Hit;
                                AllyBoard.CellList[i, j].isHit = true;
                                Refresh();
                                return true;
                            }
                            else
                                return false;
                        }
                    }
                }
            }
            return false;
        }
        private bool CheckEndGame()
        {
            foreach (Ship AllyShip in AllyBoard.shipList)
            {
                foreach (Cell shipPart in AllyShip.shipParts)
                {
                    if (shipPart.isHit==false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void EnemyShipGotHit()
        {
            //first it finds the cell
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (LastShotCoordinates.X > EnemyBoard.CellList[i, j].Position.X && LastShotCoordinates.X < EnemyBoard.CellList[i, j].Position.X + Cell.CellSize)
                    {
                        if (LastShotCoordinates.Y > EnemyBoard.CellList[i, j].Position.Y && LastShotCoordinates.Y < EnemyBoard.CellList[i, j].Position.Y + Cell.CellSize)
                        {
                            EnemyBoard.CellList[i, j].cellImage = Properties.Resources.Hit;
                            EnemyBoard.CellList[i, j].isHit = true;
                            Refresh();
                        }
                    }
                }
            }
        }
        private void ShotMissed()
        {
            //first it finds the cell
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (LastShotCoordinates.X > EnemyBoard.CellList[i, j].Position.X && LastShotCoordinates.X < EnemyBoard.CellList[i, j].Position.X + Cell.CellSize)
                    {
                        if (LastShotCoordinates.Y > EnemyBoard.CellList[i, j].Position.Y && LastShotCoordinates.Y < EnemyBoard.CellList[i, j].Position.Y + Cell.CellSize)
                        {
                            EnemyBoard.CellList[i, j].cellImage = Properties.Resources.Miss;
                            Refresh();
                        }
                    }
                }
            }
        }
        private void EnterChat()
        {
           ChatProxy.RegisterChatRoom(playername);
        }
        #endregion
        //EVENT HANDLERS
        #region
        private void panelAlly_MouseClick(object sender, MouseEventArgs e)
        {
            if (currentGameState == GameStates.AddingShips && ChosenShipType != ShipTypes.None)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (e.X > AllyBoard.CellList[i, j].Position.X && e.X < AllyBoard.CellList[i, j].Position.X + Cell.CellSize)
                        {
                            if (e.Y > AllyBoard.CellList[i, j].Position.Y && e.Y < AllyBoard.CellList[i, j].Position.Y + Cell.CellSize)
                            {
                                if (AllyBoard.CellList[i, j].cellHasShip == false && e.Button == MouseButtons.Left)
                                    AddShip(i,j);
                                else
                                    MessageBox.Show("You cannot place the ship in this cell.");
                            }
                        }
                    }
                }
            }
            
            else if (currentGameState == GameStates.AddingShips && ChosenShipType == ShipTypes.None)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (e.X > AllyBoard.CellList[i, j].Position.X && e.X < AllyBoard.CellList[i, j].Position.X + Cell.CellSize)
                        {
                            if (e.Y > AllyBoard.CellList[i, j].Position.Y && e.Y < AllyBoard.CellList[i, j].Position.Y + Cell.CellSize)
                            {
                                if (AllyBoard.CellList[i, j].cellHasShip == true && e.Button == MouseButtons.Right)
                                {
                                    foreach (Ship myship in AllyBoard.shipList)
                                    {
                                        if (myship.shipParts.Contains(AllyBoard.CellList[i, j]) && myship.TypeOfShip == ShipTypes.SmallShip)
                                        {
                                            if (PBdirection == "h")
                                            {
                                                pictureBoxSmallShip.Visible = true;
                                                pictureBoxSmallShip.Enabled = true;
                                                pictureBoxSmallShip.BorderStyle = BorderStyle.None;
                                            }
                                            else if (PBdirection == "v")
                                            {
                                                pictureBoxSmallShipR.Visible = true;
                                                pictureBoxSmallShipR.Enabled = true;
                                                pictureBoxSmallShipR.BorderStyle = BorderStyle.None;
                                            }
                                            SmallshipPlaced = false;
                                        }
                                        else if (myship.shipParts.Contains(AllyBoard.CellList[i, j]) && myship.TypeOfShip == ShipTypes.TinyShip)
                                        {
                                            if (PBdirection == "h")
                                            {
                                                pictureBoxTinyShip.Visible = true;
                                                pictureBoxTinyShip.Enabled = true;
                                                pictureBoxTinyShip.BorderStyle = BorderStyle.None;
                                            }
                                            else if (PBdirection == "v")
                                            {
                                                pictureBoxTinyShipR.Visible = true;
                                                pictureBoxTinyShipR.Enabled = true;
                                                pictureBoxTinyShipR.BorderStyle = BorderStyle.None;
                                            }
                                            TinyshipPlaced = false;
                                        }
                                        else if (myship.shipParts.Contains(AllyBoard.CellList[i, j]) && myship.TypeOfShip == ShipTypes.Destroyer)
                                        {
                                            if (PBdirection == "h")
                                            {
                                                pictureBoxDestroyer.Visible = true;
                                                pictureBoxDestroyer.Enabled = true;
                                                pictureBoxDestroyer.BorderStyle = BorderStyle.None;
                                            }
                                            else if (PBdirection == "v")
                                            {
                                                pictureBoxDestroyerR.Visible = true;
                                                pictureBoxDestroyerR.Enabled = true;
                                                pictureBoxDestroyerR.BorderStyle = BorderStyle.None;
                                            }
                                            DestroyerPlaced = false;
                                        }
                                        else if (myship.shipParts.Contains(AllyBoard.CellList[i, j]) && myship.TypeOfShip == ShipTypes.Battleship)
                                        {
                                            if (PBdirection == "h")
                                            {
                                                pictureBoxBattleship.Visible = true;
                                                pictureBoxBattleship.Enabled = true;
                                                pictureBoxBattleship.BorderStyle = BorderStyle.None;
                                            }
                                            else if (PBdirection == "v")
                                            {
                                                pictureBoxBattleshipR.Visible = true;
                                                pictureBoxBattleshipR.Enabled = true;
                                                pictureBoxBattleshipR.BorderStyle = BorderStyle.None;
                                            }
                                            BattleshipPlaced = false;
                                        }
                                        else if (myship.shipParts.Contains(AllyBoard.CellList[i, j]) && myship.TypeOfShip == ShipTypes.Carrier)
                                        {
                                            if (PBdirection == "h")
                                            {
                                                pictureBoxCarrier.Visible = true;
                                                pictureBoxCarrier.Enabled = true;
                                                pictureBoxCarrier.BorderStyle = BorderStyle.None;
                                            }
                                            else if (PBdirection == "v")
                                            {
                                                pictureBoxCarrierR.Visible = true;
                                                pictureBoxCarrierR.Enabled = true;
                                                pictureBoxCarrierR.BorderStyle = BorderStyle.None;
                                            }
                                            CarrierPlaced = false;
                                        }
                                    }
                                    AllyBoard.DeleteShip(i, j);
                                    Refresh();
                                }
                            }
                        }
                    }
                }
            }
        }
        private void panelEnemy_MouseClick(object sender, MouseEventArgs e)
        {
            if (currentGameState == GameStates.YourTurn)
            {
                BattleshipProxy.Shoot(new Point(e.X, e.Y));
                LastShotCoordinates = new Point(e.X, e.Y);
                currentGameState = GameStates.EnemyTurn;
            }
            else
            {
                MessageBox.Show("It's not your turn! Enemy will shoot.");
            }
        }
        private void pictureBoxSmallShip_MouseDown(object sender, MouseEventArgs e)
        {
            this.ChosenShipType = ShipTypes.SmallShip;
            DoDragDrop(pictureBoxSmallShip, DragDropEffects.Move);
            pictureBoxSmallShip.BorderStyle = BorderStyle.Fixed3D;
            direction = "horizontal";
            //panelAlly.Cursor = new Cursor(Properties.Resources.smallship.GetHicon());
        }
        private void pictureBoxSmallShipR_MouseDown(object sender, MouseEventArgs e)
        {
            this.ChosenShipType = ShipTypes.SmallShip;
            DoDragDrop(pictureBoxSmallShipR, DragDropEffects.Move);
            pictureBoxSmallShipR.BorderStyle = BorderStyle.Fixed3D;
            direction = "vertical";
        }
        private void pictureBoxTinyShip_MouseDown(object sender, MouseEventArgs e)
        {
            this.ChosenShipType = ShipTypes.TinyShip;
            DoDragDrop(pictureBoxTinyShip, DragDropEffects.Move);
            pictureBoxTinyShip.BorderStyle = BorderStyle.Fixed3D;
            direction = "horizontal";
        }
        private void pictureBoxTinyShipR_MouseDown(object sender, MouseEventArgs e)
        {
            this.ChosenShipType = ShipTypes.TinyShip;
            DoDragDrop(pictureBoxTinyShipR, DragDropEffects.Move);
            pictureBoxTinyShipR.BorderStyle = BorderStyle.Fixed3D;
            direction = "vertical";
        }
        private void pictureBoxDestroyer_MouseDown(object sender, MouseEventArgs e)
        {
            this.ChosenShipType = ShipTypes.Destroyer;
            DoDragDrop(pictureBoxDestroyer, DragDropEffects.Move);
            pictureBoxDestroyer.BorderStyle = BorderStyle.Fixed3D;
            direction = "horizontal";
        }
        private void pictureBoxDestroyerR_MouseDown(object sender, MouseEventArgs e)
        {
            this.ChosenShipType = ShipTypes.Destroyer;
            DoDragDrop(pictureBoxDestroyerR, DragDropEffects.Move);
            pictureBoxDestroyerR.BorderStyle = BorderStyle.Fixed3D;
            direction = "vertical";
        }
        private void pictureBoxBattleship_MouseDown(object sender, MouseEventArgs e)
        {
            this.ChosenShipType = ShipTypes.Battleship;
            DoDragDrop(pictureBoxBattleship, DragDropEffects.Move);
            pictureBoxBattleship.BorderStyle = BorderStyle.Fixed3D;
            direction = "horizontal";
        }
        private void pictureBoxBattleshipR_MouseDown(object sender, MouseEventArgs e)
        {
            
            this.ChosenShipType = ShipTypes.Battleship;
            DoDragDrop(pictureBoxBattleshipR, DragDropEffects.Move);
            pictureBoxBattleshipR.BorderStyle = BorderStyle.Fixed3D;
            direction = "vertical";
        }
        private void pictureBoxCarrier_MouseDown(object sender, MouseEventArgs e)
        {

            this.ChosenShipType = ShipTypes.Carrier;
            DoDragDrop(pictureBoxCarrier, DragDropEffects.Move);
            pictureBoxCarrier.BorderStyle = BorderStyle.Fixed3D;
            direction = "horizontal";
        }
        private void pictureBoxCarrierR_MouseDown(object sender, MouseEventArgs e)
        {

            this.ChosenShipType = ShipTypes.Carrier;
            DoDragDrop(pictureBoxCarrierR, DragDropEffects.Move);
            pictureBoxCarrierR.BorderStyle = BorderStyle.Fixed3D;
            direction = "vertical";
        }
        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (PBdirection == "h")
            {
                if (SmallshipPlaced == false)
                {
                    pictureBoxSmallShip.Visible = false;
                    pictureBoxSmallShip.Enabled = false;
                    pictureBoxSmallShip.BorderStyle = BorderStyle.None;
                    pictureBoxSmallShipR.Visible = true;
                    pictureBoxSmallShipR.Enabled = true;
                    pictureBoxSmallShipR.BorderStyle = BorderStyle.None;
                }
                if (TinyshipPlaced == false)
                {
                    pictureBoxTinyShip.Visible = false;
                    pictureBoxTinyShip.Enabled = false;
                    pictureBoxTinyShip.BorderStyle = BorderStyle.None;
                    pictureBoxTinyShipR.Visible = true;
                    pictureBoxTinyShipR.Enabled = true;
                    pictureBoxTinyShipR.BorderStyle = BorderStyle.None;
                }
                if (DestroyerPlaced == false)
                {
                    pictureBoxDestroyer.Visible = false;
                    pictureBoxDestroyer.Enabled = false;
                    pictureBoxDestroyer.BorderStyle = BorderStyle.None;
                    pictureBoxDestroyerR.Visible = true;
                    pictureBoxDestroyerR.Enabled = true;
                    pictureBoxDestroyerR.BorderStyle = BorderStyle.None;
                }
                if (BattleshipPlaced == false)
                {
                    pictureBoxBattleship.Visible = false;
                    pictureBoxBattleship.Enabled = false;
                    pictureBoxBattleship.BorderStyle = BorderStyle.None;
                    pictureBoxBattleshipR.Visible = true;
                    pictureBoxBattleshipR.Enabled = true;
                    pictureBoxBattleshipR.BorderStyle = BorderStyle.None;
                }
                if (CarrierPlaced == false)
                {
                    pictureBoxCarrier.Visible = false;
                    pictureBoxCarrier.Enabled = false;
                    pictureBoxCarrier.BorderStyle = BorderStyle.None;
                    pictureBoxCarrierR.Visible = true;
                    pictureBoxCarrierR.Enabled = true;
                    pictureBoxCarrierR.BorderStyle = BorderStyle.None;
                }
                PBdirection = "v";
            }
            else if (PBdirection == "v")
            {
                if (SmallshipPlaced == false)
                {
                    pictureBoxSmallShip.Visible = true;
                    pictureBoxSmallShip.Enabled = true;
                    pictureBoxSmallShip.BorderStyle = BorderStyle.None;
                    pictureBoxSmallShipR.Visible = false;
                    pictureBoxSmallShipR.Enabled = false;
                    pictureBoxSmallShipR.BorderStyle = BorderStyle.None;
                }
                if (TinyshipPlaced == false)
                {
                    pictureBoxTinyShip.Visible = true;
                    pictureBoxTinyShip.Enabled = true;
                    pictureBoxTinyShip.BorderStyle = BorderStyle.None;
                    pictureBoxTinyShipR.Visible = false;
                    pictureBoxTinyShipR.Enabled = false;
                    pictureBoxTinyShipR.BorderStyle = BorderStyle.None;
                }
                if (DestroyerPlaced == false)
                {
                    pictureBoxDestroyer.Visible = true;
                    pictureBoxDestroyer.Enabled = true;
                    pictureBoxDestroyer.BorderStyle = BorderStyle.None;
                    pictureBoxDestroyerR.Visible = false;
                    pictureBoxDestroyerR.Enabled = false;
                    pictureBoxDestroyerR.BorderStyle = BorderStyle.None;
                }
                if (BattleshipPlaced == false)
                {
                    pictureBoxBattleship.Visible = true;
                    pictureBoxBattleship.Enabled = true;
                    pictureBoxBattleship.BorderStyle = BorderStyle.None;
                    pictureBoxBattleshipR.Visible = false;
                    pictureBoxBattleshipR.Enabled = false;
                    pictureBoxBattleshipR.BorderStyle = BorderStyle.None;
                }
                if (CarrierPlaced == false)
                {
                    pictureBoxCarrier.Visible = true;
                    pictureBoxCarrier.Enabled = true;
                    pictureBoxCarrier.BorderStyle = BorderStyle.None;
                    pictureBoxCarrierR.Visible = false;
                    pictureBoxCarrierR.Enabled = false;
                    pictureBoxCarrierR.BorderStyle = BorderStyle.None;
                }
                PBdirection = "h";
            }
        }
        private void btnReady_Click(object sender, EventArgs e)
        {
            if (pictureBoxSmallShip.Enabled == false && pictureBoxBattleship.Enabled == false && pictureBoxCarrier.Enabled == false && pictureBoxTinyShip.Enabled == false && pictureBoxDestroyer.Enabled == false && pictureBoxSmallShipR.Enabled == false && pictureBoxBattleshipR.Enabled == false && pictureBoxCarrierR.Enabled == false && pictureBoxTinyShipR.Enabled == false && pictureBoxDestroyerR.Enabled == false)
            {
                BattleshipProxy.ReadyForBattle();
                label_YourState.Text = "Waiting enemy to place ships";
                currentGameState = GameStates.WaitingOtherPlayerToAddShips;
                btnReady.Enabled = false;
                btnReady.Visible = false;
                btnRotate.Enabled = false;
                btnRotate.Visible = false;
            }
            else
                MessageBox.Show("all ship must be placed before declaring readiness");
        }
        List<string> availablePlayers = new List<string>();
        private void buttonFindPlayers_Click(object sender, EventArgs e)
        {
            this.playername = textBoxName.Text;
            LobbyProxy.logPlayer(textBoxName.Text);
            
        }
        private void btnSendText_Click(object sender, EventArgs e)
        {
            string current=richTextBoxChatWindow.Text;
            current +="\n"+playername+" says:"+ textBoxSendText.Text;
            richTextBoxChatWindow.Text = current;
            ChatProxy.SendMessage(textBoxSendText.Text);
            textBoxSendText.Text = "";
            textBoxSendText.Focus();
        }
        private void richTextBoxChatWindow_TextChanged(object sender, EventArgs e)
        {//scrolls to bottom whenever something is written
            richTextBoxChatWindow.SelectionStart = richTextBoxChatWindow.Text.Length; //Set the current caret position at the end
            richTextBoxChatWindow.ScrollToCaret();
        }
        private void panelAlly_Paint(object sender, PaintEventArgs e)
        {
            foreach (Cell mycell in AllyBoard.CellList)
            {
                e.Graphics.DrawRectangle(Pens.Black, mycell.Position.X, mycell.Position.Y, Cell.CellSize, Cell.CellSize);
                if (mycell.cellImage != null)
                {
                    e.Graphics.DrawImage(mycell.cellImage, mycell.Position);
                }
            }
        }
        private void panelEnemy_Paint(object sender, PaintEventArgs e)
        {
            foreach (Cell mycell in EnemyBoard.CellList)
            {
                e.Graphics.DrawRectangle(Pens.Black, mycell.Position.X, mycell.Position.Y, Cell.CellSize, Cell.CellSize);
                if (mycell.cellImage != null)
                {
                    e.Graphics.DrawImage(mycell.cellImage, mycell.Position);
                }
            }
        }
        //lobby
        private void RandomButton_Click(object sender, EventArgs e)
        {

            LobbyProxy.RandomGame(this.playername);

            //label_YourState.Visible = true;Waiting for players label
            // buttonFindPlayers.Visible = false;
            label3.Text = "You are currently logged in as: " + textBoxName.Text;
            textBoxName.Visible = false;
        }
        private void InviteButton_Click(object sender, EventArgs e)
        {
            string selectedPlayer;
            selectedPlayer = (string)listBox1.SelectedItem;
            if (selectedPlayer == this.playername) { MessageBox.Show("You cannot invite yourself!"); }
            else { LobbyProxy.invitePlayer(this.playername, selectedPlayer); }

        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            LobbyProxy.logOut(this.playername);
            btnLogout.Visible = false;
            buttonLoginPlayer.Enabled = true;
            label3.Text = "Enter your Nickname:";
            invitePlayer.Enabled = false;
            btnSend.Enabled = false;
            randomGameButton.Enabled = false;
            textBoxName.Text = "";
            textBoxName.Visible = true;
        }
        private void frmBattleship_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.playername != "")
            {
                LobbyProxy.logOut(this.playername);
            }
        }
        private void frmBattleship_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.playername != "")
            {
                LobbyProxy.logOut(this.playername);
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            string current = richTextBoxLobby.Text;
            current += "\n" + playername + " says:" + txtToSend.Text;
            richTextBoxLobby.Text = current;
            ChatProxy.SendLobbyMessage(txtToSend.Text);
            txtToSend.Text = "";
            txtToSend.Focus();
        }
        private void richTextBoxLobby_TextChanged(object sender, EventArgs e)
        {
            richTextBoxLobby.SelectionStart = richTextBoxChatWindow.Text.Length; //Set the current caret position at the end
            richTextBoxLobby.ScrollToCaret();
        }
        #endregion
        //CALLBACK CLASS FOR BATTLESHIP
        public class BattleshipCallback : MyBattleshipService.IBattleshipCallback
        {
            private frmBattleship myform;
            public BattleshipCallback(frmBattleship Myform)
            {
                this.myform = Myform;
            }

            public void PlaceShips()
            {
                myform.lobbyPanel.Hide();
                myform.EnterChat();
                myform.richTextBoxChatWindow.Text= "Welcome to private chat room";
                myform.currentGameState = GameStates.AddingShips;
                myform.RefreshGameState();
            }
            public void EnemyReady()
            {
                myform.label_EnemyState.Text = "Your enemy is ready for battle!";
            }
            public void StartGame(int StartingPosition)
            {
                if (StartingPosition == 0)
                {
                    MessageBox.Show("YOUR TURN!");
                    myform.currentGameState = GameStates.YourTurn;
                    myform.RefreshGameState();
                }
                else
                {
                    myform.currentGameState = GameStates.EnemyTurn;
                    myform.RefreshGameState();
                }
            }
            public void ReceiveHit(Point target)
            {
                if (myform.CheckHit(target) == true)
                {
                    if (myform.CheckEndGame() == true)
                    {
                        myform.BattleshipProxy.GameEnded();
                        myform.label_YourState.Text = "You lost...";
                        myform.label_EnemyState.Text = "Enemy is celebrating";
                        myform.currentGameState = GameStates.EndGame;
                        MessageBox.Show("You lost...");
                        myform.lobbyPanel.Show();
                        myform.LobbyProxy.logPlayer(myform.playername);
                       myform.AllyBoard = new GameBoard();
                       myform.EnemyBoard = new GameBoard();
                       myform.panelAlly.Enabled = false;
                       myform.panelEnemy.Enabled = false;
                       myform.panelAlly.Visible = false;
                       myform.panelEnemy.Visible = false;
                       myform.label1.Visible = false;
                       myform.label2.Visible = false;
                       myform.label_EnemyState.Visible = false;
                       myform.label_YourState.Visible = false;
                       myform.btnRotate.Visible = false;
                       myform.btnReady.Visible = false;
                       myform.pictureBoxSmallShip.Visible = false;
                       myform.pictureBoxSmallShipR.Visible = false;
                       myform.pictureBoxTinyShip.Visible = false;
                       myform.pictureBoxTinyShipR.Visible = false;
                       myform.pictureBoxDestroyer.Visible = false;
                       myform.pictureBoxDestroyerR.Visible = false;
                       myform.pictureBoxBattleship.Visible = false;
                       myform.pictureBoxBattleshipR.Visible = false;
                       myform.pictureBoxCarrier.Visible = false;
                       myform.pictureBoxCarrierR.Visible = false;
                       myform.btnSendText.Visible = false;

                       myform.textBoxSendText.Visible = false;
                       myform.richTextBoxChatWindow.Visible = false;
           
                        return;
                    }
                    myform.BattleshipProxy.SendHitResult(true);
                    myform.currentGameState = GameStates.EnemyTurn;
                    myform.RefreshGameState();
                }
                else
                {
                    myform.BattleshipProxy.SendHitResult(false);
                    myform.currentGameState = GameStates.YourTurn;
                    myform.RefreshGameState();
                }
            }
            public void ReceiveHitResult(bool result)
            {
                if (result == true)
                {
                    myform.EnemyShipGotHit();
                    MessageBox.Show("You hit the enemy ship! You can shoot again.");
                    myform.currentGameState = GameStates.YourTurn;
                    myform.RefreshGameState();
                }
                else
                {
                    myform.ShotMissed();
                    MessageBox.Show("You missed the target, now its enemy's turn");
                    myform.currentGameState = GameStates.EnemyTurn;
                    myform.RefreshGameState();
                }
            }
            public void ReceiveGameEnd()
            {
                myform.EnemyShipGotHit();
                myform.currentGameState = GameStates.EndGame;
                myform.RefreshGameState();
                myform.label_YourState.Text = "CONGRATULATIONS!You won!";
                myform.label_EnemyState.Text = "Enemy is very unhappy";
                MessageBox.Show("You won the battle!");
                myform.lobbyPanel.Show();
                myform.AllyBoard = new GameBoard();
                myform.EnemyBoard = new GameBoard();
                myform.panelAlly.Enabled = false;
                myform.panelEnemy.Enabled = false;
                myform.panelAlly.Visible = false;
                myform.panelEnemy.Visible = false;
                myform.label1.Visible = false;
                myform.label2.Visible = false;
                myform.label_EnemyState.Visible = false;
                myform.label_YourState.Visible = false;
                myform.btnRotate.Visible = false;
                myform.btnReady.Visible = false;
                myform.pictureBoxSmallShip.Visible = false;
                myform.pictureBoxSmallShipR.Visible = false;
                myform.pictureBoxTinyShip.Visible = false;
                myform.pictureBoxTinyShipR.Visible = false;
                myform.pictureBoxDestroyer.Visible = false;
                myform.pictureBoxDestroyerR.Visible = false;
                myform.pictureBoxBattleship.Visible = false;
                myform.pictureBoxBattleshipR.Visible = false;
                myform.pictureBoxCarrier.Visible = false;
                myform.pictureBoxCarrierR.Visible = false;
                myform.btnSendText.Visible = false;

                myform.textBoxSendText.Visible = false;
                myform.richTextBoxChatWindow.Visible = false;
           
                myform.LobbyProxy.logPlayer(myform.playername);


            }
        }
        //CALLBACK CLASS FOR LOBBY
        public class LobbyCallBack : MyLobbyService.ILobbyCallback
        {
            private frmBattleship myform;
            public LobbyCallBack(frmBattleship Myform)
            {
                this.myform = Myform;
            }

            public void notifyPlayerInvitationResult(bool acceptOrDecline)
            {
                if (acceptOrDecline == false)
                {
                    MessageBox.Show("Game has been declined");
                }
                if (acceptOrDecline == true)
                {
                    MessageBox.Show("Game has been accepted and it is starting shortly");
                }
            }
            public void notifyPlayerInvitation(string invitedFrom)
            {
                var message = invitedFrom + " Has challenged you! Accept or decline the match.";
                var title = "Incoming match!";
                var result = MessageBox.Show(
                    message,                  // the message to show
                    title,                    // the title for the dialog box
                    MessageBoxButtons.YesNo,  // show two buttons: Yes and No
                    MessageBoxIcon.Question); // show a question mark icon

                // the following can be handled as if/else statements as well
                switch (result)
                {
                    case DialogResult.Yes:   // Yes button pressed
                        myform.LobbyProxy.acceptInvitationInvokeGame(invitedFrom, myform.playername);
                        break;
                    case DialogResult.No:    // No button pressed
                        myform.LobbyProxy.declineInvitation(invitedFrom);

                        break;
                    default:                 // Neither Yes nor No pressed (just in case)
                        MessageBox.Show("What did you press?");
                        break;
                }
            }
            public void receiveLoginResult(bool result)
            {

                if (result == false)
                {
                    MessageBox.Show("Your nickname is already in use");
                }
                else
                {
                    //label_YourState.Visible = true;Waiting for players label
                    // buttonFindPlayers.Visible = false;
                    myform.label3.Text = "You are currently logged in as: " + myform.textBoxName.Text;
                    myform.textBoxName.Visible = false;
                    myform.buttonLoginPlayer.Enabled = false;
                    myform.btnLogout.Visible = true;
                    myform.randomGameButton.Enabled = true;
                    myform.invitePlayer.Enabled = true;
                    myform.BattleshipProxy.RegisterBattleshipClient(myform.playername);
                    myform.ChatProxy.RegisterChatRoom(myform.playername);
                    myform.btnSend.Enabled = true;
                }
            }
            public void receiveAvailablePlayers(List<string> AvailablePlayers)
            {
                int i = 0;
                myform.listBox1.Items.Clear();
                while (i < AvailablePlayers.Count)
                {
                    myform.listBox1.Items.Add(AvailablePlayers[i]);
                    i++;
                }

            }
        }
        //CALLBACK CLASS FOR CHAT
        public class ChatCallback : MyChatService.IChatCallback
        {
            private frmBattleship myform;
            public ChatCallback(frmBattleship Myform)
            {
                this.myform = Myform;
            }
            public void ReceiveMessage(string message)
            {
                string current = myform.richTextBoxChatWindow.Text;
                current += "\n" + message;
                myform.richTextBoxChatWindow.Text = current;
            }
            public void ReceiveLobbyMessage(string message)
            {
                string current = myform.richTextBoxLobby.Text;
                current += "\n" + message;
                myform.richTextBoxLobby.Text = current;
            }
        }


        }



    }

