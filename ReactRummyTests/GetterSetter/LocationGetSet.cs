using System;
using Xunit;
using ReactRummy.Models;

namespace ReactRummyTests.GetterSetter
{
    public class LocationGetSet
    {
        Location location = new Location()
        {
            ID = 1,
            GameID = 2,
            Hand = Location.HandType.Hand,
        };
        [Fact]
        public void CanGetID()
        {
            Assert.Equal(1, location.ID);
        }
        [Fact]
        public void CanGetGameID()
        {
            Assert.Equal(2, location.GameID);
        }
        [Fact]
        public void CanGetHand()
        {
            Assert.Equal(Location.HandType.Hand, location.Hand);
        }
        [Fact]
        public void CanSetID()
        {
            location.ID = 3;
            Assert.Equal(3, location.ID);
        }
        [Fact]
        public void CanSetGameID()
        {
            location.GameID = 4;
            Assert.Equal(4, location.GameID);
        }
        [Fact]
        public void CanSetHand()
        {
            location.Hand = Location.HandType.Discard;
            Assert.Equal(Location.HandType.Discard, location.Hand);
        }

    }
}
