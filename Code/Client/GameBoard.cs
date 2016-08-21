using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class GameBoard
    {
        private int BoardSize=10;
        private Cell[,] cellList;
        private List<Ship> Shiplist;
        private frmBattleship mainform;

        public GameBoard()
        {
            shipList = new List<Ship>();
            cellList = new Cell[10,10];
            AddCells();
        }
//FUNCTIONS
        private void AddCells()
        {
            int x = 0, y = 0;

            //ADD CELLS
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    cellList[i, j] = new Cell(new Point(x, y));
                    x += Cell.CellSize;
                }
                y += Cell.CellSize;
                x = 0;
            }
        }
        public void DeleteShip(int i, int j)
        {
            int index=0;

            foreach (Ship myship in shipList)
            {
                if (myship.shipParts.Contains(cellList[i, j]))
                {
                    foreach (Cell mycell in myship.shipParts)
                    {
                        mycell.cellHasShip = false;
                        mycell.cellImage = null;
                    }
                    index = shipList.IndexOf(myship);
                }
                
            }
            shipList.RemoveAt(index);
        }
//GETTERS SETTERS
        internal Cell[,] CellList
        {
            get { return cellList; }
            set { cellList = value; }
        }
        internal List<Ship> shipList
        {
            get { return Shiplist; }
            set { Shiplist = value; }
        }
    }
}
