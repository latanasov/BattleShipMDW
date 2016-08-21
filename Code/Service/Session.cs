using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class Session
    {
        private Player p1;
        private Player p2;

        public Session(Player p1, Player p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public Player P1
        {
            get { return p1; }
            set { p1 = value; }
        }
        public Player P2
        {
            get { return p2; }
            set { p2 = value; }
        }
    }
}
