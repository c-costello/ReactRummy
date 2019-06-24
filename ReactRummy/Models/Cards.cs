using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactRummy.Models
{
    public class Card
    {
        //Composite Key
        public SuitType Suit { get; set; }
        public ValType Value { get; set; }
        public LocationType Location { get; set; }
        //Constructor
        public Card (SuitType suit, ValType val, LocationType location)
        {
            Suit = suit;
            Value = val;
            Location = location;
        }
        public enum SuitType { Spades, Clubs, Hearts, Diamonds}
        public enum ValType { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King}
        public enum LocationType { Start, Draw, Discard, PlayerOneHand, PlayerOneLayDown, PlayerTwoHand, PlayerTwoLayDown}
    }
}
