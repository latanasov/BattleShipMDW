using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace Client
{
    class Cell
    {
        public static int CellSize = 50;
        private Point position;
        private Image image;
        private bool CellHasShip = false;
        private bool IsHit = false;

        


        public Cell(Point position)
        {
            this.position = position;
        }

//Getters, Setters
        public Image cellImage
        {
            get { return image; }
            set { image = value; }
        }
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }
        public bool cellHasShip
        {
            get { return CellHasShip; }
            set { CellHasShip = value; }
        }
        public bool isHit
        {
            get { return IsHit; }
            set { IsHit = value; }
        }


    }
}
