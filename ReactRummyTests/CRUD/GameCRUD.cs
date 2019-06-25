using System;
using Xunit;
using ReactRummy.Models;
using Microsoft.EntityFrameworkCore;
using ReactRummy.Data;
using ReactRummy.Models.Services;

namespace ReactRummyTests.CRUD
{
    public class GameCRUD
    {
        [Fact]
        public async void CanCreateGame()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("test").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                GameService gameService = new GameService(context);
                Game game = new Game();
                await gameService.CreateGame(game);
                var actual = await context.Games.FirstOrDefaultAsync(g => g.ID == game.ID);
                Assert.Equal(game, actual);
            }
        }
        [Fact]
        public async void CanUpdateGame()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("test").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                GameService gameService = new GameService(context);
                Game game = new Game();
                game.Status = Game.StatusType.Open;
                await gameService.CreateGame(game);
                game.Status = Game.StatusType.InGame;
                await gameService.UpdateGame(game);
                var actual = await context.Games.FirstOrDefaultAsync(g => g.ID == game.ID);
                Assert.Equal(game.Status, actual.Status);
            }

        }
        [Fact]
        public async void CanDeleteGame()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("test").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                GameService gameService = new GameService(context);
                Game game = new Game();
                await gameService.CreateGame(game);
                await gameService.DeleteGame(game.ID);
                var actual = await context.Games.FirstOrDefaultAsync(g => g.ID == game.ID);
                Assert.Null(actual);

            }
        }

        [Fact]
        public async void CanGetGame()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("test").Options;
            using(GameDbContext context = new GameDbContext(options))
            {
                GameService gameService = new GameService(context);
                Game game = new Game();
                await gameService.CreateGame(game);
                var expected = await context.Games.FirstOrDefaultAsync(g => g.ID == game.ID);
                var actual = await gameService.GetGame(game.ID);
                Assert.Equal(expected, actual);
            }
        }
        [Fact]
        public async void CanGetGames()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("test").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                GameService gameService = new GameService(context);
                Game game = new Game();
                await gameService.CreateGame(game);
                var expected = await context.Games.ToListAsync();
                var actual = await gameService.GetGames();
                Assert.Equal(expected, actual);
            }
        }
            
    }
}
