using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class Destroyer : Ship
    {
        public Destroyer(Cell firstCell, Cell secondCell, Cell thirdCell, string direction)
        {
            this.TypeOfShip = ShipTypes.Destroyer;
            this.Size = 3;
            this.Direction = direction;
            this.shipParts = new Cell[3];
            this.shipParts[0] = firstCell;
            this.shipParts[1] = secondCell;
            this.shipParts[2] = thirdCell;
            if (this.Direction == "horizontal")
            {
                firstCell.cellImage = Properties.Resources.destroyerPart1;
                secondCell.cellImage = Properties.Resources.destroyerPart2;
                thirdCell.cellImage = Properties.Resources.destroyerPart3;
            }
            else if (this.Direction == "vertical")
            {
                firstCell.cellImage = Properties.Resources.destroyerPart1R;
                secondCell.cellImage = Properties.Resources.destroyerPart2R;
                thirdCell.cellImage = Properties.Resources.destroyerPart3R;
            }
        }
    }
}
