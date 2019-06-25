using System;
using Xunit;
using ReactRummy.Models;

namespace ReactRummyTests.GetterSetter
{
    public class PlayerGetSet
    {
        Player player = new Player()
        {
            ID = 1,
            GameID = 2,
            HandID = 3,
            LaydownID = 4,
            User = "username",
            Score = 100,
        };

        [Fact]
        public void CanGetID()
        {
            Assert.Equal(1, player.ID);
        }
        [Fact]
        public void CanGetGameID()
        {
            Assert.Equal(2, player.GameID);
        }
        [Fact]
        public void CanGetHandID()
        {
            Assert.Equal(3, player.HandID);
        }
        [Fact]
        public void CanGetLayDownID()
        {
            Assert.Equal(4, player.LaydownID);
        }
        [Fact]
        public void CanGetUser()
        {
            Assert.Equal("username", player.User);
        }
        [Fact]
        public void CanGetScore()
        {
            Assert.Equal(100, player.Score);
        }
        [Fact]
        public void CanSetID()
        {
            player.ID = 5;
            Assert.Equal(5, player.ID);
        }
        [Fact]
        public void CanSetGameID()
        {
            player.GameID = 6;
            Assert.Equal(6, player.GameID);
        }
        [Fact]
        public void CanSetHandID()
        {
            player.HandID = 7;
            Assert.Equal(7, player.HandID);
        }
        [Fact]
        public void CanSetLayDownID()
        {
            player.LaydownID = 8;
            Assert.Equal(8, player.LaydownID);
        }
        [Fact]
        public void CanSetUser()
        {
            player.User = "new user";
            Assert.Equal("new user", player.User);
        }
        [Fact]
        public void CanSetScore()
        {
            player.Score = 50;
            Assert.Equal(50, player.Score);
        }


    }
}
