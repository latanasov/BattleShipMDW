using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class Ship
    {
        public int Size;
        public string Direction;
        private ShipTypes typeOfShip;

        public ShipTypes TypeOfShip
        {
            get { return typeOfShip; }
            set { typeOfShip = value; }
        }
        private Cell[] Parts;

        public Cell[] shipParts
        {
            get { return Parts; }
            set { Parts = value; }
        }
    }
}
