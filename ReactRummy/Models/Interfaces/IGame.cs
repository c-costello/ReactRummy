using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactRummy.Models.Interfaces
{
    public interface IGame 
    {
        Task<IEnumerable<Game>> GetGames();
        Task<Game> GetGame(int id);
        Task<Game> CreateGame(Game game);
        Task<Game> UpdateGame(Game game);
        Task<Game> DeleteGame(int id);
    }
}
