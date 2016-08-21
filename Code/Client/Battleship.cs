using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class Battleship : Ship
    {
        public Battleship(Cell firstCell, Cell secondCell, Cell thirdCell, Cell fourthCell, string direction)
        {
            this.TypeOfShip = ShipTypes.Battleship;
            this.Size = 4;
            this.Direction = direction;
            this.shipParts = new Cell[4];
            this.shipParts[0] = firstCell;
            this.shipParts[1] = secondCell;
            this.shipParts[2] = thirdCell;
            this.shipParts[3] = fourthCell;
            if (this.Direction == "horizontal")
            {
                firstCell.cellImage = Properties.Resources.battleshipPart1;
                secondCell.cellImage = Properties.Resources.battleshipPart2;
                thirdCell.cellImage = Properties.Resources.battleshipPart3;
                fourthCell.cellImage = Properties.Resources.battleshipPart4;
            }
            else if (this.Direction == "vertical")
            {
                firstCell.cellImage = Properties.Resources.battleshipPart1R;
                secondCell.cellImage = Properties.Resources.battleshipPart2R;
                thirdCell.cellImage = Properties.Resources.battleshipPart3R;
                fourthCell.cellImage = Properties.Resources.battleshipPart4R;
            }
        }
    }
}
