using Microsoft.EntityFrameworkCore;
using ReactRummy.Data;
using ReactRummy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactRummy.Models.Services
{
    public class GameService : IGame
    {
        private readonly GameDbContext _Context;

        public GameService(GameDbContext context)
        {
            _Context = context;
        }
        public async Task<Game> CreateGame(Game game)
        {
            _Context.Games.Add(game);
            await _Context.SaveChangesAsync();
            return game;
        }

        public async Task DeleteGame(int id)
        {
            Game game = await _Context.Games.FirstOrDefaultAsync(g => g.ID == id);
            _Context.Games.Remove(game);
            await _Context.SaveChangesAsync();
        }

        public async Task<Game> GetGame(int id)
        {
            Game game = await _Context.Games.FirstOrDefaultAsync(g => g.ID == id);
            return game;

        }

        public async Task<IEnumerable<Game>> GetGames()
        {
            IEnumerable<Game> games = await _Context.Games.ToListAsync();
            return games;
        }

        public async Task<Game> UpdateGame(Game game)
        {
            _Context.Games.Update(game);
            await _Context.SaveChangesAsync();
            return game;
        }
    }
}
