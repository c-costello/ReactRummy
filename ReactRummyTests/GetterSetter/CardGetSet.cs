using System;
using Xunit;
using ReactRummy.Models;

namespace ReactRummyTests.GetterSetter
{
    public class CardGetSet
    {
        Card card = new Card()
        {
            Suit = Card.SuitType.Clubs,
            Value = Card.ValType.Ace,
            GameID = 1,
            LocationID = 2,
        };

        [Fact]
        public void CanGetSuit()
        {
            Assert.Equal(Card.SuitType.Clubs, card.Suit);
        }
        [Fact]
        public void CanGetValue()
        {
            Assert.Equal(Card.ValType.Ace, card.Value);
        }
        [Fact]
        public void CanGetGameID()
        {
            Assert.Equal(1, card.GameID);
        }
        [Fact]
        public void CanGetLocationID()
        {
            Assert.Equal(2, card.LocationID);
        }

        [Fact]
        public void CanSetSuit()
        {
            card.Suit = Card.SuitType.Diamonds;
            Assert.Equal(Card.SuitType.Diamonds, card.Suit);
        }
        [Fact]
        public void CanSetValue()
        {
            card.Value = Card.ValType.Queen;
            Assert.Equal(Card.ValType.Queen, card.Value);
        }
        [Fact]
        public void CanSetGameID()
        {
            card.GameID = 3;
            Assert.Equal(3, card.GameID);
        }
        [Fact]
        public void CanSetLocationID()
        {
            card.LocationID = 4;
            Assert.Equal(4, card.LocationID);
        }
    }
}
