using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class Carrier : Ship
    {
        public Carrier(Cell firstCell, Cell secondCell, Cell thirdCell, Cell fourthCell, Cell fifthCell, string direction)
        {
            this.TypeOfShip = ShipTypes.Carrier;
            this.Size = 3;
            this.Direction = direction;
            this.shipParts = new Cell[5];
            this.shipParts[0] = firstCell;
            this.shipParts[1] = secondCell;
            this.shipParts[2] = thirdCell;
            this.shipParts[3] = fourthCell;
            this.shipParts[4] = fifthCell;
            if (this.Direction == "horizontal")
            {
                firstCell.cellImage = Properties.Resources.carrierPart1;
                secondCell.cellImage = Properties.Resources.carrierPart2;
                thirdCell.cellImage = Properties.Resources.carrierPart3;
                fourthCell.cellImage = Properties.Resources.carrierPart4;
                fifthCell.cellImage = Properties.Resources.carrierPart5;
            }
            else if (this.Direction == "vertical")
            {
                firstCell.cellImage = Properties.Resources.carrierPart1R;
                secondCell.cellImage = Properties.Resources.carrierPart2R;
                thirdCell.cellImage = Properties.Resources.carrierPart3R;
                fourthCell.cellImage = Properties.Resources.carrierPart4R;
                fifthCell.cellImage = Properties.Resources.carrierPart5R;
            }
        }
    }
}
