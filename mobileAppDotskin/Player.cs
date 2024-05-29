using System;
using System.Collections.Generic;
using System.Text;

namespace mobileAppDotskin
{
    internal class Player
    {

        public string sym;
        public bool isBot;
        public Player(string Sym, bool IsBoot) { 


            sym= Sym;
            isBot= IsBoot;    
        }
    }
}
