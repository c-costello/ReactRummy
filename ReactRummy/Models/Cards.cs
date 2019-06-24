﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactRummy.Models
{
    public class Card
    {
        //Composite Key Suit and Value
        public SuitType Suit { get; set; }
        public ValType Value { get; set; }
        public Location Location { get; set; }
        //Constructor
        public Card (SuitType suit, ValType val)
        {
            Suit = suit;
            Value = val;
        }
        //Enums
        public enum SuitType { Spades, Clubs, Hearts, Diamonds}
        public enum ValType { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King}
    }
}