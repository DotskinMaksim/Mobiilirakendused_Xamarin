using System;
namespace XamarinApps.Classes
{
	public class Player
	{
        public string sym { get; set; }
        public bool isBot { get; set; }

        public Player(string symbol, bool isBot)
        {
            sym = symbol;
            this.isBot = isBot;
        }
    }
}

