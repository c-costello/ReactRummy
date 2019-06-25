using Microsoft.EntityFrameworkCore;
using ReactRummy.Data;
using ReactRummy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactRummy.Models.Services
{
    public class PlayerService : IPlayer
    {
        private readonly GameDbContext _Context;

        public PlayerService(GameDbContext context)
        {
            _Context = context;
        }
        public async Task<Player> CreatePlayer(Player player)
        {
            _Context.Players.Add(player);
            await _Context.SaveChangesAsync();
            return player;
        }

        public async Task DeletePlayer(int id)
        {
            Player player = await _Context.Players.FirstOrDefaultAsync(p => p.ID == id);
            _Context.Players.Remove(player);
            await _Context.SaveChangesAsync();
        }

        public async Task<Player> GetPlayer(int id)
        {
            Player player = await _Context.Players.FirstOrDefaultAsync(p => p.ID == id);
            return player;
        }
        public async Task<Player> GetPlayerByUser(string user)
        {
            Player player = await _Context.Players.FirstOrDefaultAsync(p => p.User == user);
            return player;
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            IEnumerable<Player> players = await _Context.Players.ToListAsync();
            return players;
        }

        public async Task<IEnumerable<Player>> GetPlayersByGame(int gameID)
        {
            IEnumerable<Player> playersRaw = await _Context.Players.ToListAsync();
            IEnumerable<Player> players = playersRaw.Where(p => p.GameID == gameID);
            return players;

        }

        public async Task<Player> UpdatePlayer(Player player)
        {
            _Context.Players.Update(player);
            await _Context.SaveChangesAsync();
            return player;
        }
    }
}
