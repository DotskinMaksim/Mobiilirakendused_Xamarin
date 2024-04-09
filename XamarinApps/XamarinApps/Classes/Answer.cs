using System;
namespace XamarinApps.Classes
{
	public class Answer
	{
        public bool res { get; set; }
        public string sym { get; set; }

        public Answer(bool result, string symbol)
        {
            res = result;
            sym = symbol;
        }
    }
}

