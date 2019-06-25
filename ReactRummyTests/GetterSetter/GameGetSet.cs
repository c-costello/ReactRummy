using System;
using Xunit;
using ReactRummy.Models;

namespace ReactRummyTests
{
    public class GameGetSet
    {
        public Game game = new Game()
        {
            ID = 1,
            Status = Game.StatusType.Open,
            Winner = 1,
        };

        [Fact]
        public void CanGetID()
        {
            Assert.Equal(1, game.ID);
        }
        [Fact]
        public void CanGetStatus()
        {
            Assert.Equal(Game.StatusType.Open, game.Status);
        }
        [Fact]
        public void CanGetWinner()
        {
            Assert.Equal(1, game.Winner);
        }
        [Fact]
        public void CanSetID()
        {
            game.ID = 2;
            Assert.Equal(2, game.ID);
        }
        [Fact]
        public void CanSetStatus()
        {
            game.Status = Game.StatusType.Over;
            Assert.Equal(Game.StatusType.Over, game.Status);
        }
        [Fact]
        public void CanSetWinner()
        {
            game.Winner = 2;
            Assert.Equal(2, game.Winner);
        }
    }
}
