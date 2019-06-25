using System;
using Xunit;
using ReactRummy.Models;
using Microsoft.EntityFrameworkCore;
using ReactRummy.Data;
using ReactRummy.Models.Services;

namespace ReactRummyTests.CRUD
{
    public class PlayerCRUD
    {
        [Fact]
        public async void CanCreatePlayer()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("test").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                PlayerService playerService = new PlayerService(context);
                Player player = new Player();
                await playerService.CreatePlayer(player);
                var actual = await context.Players.FirstOrDefaultAsync(p => p.ID == player.ID);
                Assert.Equal(player, actual);
            }
        }
        [Fact]
        public async void CanUpdatePlayer()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("test").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                PlayerService playerService = new PlayerService(context);
                Player player = new Player();
                player.User = "user1";
                await playerService.CreatePlayer(player);
                player.User = "user2";
                await playerService.UpdatePlayer(player);
                var actual = await context.Players.FirstOrDefaultAsync(p => p.ID == player.ID);
                Assert.Equal(player, actual);
            }
        }
        [Fact]
        public async void CanDeletePlayer()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("test").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                PlayerService playerService = new PlayerService(context);
                Player player = new Player();
                await playerService.CreatePlayer(player);
                await playerService.DeletePlayer(player.ID);
                var actual = await context.Players.FirstOrDefaultAsync(p => p.ID == player.ID);
                Assert.Null(actual);
            }
        }
        [Fact]
        public async void CanGetPlayer()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("test").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                PlayerService playerService = new PlayerService(context);
                Player player = new Player();
                await playerService.CreatePlayer(player);
                var expected = await context.Players.FirstOrDefaultAsync(p => p.ID == player.ID);
                var actual = await playerService.GetPlayer(player.ID);
                Assert.Equal(expected, actual);
            }
        }
        [Fact]
        public async void CanGetPlayerByUser()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("test").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                PlayerService playerService = new PlayerService(context);
                Player player = new Player();
                player.User = "uniqueUserName";
                await playerService.CreatePlayer(player);
                var expected = await context.Players.FirstOrDefaultAsync(p => p.User == player.User);
                var actual = await playerService.GetPlayerByUser(player.User);
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public async void CanGetPlayers()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("test").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                PlayerService playerService = new PlayerService(context);
                Player player = new Player();
                await playerService.CreatePlayer(player);
                var expected = await context.Players.ToListAsync();
                var actual = await playerService.GetPlayers();
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public async void CanGetPlayerByGame()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("test").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                PlayerService playerService = new PlayerService(context);
                for(int i = 0; i < 5; i++)
                {
                    Player player = new Player()
                    {
                        GameID = 5,
                        Score = i
                    };
                    await playerService.CreatePlayer(player);
                }
                var expectedRaw = await context.Players.ToListAsync();
                var expected = expectedRaw.FindAll(p => p.GameID == 5);
                var actual = await playerService.GetPlayersByGame(5);
                Assert.Equal(expected, actual);
            }
        }

    }
}
