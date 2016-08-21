using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class SmallShip:Ship
    {
        public SmallShip(Cell firstCell,Cell secondCell,string direction)
        {
            this.TypeOfShip = ShipTypes.SmallShip;
            this.Size = 2;
            this.Direction = direction;
            this.shipParts = new Cell[2];
            this.shipParts[0] = firstCell;
            this.shipParts[1] = secondCell;
            if (this.Direction == "horizontal")
            {
                firstCell.cellImage = Properties.Resources.smallshipPart1;
                secondCell.cellImage = Properties.Resources.smallshipPart2;
            }
            else if (this.Direction == "vertical")
            {
                firstCell.cellImage = Properties.Resources.smallshipPart1R;
                secondCell.cellImage = Properties.Resources.smallshipPart2R;
            }
        }
    }
}
