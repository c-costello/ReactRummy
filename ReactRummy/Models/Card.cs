using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactRummy.Models
{
    public class Card
    {
        //Composite Key Suit and Value and GameID
        public SuitType Suit { get; set; }
        public ValType Value { get; set; }
        public int GameID { get; set; }
        public int LocationID { get; set; }
        //Enums
        public enum SuitType { Spades, Clubs, Hearts, Diamonds}
        public enum ValType { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King}
    }
}
