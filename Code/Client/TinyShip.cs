using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class TinyShip : Ship
    {
        public TinyShip(Cell firstCell, string direction)
        {
            this.TypeOfShip = ShipTypes.TinyShip;
            this.Size = 1;
            this.Direction = direction;
            this.shipParts = new Cell[1];
            this.shipParts[0] = firstCell;
            if (this.Direction == "horizontal")
            {
                firstCell.cellImage = Properties.Resources.tinyship;
            }
            else if (this.Direction == "vertical")
            {
                firstCell.cellImage = Properties.Resources.tinyshipR;
            }
        }
    }
}
